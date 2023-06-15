using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.DbContexts;
using EmployeeManagement.DataAccess.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Test.Fixtures
{
    public class EmployeeServiceRepoFixture : IDisposable
    {
        public readonly EmployeeService EmployeeService;
        public readonly EmployeeManagementRepository EmployeeManagementRepository;
        public EmployeeServiceRepoFixture()
        {
            var connection = new SqliteConnection("Data source=:memory:");
            connection.Open();
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeDbContext>().UseSqlite(connection);
            var dbContext = new EmployeeDbContext(optionsBuilder.Options);
            dbContext.Database.Migrate();
            EmployeeManagementRepository = new(dbContext);
            EmployeeService = new(EmployeeManagementRepository, new EmployeeFactory());
        }
        public void Dispose() { }
    }
}
