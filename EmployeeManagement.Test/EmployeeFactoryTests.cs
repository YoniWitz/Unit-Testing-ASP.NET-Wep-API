using EmployeeManagement.Business;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Test;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTests
    {
        [Fact]
        public void CreateEmployee_CosntructInternalEmployy_SalaryMustBe2500()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();
            
            //Act
            var employee = (InternalEmployee) employeeFactory.CreateEmployee("Yoni", "Dockx");

            //Assert
            Assert.Equal(2500, employee.Salary);
        }

        [Fact]
        public async Task GiveRaiseAsync_ThrowsExceptionWhenRaiseBelowMinimum()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();
            var employeeService = new EmployeeService(new EmployeeManagementTestDataRepository(), new EmployeeFactory());
            var internalEmployee = (InternalEmployee)employeeFactory.CreateEmployee("Yoni", "Dockx");

            //Act
            await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(async () => await employeeService.GiveRaiseAsync(internalEmployee, 50));

        }
    }
}
