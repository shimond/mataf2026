namespace OOP_BASICS
{

    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }


    public class Person
    {
        private string _firstName;
        private string _lastName;
        public string Name
        {
            get {  return _firstName + " " + _lastName; }
            set
            {
                var names = value.Split(' ');
                _firstName = names[0];
                _lastName = names[1];
            }
        }

        public string Email { get; set; }
        public int Age { get; set; }
        public string Tz { get; set; }
       

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Tz: {Tz}");
        }
    }
}

