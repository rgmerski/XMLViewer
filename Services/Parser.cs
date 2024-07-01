using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLViewer.ModelWithoutXMLAttrs;

namespace XMLViewer.Services
{
    internal class Parser
    {
        private static decimal GetAttributeValueAsDecimal(XElement element, string attributeName, decimal defaultValue)
        {
            if (element == null) return defaultValue;

            XAttribute attribute = element.Attribute(attributeName);
            if (attribute == null || string.IsNullOrEmpty(attribute.Value))
            {
                return defaultValue;
            }

            if (decimal.TryParse(attribute.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }

            return defaultValue;
        }

        private static int GetAttributeValueAsInteger(XElement element, string attributeName, int defaultValue)
        {
            if (element == null) return defaultValue;

            XAttribute attribute = element.Attribute(attributeName);
            if (attribute == null || string.IsNullOrEmpty(attribute.Value))
            {
                return defaultValue;
            }

            if (int.TryParse(attribute.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
            {
                return result;
            }

            return defaultValue;
        }

        private static string GetAttributeValueAsString(XElement element, string attributeName, string defaultValue, XNamespace xnm = null)
        {
            if (element == null) return defaultValue;

            
            XAttribute attribute = element.Attribute(attributeName);
            if (xnm != null) attribute = element.Attribute(xnm + attributeName);
            if (attribute == null || string.IsNullOrEmpty(attribute.Value))
            {
                return defaultValue;
            }
            return attribute.Value;
        }

        public static Price PriceParser(XElement element)
        {
            decimal gross = GetAttributeValueAsDecimal(element.Element("price"), "gross", -1);
            decimal net = GetAttributeValueAsDecimal(element.Element("price"), "net", -1);
            decimal vat = GetAttributeValueAsDecimal(element.Element("price"), "vat", -1);

            return new Price
            {
                Gross = gross,
                Net = net,
                Vat = vat
            };
        }

        public static Srp SrpParser(XElement element)
        {
            decimal gross = GetAttributeValueAsDecimal(element.Element("price"), "gross", -1);
            decimal net = GetAttributeValueAsDecimal(element.Element("price"), "net", -1);
            decimal vat = GetAttributeValueAsDecimal(element.Element("price"), "vat", -1);

            return new Srp
            {
                Gross = gross,
                Net = net,
                Vat = vat
            };
        }

        public static Size SizeParser(XElement element)
        {
            decimal weight = GetAttributeValueAsDecimal(element, "weight", -1);

            int quantity = GetAttributeValueAsInteger(element.Element("stock"), "quantity", -1);
            return new Size
            {
                Id = GetAttributeValueAsString(element, "id", ""),
                CodeProducer = GetAttributeValueAsString(element, "code_producer", ""),
                Code = GetAttributeValueAsString(element, "code", ""),
                Weight = weight, // tutaj nie mam pewności, czy waga jest tak samo zapisana, wszędzie w plikach jest jako 0
                Stock = new Stock
                {
                    Id = GetAttributeValueAsString(element.Element("stock"), "id", ""),
                    Quantity = quantity
                }
            };
        }

        public static Image ImageParser(XElement element, XNamespace xnm)
        {
            int w = GetAttributeValueAsInteger(element, "width", -1);
            int h = GetAttributeValueAsInteger(element, "height", -1);

            return new Image
            {
                Url = GetAttributeValueAsString(element, "url", ""),
                //Url = element.Attribute("url").Value,
                Url2 = GetAttributeValueAsString(element, "url2", "", xnm),
                //Url2 = element.Attribute(xnm + "url2").Value,
                Width = w,
                Height = h,
            };
        }
    }
}