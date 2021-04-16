using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Api.Models;
using PasswordValidator.Domain.Entities;

namespace PasswordValidator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordValidatorController : ControllerBase
    {
        [HttpPost]
        public PasswordResult Post([FromBody] PasswordRequest request)
        {
            return new PasswordResult
            {
                IsValid = new Password(request.Password).IsValid
            };
        }


        [HttpGet]
        public PasswordResult Get()
        {
            return new PasswordResult
            {
                IsValid = true
            };
        }
    }
}