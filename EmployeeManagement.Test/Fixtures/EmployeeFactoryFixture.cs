using EmployeeManagement.Business;

namespace EmployeeManagement.Test.Fixtures
{
    public class EmployeeFactoryFixture : IDisposable
    {
        public readonly EmployeeFactory _factory;

        public EmployeeFactoryFixture()
        {
            _factory = new EmployeeFactory();
        }
        public void Dispose() { }
    }
}
