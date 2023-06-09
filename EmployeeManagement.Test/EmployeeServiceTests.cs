using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
using Xunit.Sdk;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeServiceRepoCollection")]
    public class EmployeeServiceTests
    {
        private readonly EmployeeServiceRepoFixture _employeeServiceFixture;

        public EmployeeServiceTests(EmployeeServiceRepoFixture fixture)
        {
            _employeeServiceFixture = fixture;
        }

        [Fact]
        public void InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse()
        {
            //Arrange
            List<Course> obligatoryCourses = _employeeServiceFixture.employeeService.GetObligatoryCourses();

            //Act
            InternalEmployee internalEmployee = _employeeServiceFixture.employeeService.CreateInternalEmployee("yoni", "witz");

            //Assert
            Assert.NotNull(internalEmployee);
            Assert.Contains(obligatoryCourses[0], internalEmployee.AttendedCourses);
        }

        [Fact]
        public async Task SuggestedBonusMustUpdate_WhenCourseAttended()
        {
            //Arrange
            var internalEmployee = await _employeeServiceFixture.employeeManagementRepository.GetInternalEmployeeAsync(Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"));

            var courseToAttend = await _employeeServiceFixture.employeeManagementRepository.GetCourseAsync(Guid.Parse("d6e0e4b7-9365-4332-9b29-bb7bf09664a6"));

            if (courseToAttend == null || internalEmployee == null) throw new XunitException("call to db failed");

            var expectedSuggestedBonus = internalEmployee.YearsInService
                * (internalEmployee.AttendedCourses.Count + 1) * 100;

            //Act
            await _employeeServiceFixture.employeeService.AttendCourseAsync(internalEmployee, courseToAttend);

            //Assert
            Assert.Equal(internalEmployee.SuggestedBonus, expectedSuggestedBonus);


        }
    }
}
