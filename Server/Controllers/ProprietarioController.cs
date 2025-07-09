using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Server.DAO;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
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
        public IActionResult ListarProprietarios()
        {
            try
            {
                ProprietarioDAO proprietarioDAO = new ProprietarioDAO();
                var proprietarios = proprietarioDAO.ListProprietario();
                return Ok(proprietarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("listarPorId/{id}")]
        public IActionResult ListarProprietariosPorId([FromRoute] int? id)
        {
            try
            {
                ProprietarioDAO proprietarioDAO = new ProprietarioDAO();
                var proprietarioPorId = proprietarioDAO.ListProprietarioPorId(id);
                return Ok(proprietarioPorId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
