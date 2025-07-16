using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.DAO;
using Shared.Models;

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
        public IActionResult ListarVeiculosPorId([FromRoute] int id)
        {
            try
            {
                VeiculoDAO veiculoDAO = new VeiculoDAO();
                var veiculo = veiculoDAO.ListarVeiculoPorId(id);
                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("incluir")]
        public IActionResult IncluirVeiculo([FromBody] Veiculo veiculo)
        {
            try
            {                
                VeiculoDAO veiculoDAO = new VeiculoDAO();
                veiculoDAO.CreateVeiculo(veiculo);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("excluir/{id_veiculo}")]
        public IActionResult ExcluirVeiculo([FromRoute] int id_veiculo)
        {
            try
            {
                VeiculoDAO veiculoDAO = new VeiculoDAO();
                veiculoDAO.DeleteVeiculo(id_veiculo);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
