using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.DAO;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("listar")]
        public IActionResult ListarVeiculos()
        {
            try
            {
                VeiculoDAO veiculoDAO = new VeiculoDAO();
                var veiculos = veiculoDAO.ListarVeiculos();
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("listarPorId/{id}")]
        public IActionResult ListarVeiculosPorId([FromRoute] int? id)
        {
            try
            {
                // Implementar lógica para listar veículo por ID
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("excluir/{id_veiculo}/{id_proprietario}")]
        public IActionResult ExcluirVeiculo([FromRoute] int? id_veiculo, [FromRoute] int? id_proprietario)
        {
            try
            {
                // Implementar lógica para excluir veículo
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
