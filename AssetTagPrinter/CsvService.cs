using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AssetTagPrinter
{
    public class CsvService
    {
        public IEnumerable<Asset> ReadAssets(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("CSV file not found.", filePath);
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var lines = ReadAllLinesWithEncodingFallback(filePath).Skip(1); // Skip header
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length >= 4)
                {
                    yield return new Asset
                    {
                        Id = int.Parse(values[0]),
                        Ref = values[1],
                        Label = values[2],
                        Barcode = values[3]
                    };
                }
            }
        }

        private static string[] ReadAllLinesWithEncodingFallback(string filePath)
        {
            var utf8 = File.ReadAllText(filePath, new UTF8Encoding(false));
            if (!utf8.Contains('�'))
            {
                return utf8.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);
            }

            var shiftJis = Encoding.GetEncoding(932);
            var sjisText = File.ReadAllText(filePath, shiftJis);
            return sjisText.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);
        }
    }
}
