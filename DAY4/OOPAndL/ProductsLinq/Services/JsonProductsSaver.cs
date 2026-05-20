using ProductsLinq.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ProductsLinq.Services
{
    internal class JsonProductsSaver : IProductSaver
    {
        private string _filePath = "products.json";

        public List<Product> LoadProduct()
        {
            var jsonString = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Product>>(jsonString); // read
        }

        public void SaveProducts(List<Product> products)
        {
            string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true }); // write
            File.WriteAllText(_filePath, json);
        }
    }
}
