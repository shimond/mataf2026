using EmployeeApp.Contracts;
using EmployeeApp.Dto;
using EmployeeApp.Dtos;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;

namespace EmployeeApp.Endpoints
{
    public class EmployeeEndPoints
    {
        public static void MapEmployees(WebApplication app)
        {
            var employeeGroup = app.MapGroup("employees").WithTags("EmployeesRoutes");

            employeeGroup.MapGet("search/{term}", SearchEmployee);
            employeeGroup.MapGet("{id}", GetEmployeeById);
            employeeGroup.MapDelete("{id}", DeleteEmployee);
            //employees -> 1477 (function addess in memory)
            employeeGroup.MapPost("", AddNewEmployee);
            employeeGroup.MapGet("", GetAll).CacheOutput();
        }
        static async Task<Ok<List<EmployeeDto>>> GetAll(IEmployeesRepository employeesRepository, IOutputCacheStore c)
        {
            var result = await employeesRepository.GetAllEmployees();

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
            return TypedResults.Ok(list);
        }
        static async Task<Ok> DeleteEmployee(int id, IEmployeesRepository employeesRepository)
        {
            await employeesRepository.DeleteEmployee(id);
            return TypedResults.Ok();
        }
        static async Task<Ok<List<Employee>>> SearchEmployee(string term, IEmployeesRepository employeesRepository)
        {
            var res = await employeesRepository.Search(term);
            return TypedResults.Ok(res);
        }
        static async Task<Results<NotFound<string>, Ok<Employee>>> GetEmployeeById(int id, IEmployeesRepository employeesRepository)
        {
            var result = await employeesRepository.GetEmpolyeeById(id);
            if (result is not null)
            {
                return TypedResults.Ok(result); // status code 200
            }
            return TypedResults.NotFound("Employee with id " + id + " not found"); // status code 404
        }
        static async Task<Created<Employee>> AddNewEmployee(CreateEmployeeRequestDto request, IEmployeesRepository employeesRepository)
        {
            var employee = new EmployeeApp.Models.Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthdate = request.Birthdate,
                Salary = request.Salary,
                Email = request.Email
            };
            var result = await employeesRepository.AddNewEmployee(employee);
            return TypedResults.Created("employees/" + result.Id, result); // sucess - 201
        }
    }
}

// Real implemenation
// Middleware
// BFF

//async method Task, Task<>, ValueTask, ValueTask<>


// Configuartion
// Validation
// Task - Async/Await
// Mapping
// AI






