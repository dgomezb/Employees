using Employees.DAL.Entities;
using Employees.DAL.Interfaces;
using System.Net.Http.Json;

namespace Employees.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient httpClient;
        private string url = "https://gorest.co.in/public/v2/users";

        public EmployeeRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"{url}/{id}");
                response.EnsureSuccessStatusCode();
                var employee = await response.Content.ReadFromJsonAsync<EmployeeModel>();
                return employee ?? new EmployeeModel();
            }
            catch (HttpRequestException)
            {
                return new EmployeeModel();
            }
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync()
        {            
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var employees = await response.Content.ReadFromJsonAsync<List<EmployeeModel>>();
                return employees ?? new List<EmployeeModel>();
            }
            catch (HttpRequestException)
            {
                return new List<EmployeeModel>();
            }
        }
    }
}
