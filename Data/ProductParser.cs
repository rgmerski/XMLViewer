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
using XMLViewer.Services;

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
                    Price = Parser.PriceParser(element),
                    Srp = Parser.SrpParser(element),
                    Sizes = new List<Size>(),
                    Images = new List<Image>(),
                    Parameters = new List<Parameter>(),
                    ShortDescriptions = new List<Description>(),
                    LongDescriptions = new List<Description>()
                };

                foreach (var sizeElement in element.Descendants("size"))
                {
                    var size = Parser.SizeParser(sizeElement);
                    product.Sizes.Add(size);
                }

                foreach (var imageElement in element.Descendants("image"))
                {
                    var image = Parser.ImageParser(imageElement, iaiext);
                    product.Images.Add(image);
                }

                // Zdjęcia również zapisane są w elemencie o nazwie photos
                foreach (var imageElement in element.Descendants("photo"))
                {
                    var image = Parser.PhotosParser(imageElement);
                    product.Images.Add(image);
                }

                // Poniższe parsery zostawiam, ponieważ są krótkie
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