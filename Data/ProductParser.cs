using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLViewer.ModelWithoutXMLAttrs;
using System.Xml;

using XMLViewer.ModelWithoutXMLAttrs;

//using XMLViewer.ModelWithoutXMLAtts;

//using XMLViewer.ModelWithoutXMLAtts;
//Atts - z konwertera, inne pola
namespace XMLViewer.Data
{
    internal class ProductParser
    {
        public static List<Product> ParseXml(string filePath, List<Product> allProducts)
        {
            XDocument doc = XDocument.Load(filePath);
            var products = new List<Product>();


            //Pliki XML zawierają przecinki, które decimal.Parse wyłapuje jako przerwy tysięczne. Załóżmy, że takowe nie są tutaj używane
            CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR");

            XNamespace iaiext = doc.Root.GetNamespaceOfPrefix("iaiext");

            //Znajdź produkty
            foreach (var element in doc.Descendants("product"))
            {
                //Produkt o danym ID może już istnieć, gdyż mogą to być pliki, gdzie dane są rozłożone - stwórz i tak za każdym razem nowy, potem je połącz

                // TODO - obsługa sytuacji, jak nie znajdzie, bo np. są te dane w drugim pliku i potem to połączyć 
                // pobieranie elementu wcześniej i sprawdzanie nulli, jeśli nie to przypisz
                var product = new Product
                {
                    Id = element.Attribute("id")?.Value,
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
                    Sizes = new List<Size>(),
                    Images = new List<Image>(),
                    Parameters = new List<Parameter>(),
                    ShortDescriptions = new List<Description>(),
                    LongDescriptions = new List<Description>()
                };

                foreach (var sizeElement in element.Descendants("size"))
                {
                    var size = new Size
                    {
                        Id = sizeElement.Attribute("id").Value,
                        CodeProducer = sizeElement.Attribute("code_producer").Value,
                        Code = sizeElement.Attribute("code").Value,
                        Weight = decimal.Parse(sizeElement.Attribute("weight")?.Value),
                        Stock = new Stock
                        {
                            Id = sizeElement.Element("stock").Attribute("id").Value,
                            Quantity = int.Parse(sizeElement.Element("stock").Attribute("quantity").Value)
                        }
                    };
                    product.Sizes.Add(size);
                }

                foreach (var imageElement in element.Descendants("image"))
                {
                    int w, h;
                    if (!int.TryParse(imageElement.Attribute(iaiext + "width").Value, out w))
                    {
                        Console.WriteLine($"Błąd parsowania rozmiarów zdjęcia dla {product.Id} - szerokość");
                        w = 0;
                    }

                    if (!int.TryParse(imageElement.Attribute(iaiext + "height").Value, out h))
                    {
                        Console.WriteLine($"Błąd parsowania rozmiarów zdjęcia dla {product.Id} - wysokość");
                        h = 0;
                    }

                    var image = new Image
                    {
                        Url = imageElement.Attribute("url").Value,
                        Url2 = imageElement.Attribute(iaiext + "url2").Value,
                        Width = w,
                        Height = h,
                    };
                    product.Images.Add(image);
                }

                foreach (var parameterElement in element.Descendants("parameter"))
                {
                    var parameter = new Parameter
                    {
                        Id = int.Parse(parameterElement.Attribute("id").Value),
                        Lang = parameterElement.Attribute(XNamespace.Xml + "lang")?.Value,
                        Name = parameterElement.Attribute("name").Value,
                        Priority = int.Parse(parameterElement.Attribute(iaiext + "priority").Value),
                    };
                    product.Parameters.Add(parameter);
                }

                foreach (var descriptionElement in element.Descendants("short_desc"))
                {
                    var description = new Description
                    {
                        Language = descriptionElement.Attribute(XNamespace.Xml + "lang").Value,
                        Text = descriptionElement.Value
                    };
                    product.ShortDescriptions.Add(description);
                }

                foreach (var descriptionElement in element.Descendants("long_desc"))
                {
                    var description = new Description
                    {
                        Language = descriptionElement.Attribute(XNamespace.Xml + "lang").Value,
                        Text = descriptionElement.Value
                    };
                    product.LongDescriptions.Add(description);
                }

                products.Add(product);
            }
            return products;
        }
    }
}