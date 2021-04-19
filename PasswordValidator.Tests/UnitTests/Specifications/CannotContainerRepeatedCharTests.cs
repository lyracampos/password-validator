using PasswordValidator.Api.Specifications;
using Xunit;

namespace PasswordValidator.Tests.UnitTests.Specifications
{
    public class CannotContainerRepeatedCharTests
    {
        [Fact]
        public void ShouldReturnTrue_WhenPassword_IsValid()
        {
            var password = "senha";
            var isValid = new CannotContainerRepeatedChar(password).IsValid;
            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnFalse_WhenPassword_IsInvalid()
        {
            var password = "senhas";
            var isValid = new CannotContainerRepeatedChar(password).IsValid;
            Assert.False(isValid);
        }
    }
}
