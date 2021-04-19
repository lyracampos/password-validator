using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PasswordValidator.Api;
using PasswordValidator.Api.Models;
using Xunit;

namespace PasswordValidator.Tests.IntegrationTests.Controllers
{
    public class PasswordValidatorControllerTests
    {
        private readonly HttpClient httpClient;

        public PasswordValidatorControllerTests()
        {
            var factory = new WebApplicationFactory<Startup>(); ;
            httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task ShouldReturnsTrue_WhenPassword_IsValid()
        {
            // arrange
            var content = SetContent("AbTp9!fok");
            var response = await httpClient.PostAsync("/api/passwordvalidator", content);

            // act
            var result = JsonConvert.DeserializeObject<PasswordResult>(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // assert
            Assert.IsType<PasswordResult>(result);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public async Task ShouldReturnsTrue_WhenPassword_IsInvalid(string password)
        {
            // arrange
            var content = SetContent(password);
            var response = await httpClient.PostAsync("/api/passwordvalidator", content);

            // act
            var result = JsonConvert.DeserializeObject<PasswordResult>(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // assert
            Assert.IsType<PasswordResult>(result);
            Assert.False(result.IsValid);
        }

        private StringContent SetContent(string password)
        {
            var request = new PasswordRequest(password);
            return new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        }
    }
}
