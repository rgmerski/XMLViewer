using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLViewer.ModelWithoutXMLAttrs
{
    internal class Product
    {
        public string Id { get; set; }
        public Price Price { get; set; }
        public Srp Srp { get; set; }
        public List<Size> Sizes { get; set; }
        public Producer Producer { get; set; }
        public Category Category { get; set; }
        public Unit Unit { get; set; }
        public Warranty Warranty { get; set; }
        public Card Card { get; set; }
        public List<Description> ShortDescriptions { get; set; }
        public List<Description> LongDescriptions { get; set; }
        public List<Image> Images { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
    
    public class Price
    {
        public decimal? Gross { get; set; }
        public decimal? Net { get; set; }
        public decimal? Vat { get; set; }
    }

    public class Srp
    {
        public decimal? Gross { get; set; }
        public decimal? Net { get; set; }
        public decimal? Vat { get; set; }
    }

    public class Size
    {
        public string Id { get; set; }
        public string CodeProducer { get; set; }
        public string Code { get; set; }
        public decimal Weight { get; set; }
        public Stock Stock { get; set; }
    }

    public class Stock
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
    }

    public class Producer
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Unit
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Warranty
    {
        public string Type { get; set; }
        public int Period { get; set; }
    }

    public class Card
    {
        public string Url { get; set; }
    }

    public class Description
    {
        public string Text { get; set; }
        public string Language { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
        public string Url2 { get; set; }
        public DateTime DateChanged { get; set; }
        public string Hash { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }


    public class Parameter
    {
        public int? Id;
        public string Lang;
        public string Name;
        public int? Priority;
    }
}
