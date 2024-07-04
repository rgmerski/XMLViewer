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
        private static List<Product> MergeProducts(List<Product> products)
        {
            // Implementacja łączenia produktów
            var mergedProducts = products
                .GroupBy(p => p.Id)
                .Select(g =>
                {
                    var product = g.First();
                    foreach (var p in g.Skip(1))
                    {
                        product.Merge(p);
                    }
                    return product;
                })
                .ToList();
            return mergedProducts;
        }

        public List<Product> ConsolidateData(string dataFolder)
        {
            var allProducts = new List<Product>();
            var filePaths = Directory.GetFiles(dataFolder, "*.xml");
            //var filePaths = Directory.GetFiles(dataFolder, "dostawca3plik1.xml");

            foreach (var filePath in filePaths)
            {
                var products = ProductParser.ParseXml(filePath, allProducts);
                allProducts.AddRange(products);
            }

            return allProducts;
        }
    }
}