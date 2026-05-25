namespace EmployeeApp.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public double Age { get; set; }
        public double Salary { get; set; }
        public required string Email { get; set; }

    }
}
