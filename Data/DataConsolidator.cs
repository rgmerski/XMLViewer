using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLViewer.ModelWithoutXMLAttrs;
//using XMLViewer.ModelWithoutXMLAtts;

namespace XMLViewer.Data
{
    internal class DataConsolidator
    {
        public List<Product> ConsolidateData(string dataFolder)
        {
            var allProducts = new List<Product>();
            //var filePaths = Directory.GetFiles(dataFolder, "*.xml");
            var filePaths = Directory.GetFiles(dataFolder, "dostawca1plik2.xml");

            foreach (var filePath in filePaths)
            {
                var products = ProductParser.ParseXml(filePath, allProducts);
                allProducts.AddRange(products);
            }
            return allProducts;
        }
    }
}
