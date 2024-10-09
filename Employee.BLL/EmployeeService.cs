using Employees.BLL.Interfaces;
using Employees.DAL.Entities;
using Employees.DAL.Interfaces;

namespace Employees.BLL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(id);
            CalculateAnualSalary(employee);
            return employee;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync()
        {
            var employees = await employeeRepository.GetEmployeesAsync();
            foreach (var employee in employees)
            {
                CalculateAnualSalary(employee);
            }

            return employees;
        }
        
        private void CalculateAnualSalary(EmployeeModel employee)
        {
            //A random salary is assigned since the current API does not provide one
            employee.Salary = Random.Shared.Next(1000, 10000);

            employee.AnualSalary = employee.Salary * 12;
        }

    }
}
