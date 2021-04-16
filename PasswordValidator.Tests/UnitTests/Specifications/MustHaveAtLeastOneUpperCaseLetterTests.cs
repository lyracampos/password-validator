using PasswordValidator.Domain.Specifications;
using Xunit;

namespace PasswordValidator.Tests.UnitTests.Specifications
{
    public class MustHaveAtLeastOneUpperCaseLetterTests
    {
        [Fact]
        public void ShouldReturnTrue_WhenPassword_IsValid()
        {
            var password = "senhA";
            var isValid = new MustHaveAtLeastOneUpperCaseLetter(password).IsValid;
            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnFalse_WhenPassword_IsInvalid()
        {
            var password = "senha";
            var isValid = new MustHaveAtLeastOneUpperCaseLetter(password).IsValid;
            Assert.False(isValid);
        }
    }
}
