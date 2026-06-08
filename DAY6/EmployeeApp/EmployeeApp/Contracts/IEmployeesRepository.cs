using EmployeeApp.Models;

namespace EmployeeApp.Contracts
{
    public interface IEmployeesRepository
    {
        Task<List<Employee>> Search(string name);
        Task<Employee> AddNewEmployee(Employee employee);
        Task<Employee?> GetEmpolyeeById(int id);
        Task<List<Employee>> GetAllEmployees(); //  List<Employee> - > Task<List<Employee>> 
        Task<Employee> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}

// await Task, ValueTask, Task<>, ValueTask<>