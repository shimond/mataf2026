using EmployeeApp.Contracts;
using EmployeeApp.Dto;
using EmployeeApp.Dtos;

namespace EmployeeApp.Endpoints
{
    public class EmployeeEndPoints
    {
        public static void MapEmployees(WebApplication app)
        {
            var employeeGroup = app.MapGroup("employees");

            employeeGroup.MapGet("search/{term}", (string term, IEmployeesRepository employeesRepository) => {

                var res = employeesRepository.Search(term);
                return res;
            });

            employeeGroup.MapDelete("{id}", (int id, IEmployeesRepository employeesRepository) => {

                employeesRepository.DeleteEmployee(id);
                return Results.Ok();
            });

            employeeGroup.MapGet("{id}", (int id, IEmployeesRepository employeesRepository) => {

                var result = employeesRepository.GetEmpolyeeById(id);
                if (result is not null)
                {
                    return Results.Ok(result);
                }
                return Results.NotFound();
            });

            employeeGroup.MapPost("", (CreateEmployeeRequestDto request, IEmployeesRepository employeesRepository) =>
            {
                var employee = new EmployeeApp.Models.Employee()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Birthdate = request.Birthdate,
                    Salary = request.Salary,
                    Email = request.Email
                };
                var result = employeesRepository.AddNewEmployee(employee);
                return result;
            });

            employeeGroup.MapGet("", (IEmployeesRepository employeesRepository) =>
            {
                var result = employeesRepository.GetAllEmployees();
                List<EmployeeDto> list = new List<EmployeeDto>();
                foreach (var emp in result)
                {
                    var empDto = new EmployeeDto()
                    {
                        Email = emp.Email,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        Id = emp.Id,
                        Salary = emp.Salary,
                        Age = DateTime.Today.Year - emp.Birthdate.Year

                    };
                    list.Add(empDto);
                }
                return list;
            });

        }
    }
}

// Configuartion
// Validation
// Task - Async/Await
// Mapping
// Real implemenation
// Middleware
// BFF
// AI






