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
        private readonly WebApplicationFactory<Startup> factory = new WebApplicationFactory<Startup>();

        [Fact]
        public async Task ShouldReturnsTrue_WhenPassword_Isvalid()
        {
            // arrange
            var password = new Password("AbTp9!fok");
            var content = new StringContent(JsonConvert.SerializeObject(password), Encoding.UTF8, "application/json");
            var client = factory.CreateClient();
            var response = await client.PostAsync("/api/passwordvalidator", content);

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
            var password = new Password("123123");
            var content = new StringContent(JsonConvert.SerializeObject(password), Encoding.UTF8, "application/json");
            var client = factory.CreateClient();
            var response = await client.PostAsync("/api/passwordvalidator", content);

            // act
            var result = JsonConvert.DeserializeObject<PasswordResult>(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // assert
            Assert.IsType<PasswordResult>(result);
            Assert.False(result.IsValid);
        }
    }
}
