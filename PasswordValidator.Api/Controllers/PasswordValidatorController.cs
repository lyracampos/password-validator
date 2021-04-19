using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Api.Models;

namespace PasswordValidator.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PasswordValidatorController : ControllerBase
    {
        /// <summary>
        /// Atualiza as informações cadastrais do parceiro.
        /// </summary>
        /// <param name="request">Payload com as informações para atualização</param>
        /// <param name="cpf">Cpf do parceiro a ser atualizado</param>
        /// <param name="atualizarParceiroPessoaFisicaUseCase">Serviço responsável por atualizar parceiro pessoa física.</param>
        /// <returns></returns>
        /// <response code="200">indica que a solicitação foi feita com sucesso.</response>
        /// <response code="500">indica que algum erro interno aconteceu com a aplicação.</response>
        [HttpPost]
        [ProducesResponseType(typeof(PasswordResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public PasswordResult Post([FromBody] PasswordRequest request)
        {
            return new PasswordResult
            {
                IsValid = new Password(request.Password).IsValid
            };
        }
    }
}