using System.Linq;
namespace PasswordValidator.Api.Specifications
{
    public class MustHaveAtLeastOneLowercaseLetter : ValidatePassword
    {
        public MustHaveAtLeastOneLowercaseLetter(string password) : base(password) => Validate();

        protected override void Validate() => IsValid = Password.Any(ch => char.IsLower(ch));
    }
}
