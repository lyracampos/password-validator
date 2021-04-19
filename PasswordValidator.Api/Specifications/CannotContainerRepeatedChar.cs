using System.Linq;

namespace PasswordValidator.Api.Specifications
{
    public class CannotContainerRepeatedChar : ValidatePassword
    {
        public CannotContainerRepeatedChar(string password) : base(password)
        {
            Validate();
        }

        protected override void Validate()
        {
            IsValid = Password.Distinct().Count() == Password.Length;
        }
    }
}
