using EmployeeManagement.DataAccess.Services;
using System.Text;
using System.Text.Json;

namespace EmployeeManagement.Test.HttpMessageHandlers
{
    public class PromotionServiceHttpMessageHandler : HttpMessageHandler
    {
        public PromotionServiceHttpMessageHandler(EmployeeManagementRepository employeeManagementRepository) {
            _employeeManagementRepository = employeeManagementRepository;
        }

        private readonly EmployeeManagementRepository _employeeManagementRepository;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(request.Content,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    }),
                Encoding.ASCII,
                "application/json")
            };
            return Task.FromResult(response);
        }
    }
}
