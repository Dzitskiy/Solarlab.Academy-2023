using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Board.Contracts.Advert;
using Board.Domain.Adverts;
using Newtonsoft.Json;
using Xunit;

namespace Board.Api.Tests
{
    public class AdvertTests : IClassFixture<BoardWebApplicationFactory>
    {
        public AdvertTests(BoardWebApplicationFactory webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
        }

        private readonly BoardWebApplicationFactory _webApplicationFactory;

        [Fact]
        public async Task Advert_GetById_Success()
        {
            // Arrange
            var httpClient = _webApplicationFactory.CreateClient();
            var id = DataSeedHelper.TestAdvertId;

            // Act
            var response = await httpClient.GetAsync($"Advert/{id}");

            // Assert
            
            Assert.NotNull(response);

            var result = await response.Content.ReadFromJsonAsync<AdvertInfoDto>();

            Assert.NotNull(result);

            Assert.Equal("test_advert_name", result!.Name);
            Assert.Equal("test_desc", result.Description);
            Assert.Equal("new_prostokvashino", result.Address);
            Assert.True(result.IsActive);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Advert_Add_Success()
        {
            // Arrange
            var httpClient = _webApplicationFactory.CreateClient();

            CreateAdvertDto model = new CreateAdvertDto
            {
                Name = "test_name",
                Description = "test_description",
                CategoryId = DataSeedHelper.TestCategoryId,
                Address = "some_city"
            };


            // Act
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("Advert", content);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            // полчить из ответа id созданной сущности
            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            var id = json.GetProperty("id").GetString();

            // получить созданную сущность из тестовой БД
            await using var dbContext = _webApplicationFactory.CreateDbContext();
            var advert = dbContext.Find<Advert>(Guid.Parse(id!));
            
            Assert.NotNull(advert);

            Assert.Equal(model.Name, advert!.Name);
            Assert.Equal(model.Description, advert.Description);
            Assert.Equal(model.Address, advert.Address);
            Assert.True(advert.IsActive);
        }
    }
}