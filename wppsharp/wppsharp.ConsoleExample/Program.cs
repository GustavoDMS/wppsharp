using QRCoder;
using wppsharp;
Client c = new Client("Teste");

c.OnQrCodeChange += c_OnQrCodeChange;
c.Initialize().Wait();

void c_OnQrCodeChange(string token)
{
    Console.Clear();
    QRCodeData qrCodeData = new QRCodeGenerator().CreateQrCode(token, QRCodeGenerator.ECCLevel.L);

    AsciiQRCode qrCode = new AsciiQRCode(qrCodeData);

    string qrCodeAsAsciiArt = qrCode.GetGraphicSmall();

    Console.WriteLine(qrCodeAsAsciiArt);
}