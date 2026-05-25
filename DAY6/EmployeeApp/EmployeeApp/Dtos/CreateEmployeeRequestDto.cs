namespace EmployeeApp.Dtos
{
    public class CreateEmployeeRequestDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public double Salary { get; set; }
        public required string Email { get; set; }
    }
}
