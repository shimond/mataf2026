namespace ExeptionHandleEx
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var names = new string[] { "Alice", "Bob", "Charlie" };
            var name = names.FirstOrDefault(x => x[0] == 'D');  
            Console.WriteLine(name.Length);

            while (true)
            {


                Console.WriteLine("Enter number");
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine("AFTER PARSING");
                    Console.WriteLine(100 / number);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Cannot divide by zero.");
                }
            }
            Console.WriteLine("END");

        }
    }
}
