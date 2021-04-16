using PasswordValidator.Domain.Specifications;
using Xunit;

namespace PasswordValidator.Tests.UnitTests.Specifications
{
    public class MustHaveAtLeastOneLowercaseLetterTests
    {
        [Fact]
        public void ShouldReturnTrue_WhenPassword_IsValid()
        {
            var password = "SENHa";
            var isValid = new MustHaveAtLeastOneLowercaseLetter(password).IsValid;
            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnFalse_WhenPassword_IsInvalid()
        {
            var password = "SENHA";
            var isValid = new MustHaveAtLeastOneLowercaseLetter(password).IsValid;
            Assert.False(isValid);
        }
    }
}
