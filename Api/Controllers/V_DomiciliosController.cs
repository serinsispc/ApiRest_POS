using DAL.Controler.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_DomiciliosController : ControllerBase
    {
        [HttpPost("Filtrar/{fecha}")]
        [TokenDbFilter]
        public async Task<IActionResult>Colsultar(string fecha)
        {
            var db = HttpContext.Items["DB"];
            var resp = await V_Domicilios_controler.Filtrar($"{db}",fecha);
            return Ok(resp);
        }
    }
}
