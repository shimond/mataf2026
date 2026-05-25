using EmployeeApp.Contracts;
using EmployeeApp.Models;

namespace EmployeeApp.Services
{
    public class InMemoryEmployeeRepository : IEmployeesRepository
    {

        private static List<Employee> _employees = new List<Employee>();

        static InMemoryEmployeeRepository()
        {
            _employees.Add(new Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Birthdate = new DateTime(1990, 5, 15), Salary = 75000, Password = "pass123" });
            _employees.Add(new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Birthdate = new DateTime(1988, 8, 22), Salary = 85000, Password = "pass123" });
            _employees.Add(new Employee { Id = 3, FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", Birthdate = new DateTime(1992, 3, 10), Salary = 70000, Password = "pass123" });
            _employees.Add(new Employee { Id = 4, FirstName = "Sarah", LastName = "Williams", Email = "sarah.williams@example.com", Birthdate = new DateTime(1989, 11, 5), Salary = 80000, Password = "pass123" });
            _employees.Add(new Employee { Id = 5, FirstName = "David", LastName = "Brown", Email = "david.brown@example.com", Birthdate = new DateTime(1991, 2, 28), Salary = 72000, Password = "pass123" });
            _employees.Add(new Employee { Id = 6, FirstName = "Emma", LastName = "Davis", Email = "emma.davis@example.com", Birthdate = new DateTime(1993, 7, 12), Salary = 68000, Password = "pass123" });
            _employees.Add(new Employee { Id = 7, FirstName = "Robert", LastName = "Miller", Email = "robert.miller@example.com", Birthdate = new DateTime(1987, 9, 18), Salary = 90000, Password = "pass123" });
            _employees.Add(new Employee { Id = 8, FirstName = "Lisa", LastName = "Wilson", Email = "lisa.wilson@example.com", Birthdate = new DateTime(1990, 4, 30), Salary = 77000, Password = "pass123" });
            _employees.Add(new Employee { Id = 9, FirstName = "James", LastName = "Moore", Email = "james.moore@example.com", Birthdate = new DateTime(1989, 6, 14), Salary = 82000, Password = "pass123" });
            _employees.Add(new Employee { Id = 10, FirstName = "Patricia", LastName = "Taylor", Email = "patricia.taylor@example.com", Birthdate = new DateTime(1991, 12, 8), Salary = 79000, Password = "pass123" });
        }
        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee AddNewEmployee(Employee employee)
        {
            employee.Password = "pass123";
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(int id)
        {
            var item = GetEmpolyeeById(id);
            if (item != null)
            {
                _employees.Remove(item);
            }
        }

        public Employee? GetEmpolyeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Search(string name)
        {
            var nameLower = name.ToLower();
            var result = _employees.Where(x => $"{x.FirstName}{x.LastName}{x.Email}".ToLower().Contains(nameLower)).ToList();
            return result;
        }
    }
}
