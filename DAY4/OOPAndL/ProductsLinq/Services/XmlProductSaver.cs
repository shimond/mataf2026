using ProductsLinq.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductsLinq.Services
{
    public class XmlProductSaver : IProductSaver
    {
        private string _filePath = "products.xml";
        public List<Product> LoadProduct()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            using (var reader = new System.IO.StreamReader(_filePath))
            {
                return (List<Product>)serializer.Deserialize(reader);
            }
        }

        public void SaveProducts(List<Product> products)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            using (var writer = new System.IO.StreamWriter(_filePath))
            {
                serializer.Serialize(writer, products);
            }
        }
    }
}
