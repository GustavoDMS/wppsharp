using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wppsharp
{
    public partial class Client
    {
        const string WHATSAPP_URL = "web.whatsapp.com";

        string INTRO_IMG_SELECTOR = "[data-testid=\"intro-md-beta-logo-dark\"], [data-testid=\"intro-md-beta-logo-light\"], [data-asset-intro-image-light=\"true\"], [data-asset-intro-image-dark=\"true\"]";
        const string INTRO_QRCODE_SELECTOR = "div[data-ref] canvas";

        string[] args = new string[]
                                {
                                  "--enable-gpu",
                                  "--display-entrypoints",
                                  "--disable-http-cache",
                                  "--no-sandbox",
                                  "--disable-setuid-sandbox",
                                  "--disable-2d-canvas-clip-aa",
                                  "--disable-2d-canvas-image-chromium",
                                  "--disable-3d-apis",
                                  "--disable-accelerated-2d-canvas",
                                  "--disable-accelerated-jpeg-decoding",
                                  "--disable-accelerated-mjpeg-decode",
                                  "--disable-accelerated-video-decode",
                                  "--disable-app-list-dismiss-on-blur",
                                  "--disable-audio-output",
                                  "--disable-background-timer-throttling",
                                  "--disable-backgrounding-occluded-windows",
                                  "--disable-breakpad",
                                  "--disable-canvas-aa",
                                  "--disable-client-side-phishing-detection",
                                  "--disable-component-extensions-with-background-pages",
                                  "--disable-composited-antialiasing",
                                  "--disable-default-apps",
                                  "--disable-dev-shm-usage",
                                  "--disable-extensions",
                                  "--disable-features=TranslateUI,BlinkGenPropertyTrees",
                                  "--disable-field-trial-config",
                                  "--disable-fine-grained-time-zone-detection",
                                  "--disable-geolocation",
                                  "--disable-gl-extensions",
                                  "--disable-gpu",
                                  "--disable-gpu-early-init",
                                  "--disable-gpu-sandbox",
                                  "--disable-gpu-watchdog",
                                  "--disable-histogram-customizer",
                                  "--disable-in-process-stack-traces",
                                  "--disable-infobars",
                                  "--disable-ipc-flooding-protection",
                                  "--disable-notifications",
                                  "--disable-popup-blocking",
                                  "--disable-renderer-backgrounding",
                                  "--disable-session-crashed-bubble",
                                  "--disable-setuid-sandbox",
                                  "--disable-site-isolation-trials",
                                  "--disable-software-rasterizer",
                                  "--disable-sync",
                                  "--disable-threaded-animation",
                                  "--disable-threaded-scrolling",
                                  "--disable-translate",
                                  "--disable-webgl",
                                  "--disable-webgl2",
                                  "--enable-features=NetworkService",
                                  "--force-color-profile=srgb",
                                  "--hide-scrollbars",
                                  "--ignore-certifcate-errors",
                                  "--ignore-certifcate-errors-spki-list",
                                  "--ignore-certificate-errors",
                                  "--ignore-certificate-errors-spki-list",
                                  "--ignore-gpu-blacklist",
                                  "--ignore-ssl-errors",
                                  "--log-level=3",
                                  "--metrics-recording-only",
                                  "--mute-audio",
                                  "--no-crash-upload",
                                  "--no-default-browser-check",
                                  "--no-experiments",
                                  "--no-first-run",
                                  "--no-sandbox",
                                  "--no-zygote",
                                  "--renderer-process-limit=1",
                                  "--safebrowsing-disable-auto-update",
                                  "--silent-debugger-extension-api",
                                  "--single-process",
                                  "--unhandled-rejections=strict",
                                  "--window-position=0,0" };
    }
}
