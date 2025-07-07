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
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                PessoaDAO pessoaDAO = new PessoaDAO();
                return Ok(pessoaDAO.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost()]
        public IActionResult CreatePessoa([FromBody] Pessoa pessoa)
        {
            try
            {
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoaDAO.CreatePessoa(pessoa);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
