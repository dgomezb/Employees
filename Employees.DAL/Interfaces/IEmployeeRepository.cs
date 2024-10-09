using Employees.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeModel>> GetEmployeesAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
    }
}
