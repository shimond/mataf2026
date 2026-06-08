using EmployeeApp.Contracts;
using EmployeeApp.Endpoints;
using EmployeeApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();


builder.Services.AddScoped<IEmployeesRepository, InMemoryEmployeeRepository>();
//builder.Services.AddSingleton<IEmployeesRepository, InMemoryEmployeeRepository>();
//builder.Services.AddTransient<IEmployeesRepository, InMemoryEmployeeRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


//asmx - wsdl -  web service description language

// Add OpenAPI support
builder.Services.AddOpenApi();

// Add Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();

// Enable OpenAPI endpoint
app.MapOpenApi();

// Enable Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAngularClient");

EmployeeEndPoints.MapEmployees(app); // change to extension method

app.Run();

