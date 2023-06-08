using EmployeeManagement.Business;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Test;
using EmployeeManagement.Test.Fixtures;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeFactoryCollection")]
    public class EmployeeFactoryTests
    {
        private readonly EmployeeFactoryFixture _employeeFactoryFixture;

        public EmployeeFactoryTests(EmployeeFactoryFixture employeeFactoryFixture)
        {
            _employeeFactoryFixture = employeeFactoryFixture;
        }

        [Fact]
        public void CreateEmployee_CosntructInternalEmployy_SalaryMustBe2500()
        {
            //Arrange
            
            //Act
            var employee = (InternalEmployee)_employeeFactoryFixture._factory.CreateEmployee("Yoni", "Dockx");

            //Assert
            Assert.Equal(2500, employee.Salary);
        }

        [Fact]
        public async Task GiveRaiseAsync_ThrowsExceptionWhenRaiseBelowMinimum()
        {
            //Arrange
            EmployeeService employeeService = new (new EmployeeManagementTestDataRepository(), _employeeFactoryFixture._factory);
            var internalEmployee = (InternalEmployee)_employeeFactoryFixture._factory.CreateEmployee("Yoni", "Dockx");

            //Act + assert
            await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(async () => await employeeService.GiveRaiseAsync(internalEmployee, 50));
        }

        [Fact]
        public void EmployeeFactoryCreatesExternalEmployeeWhenIsExternalTrue()
        {
            //Act
            
            //Arrange
            var employee = _employeeFactoryFixture._factory.CreateEmployee("yoni", "witz", string.Empty, true);
            
            //Assert
            Assert.IsType<ExternalEmployee>(employee);
            Assert.IsAssignableFrom<Employee>(employee);
        }
    }
}
