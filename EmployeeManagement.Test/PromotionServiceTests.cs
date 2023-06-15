using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
using EmployeeManagement.Test.HttpMessageHandlers;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeServiceRepoCollection")]
    public class PromotionServiceTests 
    {
        private readonly EmployeeServiceRepoFixture _fixture;

        public PromotionServiceTests(EmployeeServiceRepoFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ReturnIfEmployeeIsEligibleForPromotion()
        {
            //Arrange
            var httpClient = new HttpClient(new PromotionServiceHttpMessageHandler(_fixture.EmployeeManagementRepository));

            var promotionService = new PromotionService(httpClient, _fixture.EmployeeManagementRepository);

            InternalEmployee internalEmployee = new ("Brooklyn", "Cannon", 5, 3000, false, 1);

            //Act
            bool eligible = await promotionService.PromoteInternalEmployeeAsync(internalEmployee);

            Assert.True(eligible);
        }
    }
}
