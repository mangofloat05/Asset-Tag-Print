using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            var lines = File.ReadAllLines(filePath).Skip(1); // Skip header
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
    }
}
