using EmployeeApp.Models;

namespace EmployeeApp.Contracts
{
    public interface IEmployeesRepository
    {
        List<Employee> Search(string name);
        Employee AddNewEmployee(Employee employee);
        Employee? GetEmpolyeeById(int id);
        List<Employee> GetAllEmployees();
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
