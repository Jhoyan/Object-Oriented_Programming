using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.DAO;
using Shared.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpPost("incluir")]
        public IActionResult CreatePessoa([FromBody] Proprietario proprietario)
        {
            try
            {
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoaDAO.CreatePessoa(proprietario);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("atualizar")]
        public IActionResult UpdatePessoa([FromBody] Proprietario proprietario)
        {
            try
            {
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoaDAO.UpdatePessoa(proprietario);
                return Ok(proprietario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
