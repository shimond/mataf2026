using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_BASICS
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
            Console.WriteLine("Product created");
        }
        public string Name { get; set; }
        public string Manufaturer { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public bool IsKosher { get; set; }

       

    }
}
