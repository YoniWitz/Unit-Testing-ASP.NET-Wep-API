using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameIsConcatenation()
        {
            //Arrange
            var employee = new InternalEmployee("yoni", "witz", 0, 2500, false, 1);

            //Act
            //employee.FirstName = "Lucia";  
            //employee.LastName = "Shelton";

            //Assert
            Assert.Equal("yoni witz", employee.FullName);
        }
    }
}
