using PasswordValidator.Domain.Specifications;
using Xunit;

namespace PasswordValidator.Tests.UnitTests.Specifications
{
    public class ShouldBeGreaterThanNineCharsTests
    {
        [Fact]
        public void ShouldReturnTrue_WhenPassword_IsValid()
        {
            var password = "123456789";
            var isValid = new ShouldBeGreaterThanNineChars(password).IsValid;
            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnFalse_WhenPassword_IsInvalid()
        {
            var password = "12345678";
            var isValid = new ShouldBeGreaterThanNineChars(password).IsValid;
            Assert.False(isValid);
        }
    }
}
