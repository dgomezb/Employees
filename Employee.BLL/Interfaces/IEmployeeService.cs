using Employees.DAL.Entities;

namespace Employees.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetEmployeesAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
    }
}
