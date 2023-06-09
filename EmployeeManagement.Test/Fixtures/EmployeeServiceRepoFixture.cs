using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.DbContexts;
using EmployeeManagement.DataAccess.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Test.Fixtures
{
    public class EmployeeServiceRepoFixture : IDisposable
    {
        public readonly EmployeeService employeeService;
        public readonly EmployeeManagementRepository employeeManagementRepository;
        public EmployeeServiceRepoFixture()
        {
            var connection = new SqliteConnection("Data source=:memory:");
            connection.Open();
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeDbContext>().UseSqlite(connection);
            var dbContext = new EmployeeDbContext(optionsBuilder.Options);
            dbContext.Database.Migrate();
            employeeManagementRepository = new(dbContext);
            employeeService = new(employeeManagementRepository, new EmployeeFactory());
        }
        public void Dispose() { }
    }
}
