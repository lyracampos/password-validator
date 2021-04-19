namespace PasswordValidator.Api.Specifications
{
    public abstract class ValidatePassword
    {
        protected ValidatePassword(string password)
        {
            Password = password;
        }

        public string Password { get; private set; }
        public bool IsValid { get; protected set; }
        protected abstract void Validate();
    }
}
