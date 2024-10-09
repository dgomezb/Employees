namespace Employees.DAL.Entities
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Status { get; set; }
        public double Salary { get; set; }
        public double AnualSalary { get; set; }
    }
}
