using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

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
    }
}
