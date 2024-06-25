// using System.Xml.Serialization;
// XmlSerializer serializer = new XmlSerializer(typeof(Offer));
// using (StringReader reader = new StringReader(xml))
// {
//    var test = (Offer)serializer.Deserialize(reader);
// }

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

public class Stock
{
    public int Id;
    public int Quantity;
}

public class Size
{
    public Price Price;
    public Srp Srp;
    public Stock Stock;
    public int Id;
    public double CodeProducer;
    public string Code;
    public int Weight;
}

public class Sizes
{
    public Size Size;
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

public class Product
{
    public Producer Producer;
    public Category Category;
    public Unit Unit;
    public Warranty Warranty;
    public Card Card;
    public Description Description;
    public Price Price;
    public Srp Srp;
    public Images Images;
    public Icons Icons;
    public Sizes Sizes;
    public Parameters Parameters;
    public Group Group;
    public int Id;
    public string Currency;
    public string CodeProducer;
    public int Site;
    public string Text;
}

public class Products
{
    public Product Product;
    public string Iaiext;
    public string Language;
    public string Text;
}

public class Offer
{
    public Products Products;
    public string Iaiext;
    public string FileFormat;
    public DateTime Generated;
    public string Currency;
    public DateTime Version;
    public string Extensions;
    public string Text;
}

