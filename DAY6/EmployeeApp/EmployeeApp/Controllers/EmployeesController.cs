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
            //this.employeesRepository.GetAllEmployees().Wait();
            var all = this.employeesRepository.GetAllEmployees().Result;
        }

        [HttpGet("{id}")] //api/employees/3
        public async Task<Results<NotFound<string>, Ok<Employee>>> GetEmployeeById(int id)
        {
            //פקיד מחכה לסוף פעולה
            //employeesRepository.GetEmpolyeeById(id).Wait();

            //פקיד משוחרר לעשות מה שבא לו שהפעולה תסתיים הוא או פקיד אחד ימשיך את הפעולה
            //await employeesRepository.GetEmpolyeeById(id);

            // Task is promise in js/ts

            var result = await employeesRepository.GetEmpolyeeById(id);
            if (result is not null)
            {
                return TypedResults.Ok(result); // status code 200
            }
            return TypedResults.NotFound("Employee with id " + id + " not found"); // status code 404
        }

        [HttpGet()]
        public async Task<Ok<List<EmployeeDto>>> GetAll()
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
    }
}
