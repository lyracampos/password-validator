using Xunit;
using PasswordValidator.Domain.Specifications;

namespace PasswordValidator.Tests.UnitTests.Specifications
{
    public class MustHaveAtLeastOneSpecialCharTests
    {
        [Fact]
        public void ShouldReturnTrue_WhenPassword_IsValid()
        {
            var password = "Senh@";
            var isValid = new MustHaveAtLeastOneSpecialChar(password).IsValid;
            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnFalse_WhenPassword_IsInvalid()
        {
            var password = "S?nha";
            var isValid = new MustHaveAtLeastOneSpecialChar(password).IsValid;
            Assert.False(isValid);
        }
    }
}
