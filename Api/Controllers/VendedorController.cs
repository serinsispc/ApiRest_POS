using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        [HttpGet("Consultar/{id}")]
        [TokenDbFilter]
        public async Task<IActionResult>Consultar(int id)
        {
            var db = HttpContext.Items["DB"];
            var vendedor = await Vendedor_controler.ConsultarID($"{db}",id);
            return Ok(vendedor);
        }
    }
}
