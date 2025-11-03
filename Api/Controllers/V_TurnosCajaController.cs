using DAL.Controler.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_TurnosCajaController : ControllerBase
    {
        [HttpGet("Cosultar/{idusuario}")]
        [TokenDbFilter]
        public async Task<IActionResult> Consultar(int idusuario)
        {
            var db = HttpContext.Items["DB"];
            var resp = await V_TurnosCaja_controler.consultaBaseActiva("ACTIVA",idusuario, $"{db}");
            return Ok(resp);
        }

        [HttpGet("Base/{id}")]
        [TokenDbFilter]
        public async Task<IActionResult> ConsultarID(int id)
        {
            var db = HttpContext.Items["DB"];
            var resp = await V_TurnosCaja_controler.ConsutarID( id, $"{db}");
            return Ok(resp);
        }
    }
}
