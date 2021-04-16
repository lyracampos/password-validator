namespace PasswordValidator.Domain.Specifications
{
    public class ShouldBeGreaterThanNineChars : ValidatePassword
    {
        public ShouldBeGreaterThanNineChars(string password) : base(password) => Validate();

        protected override void Validate() => IsValid = !string.IsNullOrEmpty(Password) && Password.Length >= 9;
    }
}
