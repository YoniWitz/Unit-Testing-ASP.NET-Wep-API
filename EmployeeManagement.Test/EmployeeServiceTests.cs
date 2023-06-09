﻿using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
using Xunit.Sdk;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeServiceRepoCollection")]
    public class EmployeeServiceTests
    {
        private readonly EmployeeServiceRepoFixture _employeeServiceRepoFixture;

        public EmployeeServiceTests(EmployeeServiceRepoFixture fixture)
        {
            _employeeServiceRepoFixture = fixture;
        }

        [Fact]
        public void InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse()
        {
            //Arrange
            List<Course> obligatoryCourses = _employeeServiceRepoFixture.EmployeeService.GetObligatoryCourses();

            //Act
            InternalEmployee internalEmployee = _employeeServiceRepoFixture.EmployeeService.CreateInternalEmployee("yoni", "witz");

            //Assert
            Assert.NotNull(internalEmployee);
            Assert.Contains(obligatoryCourses[0], internalEmployee.AttendedCourses);
        }

        [Fact]
        public async Task SuggestedBonusMustUpdate_WhenCourseAttended()
        {
            //Arrange
            var internalEmployee = await _employeeServiceRepoFixture.EmployeeManagementRepository.GetInternalEmployeeAsync(Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"));

            var courseToAttend = await _employeeServiceRepoFixture.EmployeeManagementRepository.GetCourseAsync(Guid.Parse("d6e0e4b7-9365-4332-9b29-bb7bf09664a6"));

            if (courseToAttend == null || internalEmployee == null) throw new XunitException("call to db failed");

            var expectedSuggestedBonus = internalEmployee.YearsInService
                * (internalEmployee.AttendedCourses.Count + 1) * 100;

            //Act
            await _employeeServiceRepoFixture.EmployeeService.AttendCourseAsync(internalEmployee, courseToAttend);

            //Assert
            Assert.Equal(internalEmployee.SuggestedBonus, expectedSuggestedBonus);
        }
    }
}
