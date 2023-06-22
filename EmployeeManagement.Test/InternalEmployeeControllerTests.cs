using EmployeeManagement.Business;
using EmployeeManagement.Controllers;
using EmployeeManagement.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagement.Test
{
    public class InternalEmployeeControllerTests
    {
        [Fact]
        public async Task GetInternalEmployees_GetAction_MustReturnOkObjectResult()
        {
            //Arrange
            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(m => m.FetchInternalEmployeesAsync())
                .ReturnsAsync(new List<InternalEmployee>() {
                    new InternalEmployee("Mega", "Jones", 2, 3000, false, 2)
                    });
            var internalEmloyeesController = new InternalEmployeesController(employeeServiceMock.Object, null);
            
            //Act
            var result = await internalEmloyeesController.GetInternalEmployees();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
