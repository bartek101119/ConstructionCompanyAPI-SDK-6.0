using constructionCompanyAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace constructionCompanyAPI.IntegrationTests
{
    public class ConstructionCompanyControllerTests
    {
        private HttpClient _client;

        public ConstructionCompanyControllerTests()
        {
            _client = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services
                        .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<ConstructionCompanyDbContext>));

                        services.Remove(dbContextOptions);

                        services.AddDbContext<ConstructionCompanyDbContext>(options => options.UseInMemoryDatabase("ConstructionCompanyDb"));
                    });
                })
                .CreateClient();
        }
        [Theory]
        [InlineData("?pageNumber=1&pageSize=10")]
        [InlineData("?pageNumber=1&pageSize=5")]
        public async Task GetAll_WithQueryParameters_ReturnsOkResult(string queryParams)
        {
            // act

            var response = await _client.GetAsync("/api/constructionCompany" + queryParams);

            // assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("?pageNumber=200&pageSize=500")]
        [InlineData(null)]
        [InlineData("")]
        public async Task GetAll_WithQueryParameters_ReturnsBadRequest(string queryParams)
        {

            // act

            var response = await _client.GetAsync("/api/constructionCompany" + queryParams);

            // assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
