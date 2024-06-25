using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLViewer.ModelWithoutXMLAtts
{
    public class Price
    {
        public double Gross;
        public double Net;
        public double Vat;
    }

    public class Srp
    {
        public double Gross;
        public double Net;
        public double Vat;
    }

    public class Stock
    {
        public int Id;
        public int Quantity;
    }

    public class Size
    {
        public Stock Stock;
        public int Id;
        public double CodeProducer;
        public string Code;
        public int Weight;
        public Price Price;
        public Srp Srp;
    }

    public class Sizes
    {
        public Size Size;
    }

    public class Product
    {
        public Price Price;
        public Srp Srp;
        public Sizes Sizes;
        public int Id;
        public Producer Producer;
        public Category Category;
        public Unit Unit;
        public Warranty Warranty;
        public Card Card;
        public Description Description;
        public Images Images;
        public Icons Icons;
        public Parameters Parameters;
        public Group Group;
        public string Currency;
        public string CodeProducer;
        public int Site;
        public string Text;
        public double Ean;
        public string Sku;
        public bool InStock;
        public int Qty;
        public object Availability;
        public string Name;
        public string Desc;
        public string Url;
        public Categories Categories;
        public object Attributes;
        public double Weight;
        public string PKWiU;
        public bool RequiredBox;
        public int QuantityPerBox;
        public double PriceAfterDiscountNet;
        public int Vat;
        public int RetailPriceGross;
        public Photos Photos;
    }

    public class Products
    {
        public List<Product> Product;
        public string Currency;
        public string Iaiext;
        public string Language;
        public string Text;
        public int Elments;
        public int Clientid;
        public string Lang;
        public string Datetime;
        public int Template;
        public int Version;
    }

    public class Offer
    {
        public Products Products;
        public string FileFormat;
        public DateTime Version;
        public DateTime Generated;
        public string Iaiext;
        public string Currency;
        public string Extensions;
        public string Text;
    }

    public class Producer
    {
        public int Id;
        public string Name;
    }

    public class Category
    {
        public int Id;
        public string Lang;
        public string Name;
        public string Text;
    }

    public class Unit
    {
        public int Id;
        public string Lang;
        public string Name;
    }

    public class Warranty
    {
        public int Id;
        public string Type;
        public int Period;
    }

    public class Card
    {
        public string Url;
    }

    public class Name
    {
        public string Lang;
        public string Text;
    }

    public class Version
    {
        public List<Name> Name;
        public string Text;
    }

    public class LongDesc
    {
        public string Lang;
        public string Text;
    }

    public class ShortDesc
    {
        public string Lang;
        public string Text;
    }

    public class Description
    {
        public List<Name> Name;
        public Version Version;
        public List<LongDesc> LongDesc;
        public List<ShortDesc> ShortDesc;
    }

    public class Image
    {
        public string Url;
        public string Url2;
        public DateTime DateChanged;
        public string Hash;
        public int Width;
        public int Height;
    }

    public class Large
    {
        public List<Image> Image;
    }

    public class Icon
    {
        public string Url;
        public string Url2;
        public DateTime DateChanged;
        public string Hash;
        public int Width;
        public int Height;
    }

    public class Icons
    {
        public Icon Icon;
        public AuctionIcon AuctionIcon;
    }

    public class Originals
    {
        public List<Image> Image;
    }

    public class Images
    {
        public Large Large;
        public Icons Icons;
        public Originals Originals;
        public string External;
    }

    public class AuctionIcon
    {
        public DateTime DateChanged;
        public string Hash;
        public int Height;
        public int Width;
        public string Url;
        public string Url2;
    }

    public class Value
    {
        public int Id;
        public string Lang;
        public double Name;
        public int Priority;
    }

    public class Parameter
    {
        public List<Value> Value;
        public int Id;
        public string Lang;
        public string Name;
        public int Priority;
    }

    public class Parameters
    {
        public List<Parameter> Parameter;
    }

    public class ProductValue
    {
        public string Id;
        public double Name;
    }

    public class GroupByParameter
    {
        public ProductValue ProductValue;
        public string Id;
        public string Name;
    }

    public class Group
    {
        public GroupByParameter GroupByParameter;
        public int Id;
    }

    public class Categories
    {
        public List<Category> Category;
    }

    public class Photo
    {
        public int Id;
        public int Main;
        public string Text;
    }

    public class Photos
    {
        public List<Photo> Photo;
    }

    public class Root
    {
        public List<Offer> Offer;
        public List<Products> Products;
    }
}
