using System;
using Microsoft.PointOfService;

namespace AssetTagPrinter
{
    public class PrinterService
    {
        private PosPrinter _printer;
        private PosExplorer _posExplorer;

        public PrinterService()
        {
            _posExplorer = new PosExplorer();
            DeviceInfo printerDevice = _posExplorer.GetDevice(DeviceType.PosPrinter);
            if (printerDevice == null)
            {
                throw new Exception("No POS printer found.");
            }

            _printer = (PosPrinter)_posExplorer.CreateInstance(printerDevice);
        }

        public void Open()
        {
            _printer.Open();
            _printer.Claim(1000);
            _printer.DeviceEnabled = true;
        }

        public void PrintAssetTag(Asset asset)
        {
            string normal = "\x1b|N";
            string center = "\x1b|cA";
            string bold = "\x1b|bC";
            string cut = "\x1b|fP";

            _printer.PrintNormal(PrinterStation.Receipt, $"{normal}{center}{bold}*** ASSET TAG ***\n\n");
            _printer.PrintNormal(PrinterStation.Receipt, $"Item: {asset.ItemName}\n");
            _printer.PrintNormal(PrinterStation.Receipt, $"SKU: {asset.SKU}\n");
            _printer.PrintNormal(PrinterStation.Receipt, $"Price: ${asset.Price}\n\n");
            _printer.PrintNormal(PrinterStation.Receipt, "-----------------\n");
            _printer.PrintNormal(PrinterStation.Receipt, $"{cut}");

            Console.WriteLine($"Printed asset tag for: {asset.ItemName}");
        }

        public void Close()
        {
            if (_printer != null)
            {
                try
                {
                    _printer.DeviceEnabled = false;
                    _printer.Release();
                    _printer.Close();
                }
                catch (PosControlException)
                {
                    // Ignore exceptions on close
                }
            }
        }
    }
}
