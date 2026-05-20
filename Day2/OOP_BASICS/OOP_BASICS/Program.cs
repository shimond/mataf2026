namespace OOP_BASICS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[3];
            for (int i = 0; i < products.Length; i++)
            {
                
                Console.WriteLine("Enter product details No" + (i + 1));
                Console.WriteLine("Name:");
                string tmpName = Console.ReadLine(); 
                products[i] = new Product(tmpName);
                
                Console.WriteLine("Price");
                products[i].Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Is kosher");
                products[i].IsKosher = bool.Parse(Console.ReadLine());
            }
            //for, while, do while, 
            double maxPrice = double.MinValue;
            Product maxProduct = null;
            foreach (Product product in products)
            {
                if (product.Price > maxPrice)
                {
                    maxPrice = product.Price;
                    maxProduct = product;
                }
            }
            Console.WriteLine("Max price product is : " + maxProduct.Name);
        }
    }
}
