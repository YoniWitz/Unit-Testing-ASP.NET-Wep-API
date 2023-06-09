using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Services.Test;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Test.Fixtures
{
    public class EmployeeServiceTestsDIFixture : IDisposable
    {
        private readonly ServiceProvider _serviceProvider;

        public EmployeeServiceTestsDIFixture()
        {
            var services = new ServiceCollection();
            services.AddScoped<EmployeeFactory>();
            services.AddScoped<IEmployeeManagementRepository, EmployeeManagementTestDataRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            _serviceProvider = services.BuildServiceProvider();
        }

#pragma warning disable CS8603 // Possible null reference return.
        public IEmployeeManagementRepository EmployeeManagementTestDataRepository { get => _serviceProvider.GetService<IEmployeeManagementRepository>(); }
#pragma warning restore CS8603 // Possible null reference return.

#pragma warning disable CS8603 // Possible null reference return.
        public IEmployeeService EmployeeService { get => _serviceProvider.GetService<IEmployeeService>(); }
#pragma warning restore CS8603 // Possible null reference return.

        public void Dispose() { }
    }
}
