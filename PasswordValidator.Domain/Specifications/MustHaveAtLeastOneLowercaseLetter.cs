using System.Linq;
namespace PasswordValidator.Domain.Specifications
{
    public class MustHaveAtLeastOneLowercaseLetter : ValidatePassword
    {
        public MustHaveAtLeastOneLowercaseLetter(string password) : base(password) => Validate();

        protected override void Validate() => IsValid = Password.Any(ch => char.IsLower(ch));
    }
}
