using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace ProductsLinq
{
    public class ProductsManager
    {
        private string _filePath = "products.json";
        
        public Product GetExpensiveProduct(List<Product> products)
        {
            //ver3:
            return products.MaxBy(x => x.Price);

            ////ver2:
            //var maxPrice = products.Max(x => x.Price);
            //var expensiveProduct = products.FirstOrDefault(x => x.Price == maxPrice);
            //return expensiveProduct;


            //ver1:
            //double maxPrice = double.MinValue;
            //Product expensiveProduct = null;
            //foreach (var item in products)
            //{
            //    if (item.Price > maxPrice)
            //    {
            //        maxPrice = item.Price;
            //        expensiveProduct = item;
            //    }
            //}

            //return expensiveProduct;
        }

        public void PrintProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            while (true)
            {
                Console.WriteLine("Enter product details:");
                Console.WriteLine("ID:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Price:");
                double price = double.Parse(Console.ReadLine());
                
                Product product = new Product
                {
                    Id = id,
                    Name = name,
                    Price = price
                };
                products.Add(product);
                Console.WriteLine(  "Continue? Y/N");
                string choice = Console.ReadLine();
                if (choice != "Y")
                {
                    break;
                }
            }
            return products;
        }
    }
}
