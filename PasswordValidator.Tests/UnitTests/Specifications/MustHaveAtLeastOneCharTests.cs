using PasswordValidator.Domain.Specifications;
using Xunit;

namespace PasswordValidator.Tests.UnitTests.Specifications
{
    public class MustHaveAtLeastOneCharTests
    {
        [Fact]
        public void ShouldReturnTrue_WhenPassword_IsValid()
        {
            var password = "1";
            var isValid = new MustHaveAtLeastOneChar(password).IsValid;
            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnFalse_WhenPassword_IsInvalid()
        {
            var password = "";
            var isValid = new MustHaveAtLeastOneChar(password).IsValid;
            Assert.False(isValid);
        }
    }
}
