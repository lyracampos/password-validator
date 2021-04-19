using Xunit;
using PasswordValidator.Api.Models;

namespace PasswordValidator.Tests.UnitTests.Models
{
    public class PasswordTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public void ShouldReturnsFalse_WhenPassword_IsInvalid(string password)
        {
            var isValid = new Password(password).IsValid;
            Assert.False(isValid);
        }

        [Fact]
        public void ShouldReturnsTrue_WhenPassword_IsValid()
        {
            var password = "AbTp9!fok";
            var isValid = new Password(password).IsValid;
            Assert.True(isValid);
        }
    }
}