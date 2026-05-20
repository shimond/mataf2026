namespace WorkersApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWorkerable[] workers = [
                    new SalariedEmployee() { Id = 1, Age = 33, FirstName = "John", LastName = "Smith", MonthlySalary = 3000 },
                    new Manager() { Id = 2, Age = 40, FirstName = "Jane", LastName = "Doe", MonthlySalary = 5000, Bonus = 1000 },
                    new Freelancer() { Id = 3, Age = 28, FirstName = "Alice", LastName = "Johnson", HourlyRate = 50, HoursWorked = 160 },
                    new WorkerStudent() { Id = 4, Age = 22, FirstName = "Bob", LastName = "Brown", PricePerDay = 100, Days = 20 }
                ];

            var avgSalary = GetAvgSalary(workers);
            Console.WriteLine($"Average Salary: {avgSalary}");

        }

        static double GetAvgSalary(IWorkerable[] workers)
        {
            double totalSalary = 0;
            foreach (var item in workers)
            {
                totalSalary += item.GetCalculatedSalary();
            }
            return totalSalary / workers.Length;
        }
    }
}
