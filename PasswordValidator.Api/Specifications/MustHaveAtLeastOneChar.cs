namespace PasswordValidator.Api.Specifications
{
    public class MustHaveAtLeastOneChar : ValidatePassword
    {
        public MustHaveAtLeastOneChar(string password) : base(password) => Validate();

        protected override void Validate() => IsValid = Password.Length >= 1;
    }
}
