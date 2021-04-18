namespace PasswordValidator.Api.Models
{
    public class PasswordRequest
    {
        public PasswordRequest()
        {

        }

        public PasswordRequest(string password)
        {
            Password = password;
        }

        public string Password { get; set; }
    }
}