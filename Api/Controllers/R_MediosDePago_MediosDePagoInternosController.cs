using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class R_MediosDePago_MediosDePagoInternosController : ControllerBase
    {
        [HttpGet("Lista")]
        [TokenDbFilter]
        public async Task<IActionResult> Lista()
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_MediosDePago_MediosDePagoInternos_controler.Lista($"{db}");
            return Ok(resp);
        }
    }
}
