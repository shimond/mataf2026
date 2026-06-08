using EmployeeApp.Contracts;
using EmployeeApp.Dto;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")] // /api/employees
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }

        [HttpGet("{id}")] //api/employees/3
        public Results<NotFound<string>, Ok<Employee>> GetEmployeeById(int id)
        {
            var result = employeesRepository.GetEmpolyeeById(id);
            if (result is not null)
            {
                return TypedResults.Ok(result); // status code 200
            }
            return TypedResults.NotFound("Employee with id " + id + " not found"); // status code 404
        }

        [HttpGet()]
        public Ok<List<EmployeeDto>> GetAll()
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
            return TypedResults.Ok(list);
        }
    }
}
