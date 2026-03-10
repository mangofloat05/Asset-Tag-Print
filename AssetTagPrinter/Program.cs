using System;

namespace AssetTagPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            PrinterService printerService = null;
            try
            {
                var csvService = new CsvService();
                var assets = csvService.ReadAssets("data.csv");

                printerService = new PrinterService();
                printerService.Open();

                foreach (var asset in assets)
                {
                    printerService.PrintAssetTag(asset);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                printerService?.Close();
            }
        }
    }
}
