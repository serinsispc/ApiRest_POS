using DAL.Controler.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_ResolucionesController : ControllerBase
    {
        [HttpPost("Lista")]
        [TokenDbFilter]
        public async Task<IActionResult> Lista()
        {
            var db=HttpContext.Items["DB"];
            var resp = await V_Resoluciones_controler.Lista($"{db}");
            return Ok(resp);
        }
    }
}
