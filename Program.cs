using System.Diagnostics;
using System.Net;
using XMLViewer.Data;

namespace XMLViewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var dataFolder = Path.Combine(AppContext.BaseDirectory, "data");


            var consolidator = new DataConsolidator();
            var products = consolidator.ConsolidateData(dataFolder);


            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}");
                Console.WriteLine($"Price: {product.Price.Gross}");
                Console.WriteLine("Images:");

                foreach (var image in product.Images)
                {
                    // Pobierz zdjęcia
                    string localPath = DownloadImage(image.Url);
                    if (!string.IsNullOrEmpty(localPath))
                    {
                        OpenImage(localPath);
                    }
                    if (image.Url2 != null)
                    {
                        string localPath2 = DownloadImage(image.Url2);
                        if (!string.IsNullOrEmpty(localPath2))
                        {
                            OpenImage(localPath2);
                        }
                    }
                    Console.WriteLine(image.Url);
                    Console.WriteLine(image.Url2);
                }

                Console.WriteLine("Descriptions:");
                foreach (var description in product.ShortDescriptions)
                {
                    Console.WriteLine($"In {description.Language}");
                    Console.WriteLine(description.Text);
                }
                foreach (var description in product.LongDescriptions)
                {
                    Console.WriteLine($"In {description.Language}");
                    Console.WriteLine(description.Text);
                }

                Console.WriteLine("Do you want to add this product to your offer? (yes/no)");
                var input = Console.ReadLine();
                if (input.ToLower() == "yes")
                {
                    // Add to offer
                }
            }

        }


        // Pobierz zdjęcia i je uruchom
        static string DownloadImage(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string fileName = Path.GetFileName(new Uri(url).LocalPath);
                    string localPath = Path.Combine(Path.GetTempPath(), fileName);
                    client.DownloadFile(url, localPath);
                    return localPath;
                }
            }
            catch (Exception ex)
            {
                //Możliwa błędna obsługa błędu - pliki się pobierają i uruchamiają
                //Console.WriteLine($"Could not download image {url}: {ex.Message}");
                return null;
            }
        }

        static void OpenImage(string imagePath)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = imagePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not open image {imagePath}: {ex.Message}");
            }
        }
    }
}
