using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreosNotificacionesController : ControllerBase
    {
        [HttpPost("Lista")]
        [TokenDbFilter]
        public async Task<IActionResult> Lista()
        {
            var db = HttpContext.Items["DB"];
            var resp = await CorreosNotificaciones_controler.Lista($"{db}");
            return Ok(resp);
        }
    }
}
