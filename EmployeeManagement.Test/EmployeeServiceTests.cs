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
            EmployeeManagementTestDataRepository employeeManagementTestDataRepository = new();
            EmployeeFactory employeeFactory = new EmployeeFactory();
            EmployeeService employeeService = new EmployeeService(employeeManagementTestDataRepository, employeeFactory);
            List<Course> obligatoryCourses = employeeService.GetObligatoryCourses();

            //Act
            InternalEmployee internalEmployee = employeeService.CreateInternalEmployee("yoni", "witz");

            //Assert
            Assert.NotNull(internalEmployee);
            Assert.Contains(obligatoryCourses[0], internalEmployee.AttendedCourses);
        }
    }
}
