using ProductsLinq.Contracts;
using ProductsLinq.Services;

namespace ProductsLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductsManager manager = new ProductsManager();
            List<Product> products = manager.GetProducts();
            
            Console.WriteLine("How to save? xml or json?");
            string saveType = Console.ReadLine();
            IProductSaver saver = GetProductSaverByName(saveType.ToUpper());
            saver?.SaveProducts(products);
        }

        static IProductSaver GetProductSaverByName(string name)
        {
            if (name == "XML")
            {
                return new XmlProductSaver();
            }
            else if (name == "JSON")
            {
                return new JsonProductsSaver();
            }
            return null;
        }
    }
}
