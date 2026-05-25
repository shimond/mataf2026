using EmployeeApp.Contracts;
using EmployeeApp.Dto;
using EmployeeApp.Dtos;
using EmployeeApp.Endpoints;
using EmployeeApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IEmployeesRepository, InMemoryEmployeeRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors("AllowAngularClient");

EmployeeEndPoints.MapEmployees(app); // change to extension method

app.Run();

