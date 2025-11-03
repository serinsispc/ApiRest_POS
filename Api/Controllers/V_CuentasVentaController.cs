using DAL.Controler.Views;
using DAL.Requests_Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_CuentasVentaController : ControllerBase
    {
        [HttpPost("Lista")]
        [TokenDbFilter]
        public async Task<IActionResult> Lista(V_CuentasVenta_requests request)
        {
            var db = HttpContext.Items["DB"];
            var resp =await V_CuentasVenta_controler.Lista($"{db}", request.IdBase,request.MultiCaja);
            return Ok(resp);
        }
        [HttpPost("ListaMesero/{idMesero}")]
        [TokenDbFilter]
        public async Task<IActionResult> ListaMesero(int idMesero)
        {
            var db = HttpContext.Items["DB"];
            var resp =await V_CuentasVenta_controler.ListaMesero($"{db}", idMesero);
            return Ok(resp);
        }
    }
}
