using Microsoft.AspNetCore.Mvc;
using Server.DAO;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorController : ControllerBase
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
        public IActionResult ListarCores()
        {
            try
            {
                CorDAO corDAO = new CorDAO();
                var cores = corDAO.ListCores();
                return Ok(cores);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
