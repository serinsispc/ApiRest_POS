using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediosDePagoInternosController : ControllerBase
    {
        [HttpGet("Consultar/{idmp}")]
        [TokenDbFilter]
        public async Task<IActionResult>Conaultar(int idmp)
        {
            var db = HttpContext.Items["DB"];
            var resp = await MediosDePagoInternos_controler.Consulta($"{db}",idmp);
            return Ok(resp);
        }

        [HttpGet("Lista")]
        [TokenDbFilter]
        public async Task<IActionResult> Lista()
        {
            var db = HttpContext.Items["DB"];
            var resp = await MediosDePagoInternos_controler.Lista($"{db}");
            return Ok(resp);
        }
    }

}
