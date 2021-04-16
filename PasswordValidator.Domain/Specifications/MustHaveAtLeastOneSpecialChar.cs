namespace PasswordValidator.Domain.Specifications
{
    public class MustHaveAtLeastOneSpecialChar : ValidatePassword
    {
        private const string SPECIALCARACTERES = "!@#$%^&*()-+";

        public MustHaveAtLeastOneSpecialChar(string password) : base(password) => Validate();

        protected override void Validate() => IsValid = Password.IndexOfAny(SPECIALCARACTERES.ToCharArray()) >= 1;
    }
}
