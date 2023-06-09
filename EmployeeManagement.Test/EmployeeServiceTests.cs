using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Test;
using EmployeeManagement.Test.Fixtures;

namespace EmployeeManagement.Test
{
    public class EmployeeServiceTests :IClassFixture<EmployeeServiceTestsDIFixture>
    {
        private readonly EmployeeServiceTestsDIFixture _fixture;

        public EmployeeServiceTests(EmployeeServiceTestsDIFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse()
        {
            //Arrange
            List<Course> obligatoryCourses = _fixture.EmployeeService.GetObligatoryCourses();

            //Act
            InternalEmployee internalEmployee = _fixture.EmployeeService.CreateInternalEmployee("yoni", "witz");

            //Assert
            Assert.NotNull(internalEmployee);
            Assert.Contains(obligatoryCourses[0], internalEmployee.AttendedCourses);
        }
    }
}
