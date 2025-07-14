using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.DAO;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        [HttpGet("listar")]
        public IActionResult ListarModelos()
        {
            try
            {
                ModeloDAO modeloDAO = new ModeloDAO();
                var modelos = modeloDAO.ListarModelos();
                return Ok(modelos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
