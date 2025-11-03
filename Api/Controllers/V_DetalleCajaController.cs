using DAL.Controler.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_DetalleCajaController : ControllerBase
    {
        [HttpPost("Lista/{idventa}")]
        [TokenDbFilter]
        public async Task<IActionResult>ListaIdVenta(int idventa)
        {
            var db=HttpContext.Items["DB"];
            var resp = await V_DetalleCaja_controler.Consultar_idVenta(idventa,$"{db}");
            return Ok(resp);
        }
    }
}
