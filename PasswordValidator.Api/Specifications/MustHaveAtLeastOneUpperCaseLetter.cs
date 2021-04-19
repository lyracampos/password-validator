using System.Linq;
namespace PasswordValidator.Api.Specifications
{
    public class MustHaveAtLeastOneUpperCaseLetter : ValidatePassword
    {
        public MustHaveAtLeastOneUpperCaseLetter(string password) : base(password) => Validate();

        protected override void Validate() => IsValid = Password.Any(ch => char.IsUpper(ch));
    }
}
