using Microsoft.Extensions.Configuration;
using PasswordValidator.Api;
namespace PasswordValidator.Tests.IntegrationTests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
