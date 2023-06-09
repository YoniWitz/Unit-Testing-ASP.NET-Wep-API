using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeServiceRepoCollection")]
    public class EmployeeFactoryTests : IClassFixture<EmployeeFactoryFixture>
    {
        private readonly EmployeeFactoryFixture _employeeFactoryFixture;
        private readonly EmployeeServiceRepoFixture _employeeServiceRepoFixture;

        public EmployeeFactoryTests(EmployeeFactoryFixture employeeFactoryFixture, EmployeeServiceRepoFixture employeeServiceRepoFixture)
        {
            _employeeFactoryFixture = employeeFactoryFixture;
            _employeeServiceRepoFixture = employeeServiceRepoFixture;
        }

        [Fact]
        public void CreateEmployee_CosntructInternalEmployee_SalaryMustBe2500()
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
            var internalEmployee = (InternalEmployee)_employeeFactoryFixture._factory.CreateEmployee("Yoni", "Dockx");

            //Act + assert
            await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(async () => await _employeeServiceRepoFixture.employeeService.GiveRaiseAsync(internalEmployee, 50));
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
