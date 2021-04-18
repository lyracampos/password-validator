using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using PasswordValidator.Api;
using PasswordValidator.Api.Models;
using PasswordValidator.Domain.Entities;
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
        public async Task ShouldReturnsTrue_WhenPassword_Isvalid()
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
        
        [Fact]
        public async Task ShouldReturnsTrue_WhenPassword_Isinvalid()
        {
            // arrange
            var content = SetContent("123123123");
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
