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
                if (values.Length >= 3)
                {
                    yield return new Asset
                    {
                        ItemName = values[0],
                        SKU = values[1],
                        Price = values[2]
                    };
                }
            }
        }
    }
}
