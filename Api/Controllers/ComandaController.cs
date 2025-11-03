using DAL.Controler.Views;
using DAL.Requests_Responses.Comanda_rr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        [HttpPost("Lista")]
        [TokenDbFilter]
        public async Task<IActionResult> Lista(Comanda_Requests requests)
        {
            var db = HttpContext.Items["DB"];
            var resp = await Comanda_controler.Lista($"{db}",requests.idventa,requests.Tipo,requests.estado);
            return Ok(resp);
        }
    }
}
