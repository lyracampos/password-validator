using PasswordValidator.Domain.Specifications;

namespace PasswordValidator.Domain.Entities
{
    public class Password
    {
        public Password(string value)
        {
            Value = value;
            Validate();
        }
        public string Value { get; private set; }
        public bool IsValid { get; private set; }

        private void Validate() =>
            IsValid =
                (
                    !string.IsNullOrEmpty(Value) &&
                    new ShouldBeGreaterThanNineChars(Value).IsValid &&
                    new MustHaveAtLeastOneChar(Value).IsValid &&
                    new MustHaveAtLeastOneLowercaseLetter(Value).IsValid &&
                    new MustHaveAtLeastOneUpperCaseLetter(Value).IsValid &&
                    new MustHaveAtLeastOneSpecialChar(Value).IsValid &&
                    new CannotContainerRepeatedChar(Value).IsValid
                );
    }
}
