using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.DAO;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVeiculoController : ControllerBase
    {
        [HttpGet("listar")]
        public IActionResult ListarTiposVeiculo()
        {
            try
            {
                TipoVeiculoDAO tipoveiculoDAO = new TipoVeiculoDAO();
                var tiposveiculo = tipoveiculoDAO.ListarTiposVeiculo();
                return Ok(tiposveiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
