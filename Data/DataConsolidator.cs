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
        public List<ModelWithoutAttrs> ConsolidateData(string dataFolder)
        {
            var allProducts = new List<ModelWithoutAttrs>();
            var filePaths = Directory.GetFiles(dataFolder, "*.xml");

            foreach (var filePath in filePaths)
            {
                var products = ProductParser.ParseXml(filePath, allProducts);
                allProducts.AddRange(products);
            }
            return allProducts;
        }
    }
}
