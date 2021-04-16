using System.Linq;

namespace PasswordValidator.Domain.Specifications
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
