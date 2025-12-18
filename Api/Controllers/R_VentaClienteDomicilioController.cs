using DAL.Controler.Tables;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class R_VentaClienteDomicilioController : ControllerBase
    {
        [HttpPost("CRUD/{accion}")]
        [TokenDbFilter]
        public async Task<IActionResult>CRUD(int accion,R_VentaClienteDomicilio relacion)
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_VentaClienteDomicilio_controler.CRUD($"{db}",relacion, accion);
            return Ok(resp);
        }
        [HttpPost("Consultar/{idventa}")]
        [TokenDbFilter]
        public async Task<IActionResult> Consultar(int idventa)
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_VentaClienteDomicilio_controler.ConsultarIdVenta($"{db}", idventa);
            return Ok(resp);
        }
    }
}
