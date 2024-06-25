using XMLViewer.Data;

namespace XMLViewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var dataFolder = Path.Combine(AppContext.BaseDirectory, "data");

            //var products = ProductAggregator.AggregateProducts(dataFolder);

            var consolidator = new DataConsolidator();
            var products = consolidator.ConsolidateData(dataFolder);

            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Description.Names["pol"]}");
                Console.WriteLine($"Price: {product.Price.Gross} PLN");
                Console.WriteLine($"URL: {product.Card.Url}");

                Console.WriteLine("Images:");
                foreach (var image in product.Images)
                {
                    Console.WriteLine(image.Url);
                }

                Console.WriteLine("Do you want to add this product to your offer? (yes/no)");
                var input = Console.ReadLine();
                if (input.ToLower() == "yes")
                {
                    // Add to offer
                }
            }

            //var productService = new ProductService(products);
            //productService.DisplayProducts();

            //Console.WriteLine("Enter the ID of the product to flag as suitable for our offer:");
            //int productId = int.Parse(Console.ReadLine());
            //productService.FlagProduct(productId);
        }
    }
}
