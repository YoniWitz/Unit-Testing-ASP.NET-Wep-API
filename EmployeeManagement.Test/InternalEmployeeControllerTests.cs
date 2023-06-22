using AutoMapper;
using EmployeeManagement.Business;
using EmployeeManagement.Controllers;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.MapperProfiles;
using EmployeeManagement.Models;
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

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<EmployeeProfile>());
            var mapper = new Mapper(mapperConfiguration);
            var internalEmloyeesController = new InternalEmployeesController(employeeServiceMock.Object, mapper);
            
            //Act
            var result = await internalEmloyeesController.GetInternalEmployees();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<InternalEmployeeDto>>> (result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var dtos = Assert.IsAssignableFrom<IEnumerable<InternalEmployeeDto>>(okObjectResult.Value);
            var firstEmployee = dtos.First();
            Assert.Equal(new Guid("00000000-0000-0000-0000-000000000000"), firstEmployee.Id);
            Assert.Equal("Mega", firstEmployee.FirstName);
        }
    }
}
