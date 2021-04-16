using Xunit;
using PasswordValidator.Domain.Entities;

namespace PasswordValidator.Tests.UnitTests.Entities
{
    public class PasswordTests
    {
        // 1. IsValid("") // false  
        // 2. IsValid("aa") // false  
        // 3. IsValid("ab") // false  
        // 4. IsValid("AAAbbbCc") // false  
        // 5. IsValid("AbTp9!foo") // false  
        // 6. IsValid("AbTp9!foA") // false
        // 7. IsValid("AbTp9 fok") // false
        // 8. IsValid("AbTp9!fok") // true
        [Fact]
        public void ShouldReturnsFalse_WhenPassword_Isinvalid1()
        {
            var password = "";
            var isValid = new Password(password).IsValid;
            Assert.False(isValid);
        }

        [Fact]
        public void ShouldReturnsFalse_WhenPassword_Isinvalid2()
        {
            var password = "aa";
            var isValid = new Password(password).IsValid;
            Assert.False(isValid);
        }

        [Fact]
        public void ShouldReturnsFalse_WhenPassword_Isinvalid3()
        {
            var password = "ab";
            var isValid = new Password(password).IsValid;
            Assert.False(isValid);
        }

        [Fact]
        public void ShouldReturnsFalse_WhenPassword_Isinvalid4()
        {
            var password = "AAAbbbCc";
            var isValid = new Password(password).IsValid;
            Assert.False(isValid);
        }

        [Fact]
        public void ShouldReturnsFalse_WhenPassword_Isinvalid5()
        {
            var password = "AbTp9!foo";
            var isValid = new Password(password).IsValid;
            Assert.False(isValid);
        }

        [Fact]
        public void ShouldReturnsFalse_WhenPassword_Isinvalid6()
        {
            var password = "AbTp9!foA";
            var isValid = new Password(password).IsValid;
            Assert.False(isValid);
        }

        [Fact]
        public void ShouldReturnsFalse_WhenPassword_Isinvalid7()
        {
            var password = "AbTp9 fok";
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