using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLViewer.ModelWithoutXMLAttrs;

using XMLViewer.ModelWithoutXMLAttrs;
//using XMLViewer.ModelWithoutXMLAtts;
//Atts - z konwertera, inne pola
namespace XMLViewer.Data
{
    internal class ProductParser
    {
        public static List<ModelWithoutAttrs> ParseXml(string filePath, List<ModelWithoutAttrs> allProducts)
        {
            XDocument doc = XDocument.Load(filePath);
            var products = new List<ModelWithoutAttrs>();

            //Pliki XML zawierają przecinki, które decimal.Parse wyłapuje jako przerwy tysięczne. Załóżmy, że takowe nie są tutaj używane
            CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR");

            //Znajdź produkty
            foreach (var element in doc.Descendants("product"))
            {
                //Produkt o danym ID może już istnieć, gdyż mogą to być pliki, gdzie dane są rozłożone - kiedy już istnieje, nie twórz nowego, ewentualnie dodaj najważniejsze dane
                // TODO!!!!! co jeśli plik nie zawiera id? a zawiera go np. drugi plik od dostawcy? może najpierw złączyć te pliki i potem dopiero odczytywać?
                // tutaj może być przydatny product.elments, albo po prostu złączenie plików przed przy pomocy elments (dostawca2)
                var productId = element.Attribute("id").Value;
                var find = allProducts.Find(p => p.Id == productId);
                if (find != null)
                {
                   // dodaj dane
                }
                else
                {
                    var product = new ModelWithoutAttrs
                    {
                        Id = element.Attribute("id").Value,
                        Price = new Price
                        {
                            Gross = decimal.Parse(element.Element("price").Attribute("gross").Value, CultureInfo.InvariantCulture),
                            Net = decimal.Parse(element.Element("price").Attribute("net").Value, CultureInfo.InvariantCulture),
                            Vat = decimal.Parse(element.Element("price").Attribute("vat").Value, CultureInfo.InvariantCulture)
                        },
                        Srp = new Srp
                        {
                            Gross = decimal.Parse(element.Element("srp").Attribute("gross").Value, CultureInfo.InvariantCulture),
                            Net = decimal.Parse(element.Element("srp").Attribute("net").Value, CultureInfo.InvariantCulture),
                            Vat = decimal.Parse(element.Element("srp").Attribute("vat").Value, CultureInfo.InvariantCulture)
                        },
                        Sizes = new List<Size>()
                    };

                    foreach (var sizeElement in element.Descendants("size"))
                    {
                        var size = new Size
                        {
                            Id = sizeElement.Attribute("id").Value,
                            CodeProducer = sizeElement.Attribute("code_producer").Value,
                            Code = sizeElement.Attribute("code").Value,
                            Weight = decimal.Parse(sizeElement.Attribute("weight").Value),
                            Stock = new Stock
                            {
                                Id = sizeElement.Element("stock").Attribute("id").Value,
                                Quantity = int.Parse(sizeElement.Element("stock").Attribute("quantity").Value)
                            }
                        };
                        product.Sizes.Add(size);
                    }
                    products.Add(product);
                }
                
            }
            return products;
        }
    }
}
