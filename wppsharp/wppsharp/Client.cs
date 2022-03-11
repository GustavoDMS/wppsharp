using Microsoft.Playwright;

namespace wppsharp
{
    public partial class Client
    {
        #region Events
        public delegate void OnQrCodeChangeEventHandler(string token);

        public event OnQrCodeChangeEventHandler OnQrCodeChange;

        private async Task Page_OnQrCodeChange(string token)
        {
            OnQrCodeChangeEventHandler checkEvent = OnQrCodeChange;
            if (OnQrCodeChange != null)
                OnQrCodeChange(token);

        }
        #endregion

        private string CLIENT_NAME;
        public Client(string name)
        {
            CLIENT_NAME = name;

        }

        public async Task Initialize()
        {
            IPlaywright playwright = await Playwright.CreateAsync();
            IBrowserType browser = playwright.Chromium;

            string UserDataDir = $"{AppDomain.CurrentDomain.BaseDirectory}\\BrowserData\\{CLIENT_NAME}";
            if (!Directory.Exists(UserDataDir))
            {
                Directory.CreateDirectory(UserDataDir);
            }

            BrowserTypeLaunchPersistentContextOptions launchOptions = new BrowserTypeLaunchPersistentContextOptions
            {
                // Args = args,
                Args = new string[0],
                Headless = false,
                Devtools = true,
                Channel = "chrome",
                BypassCSP = true,
                UserAgent = "WhatsApp/2.2043.8 Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36"
            };

            IBrowserContext browserContext = await browser.LaunchPersistentContextAsync(UserDataDir, launchOptions);
            IPage page = browserContext.Pages[0];
            await page.GotoAsync("https://web.whatsapp.com");

            //Verifica se está autenticado
            var findQrCode = await page.WaitForSelectorAsync(INTRO_QRCODE_SELECTOR, new PageWaitForSelectorOptions { Timeout = 0 });
            bool needAuthenticate = findQrCode == null ? false : true;

            const string QR_CONTAINER = "div[data-ref]";
            const string QR_RETRY_BUTTON = "div[data-ref] > span > button";
            var qrRetries = 0;

            await page.ExposeFunctionAsync<string, Task>("qrChanged", Page_OnQrCodeChange);
            await page.EvaluateAsync(@"function (selectors) {
                const qr_container = document.querySelector(selectors.QR_CONTAINER);
                window.qrChanged(qr_container.dataset.ref);

                const obs = new MutationObserver((muts) => {
                    muts.forEach(mut => {
                        // Listens to qr token change
                        if (mut.type === 'attributes' && mut.attributeName === 'data-ref') {
                            window.qrChanged(mut.target.dataset.ref);
                        } else
                        // Listens to retry button, when found, click it
                        if (mut.type === 'childList') {
                            const retry_button = document.querySelector(selectors.QR_RETRY_BUTTON);
                            if (retry_button) retry_button.click();
                        }
                    });
                });
                obs.observe(qr_container.parentElement, {
                    subtree: true,
                    childList: true,
                    attributes: true,
                    attributeFilter: ['data-ref'],
                });
            }", new
            {
                QR_CONTAINER,
                QR_RETRY_BUTTON
            });
            await page.WaitForSelectorAsync(INTRO_IMG_SELECTOR, new PageWaitForSelectorOptions { Timeout = 0 });
            //await page.EvaluateAsync("ExposeStore", );

        }

    }
}

