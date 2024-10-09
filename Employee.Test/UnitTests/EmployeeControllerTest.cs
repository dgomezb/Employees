using Employees.API.Controllers;
using Employees.BLL;
using Employees.BLL.Interfaces;
using Employees.DAL.Entities;
using Employees.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Employees.Test.UnitTests
{
    [TestClass]
    public class EmployeeControllerTest
    {

        private Mock<IEmployeeService> mockEmployeeService;
        private Mock<IEmployeeRepository> mockEmployeeRepository;

        private EmployeeController employeeController;
        private EmployeeService employeeServiceBLL;

        private List<EmployeeModel> employeesList;
        private EmployeeModel employee;

        [TestInitialize]
        public void Setup()
        {
            // The service mock is initialized
            mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeRepository = new Mock<IEmployeeRepository>();

            // The mock is passed to the controller
            employeeController = new EmployeeController(mockEmployeeService.Object);
            employeeServiceBLL = new EmployeeService(mockEmployeeRepository.Object);
        }
        

        [TestMethod]
        public async Task GetEmployees_ReturnsOk_WithEmployeeList()
        {
            // Arrange: Configure the mock to return a mock list of employees
            CreateEmployeesDataList();

            mockEmployeeService
                .Setup(service => service.GetEmployeesAsync())
                .ReturnsAsync(employeesList);

            // Act: Calls the controller's Get() method
            var result = await employeeController.Get();

            // Assert: Verify that the result is 200 OK with the expected list
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var returnedEmployees = okResult.Value as List<EmployeeModel>;
            Assert.IsNotNull(returnedEmployees);
            Assert.AreEqual(3, returnedEmployees.Count);
        }

        [TestMethod]
        public async Task GetEmployeeByIdAsync_CalculatesAnualSalaryCorrectly()
        {
            // Arrange: The mock is configured so that GetEmployeeByIdAsync returns this employee
            CreateEmployeeData();
            //var expectedAnualSalary = employee.Salary * 12;

            mockEmployeeRepository
                .Setup(repo => repo.GetEmployeeByIdAsync(employee.Id))
                .ReturnsAsync(employee);

            // Act: Calls the service method
            var result = await employeeServiceBLL.GetEmployeeByIdAsync(employee.Id);
            var expectedAnualSalary = result.Salary  * 12;

            // Assert: We verify that the AnnualSalary is as expected
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedAnualSalary, result.AnualSalary);
        }

        private void CreateEmployeesDataList() {
            employeesList = new List<EmployeeModel>
            {
                new EmployeeModel() { Id = 10, Name = "Matthew Berg", Gender = "male" },
                new EmployeeModel() { Id = 20, Name = "Jane Smith", Gender = "female" },
                new EmployeeModel() { Id = 30, Name = "Francisca Lloyd", Gender = "female" }
            };
        }

        private void CreateEmployeeData()
        {
            var employeeId = 10;
            var employeeName = "Matthew Berg";
            var employeeGender = "male";
            employee = new EmployeeModel() { Id = employeeId, Name = employeeName, Gender = employeeGender };
        }
    }
}
