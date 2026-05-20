namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person> {
                new Person { Id = 1, Name = "Alice", Age = 30, Email = "alice@example.com" }, //117
                new Person { Id = 2, Name = "Bob", Age = 25, Email = "bob@example.com" }, //118
                new Person { Id = 3, Name = "Charlie", Age = 30, Email = "charlie@example.com" }, //119
                new Person { Id = 4, Name = "David", Age = 25, Email = "david@example.com" } //120
            };


            while (true)
            {
                Console.WriteLine(  "Enter ID");
                int id = int.Parse(Console.ReadLine());

                Person p1 = new Person()
                {
                    Id = id,
                    Name = "Eve",
                    Age = 35,
                    Email = "  "
                };

                people.Add(p1);
            }

            

            int[] arr = { 1, 2, 3, 4, 5 };
            int[] evens = arr.Where(x=> x % 2 == 0).ToArray();
            var r = people.OrderBy(x => x.Age).ThenBy(x=>x.Name).ToList();
            var r1 = people.FirstOrDefault(x => x.Age > 50);
            var names = people.Select(x => x.Name).ToList();

            var agesGroup = people.GroupBy(x => x.Age);
            foreach (var group in agesGroup)
            {
                Console.WriteLine(group.Key);
                foreach (var person in group)
                {
                    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}, Email: {person.Email}");
                }
                Console.WriteLine(  "__________");
            }

            List<Person> results = people.Where(p => p.Age > 30).ToList();
            List<Person> results1 = Filter(people, p => p.Age > 30);
            List<Person> results2 = Filter(people, delegate (Person p)
            {
                return p.Age > 30;
            });



            //int x = 20;
            //List<Person> results3  = Filter(people, p => p.Age > x) ;


            //List<Person> results2 = Filter(people, person =>
            //{
            //    Console.WriteLine("Test items number...");
            //    return person.Age > x;
            //});


            //Func<bool> test = () => true;


            //Func<int, string, Person, bool> fileter = (x, y, person) => true;

            //List<Person> results3 = Filter(people, IsOlderThan30);


            Print(results);
        }

        static bool IsOlderThan30(Person person)
        {
            return person.Age > 30;
        }
        //static bool IsEmailAndAgeValid(Person person)
        //{
        //    return person.Age > 0 && person.Email.Contains("@"); 
        //}
        static List<Person> Filter(List<Person> people, Func<Person, bool> func1)
        {
            var results = new List<Person>();
            foreach (var person in people)
            {
                if (func1(person))
                {
                    results.Add(person);
                }
            }
            return results;
        }

        static void Print(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}, Email: {person.Email}");
            }
        }

        private static void MemoryGames(List<Person> people)
        {
            //3
            var myPerson = people[0];// new Person { Id = 1, Name = "Alice", Age = 30, Email = "alice@example.com" };
            people.Remove(myPerson);


            if (myPerson == people[0])
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not Equal");
            }

            people.Remove(myPerson);



            people.Add(new Person
            {
                Id = 4,
                Name = "David",
                Age = 28,
                Email = "david@example.com"
            });

            people.RemoveAt(0);
            //List<string> names = new List<string>();
            //names.Add("asdsad");
            //names.Add("Shimon");

            List<int> numbers = new List<int>();
            numbers.Add(100);
            numbers.Add(200);
            numbers.Remove(100);
            numbers.RemoveAt(0);

        }

        private static void ConsoleTest()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Hello, World!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hello, World!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hello, World!");


            Random r = new Random();
            r.Next(0, 600);
        }
    }
}
