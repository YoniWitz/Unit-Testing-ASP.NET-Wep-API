using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class CourseTests
    {
        [Fact]
        public void CourseConstructor_IsNewMustBeTrue() {
            //Act
            var course = new Course("Distater Management");

            //Assert 
            Assert.True(course.IsNew);
        }
    }
}
