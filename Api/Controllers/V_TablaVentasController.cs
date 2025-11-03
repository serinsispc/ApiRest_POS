using DAL.Controler.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_TablaVentasController : ControllerBase
    {
        [HttpGet("Consultar/{id}")]
        [TokenDbFilter]
        public async Task<IActionResult> Consultar(int id)
        {
            var db=HttpContext.Items["DB"];
            var resp = await V_TablaVentas_controler.Consulta_id(id,$"{db}");
            return Ok(resp);
        }
    }
}
