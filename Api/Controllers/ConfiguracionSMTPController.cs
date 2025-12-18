using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionSMTPController : ControllerBase
    {
        [HttpPost("consultar")]
        [TokenDbFilter]
        public async Task<IActionResult> ConsultarConfiguracionSMTP()
        {
            var db= HttpContext.Items["DB"] as string;
            var resultado = await ConfiguracionSMTP_controler.Consultar(db);
            return Ok(resultado);
        }
    }
}
