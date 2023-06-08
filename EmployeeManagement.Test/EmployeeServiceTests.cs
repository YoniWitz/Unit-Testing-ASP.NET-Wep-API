using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Test;

namespace EmployeeManagement.Test
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse()
        {
            //Arrange
            EmployeeService employeeService = new (new EmployeeManagementTestDataRepository(), new EmployeeFactory());
            List<Course> obligatoryCourses = employeeService.GetObligatoryCourses();

            //Act
            InternalEmployee internalEmployee = employeeService.CreateInternalEmployee("yoni", "witz");

            //Assert
            Assert.NotNull(internalEmployee);
            Assert.Contains(obligatoryCourses[0], internalEmployee.AttendedCourses);
        }
    }
}
