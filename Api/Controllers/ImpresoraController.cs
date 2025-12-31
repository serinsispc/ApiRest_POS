using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpresoraController : ControllerBase
    {
        [HttpPost("ListaImpresora")]
        [TokenDbFilter]
        public async Task<IActionResult> ListaImpresora()
        {
            var db= HttpContext.Items["DB"] as string;
            var result = await Impresora_controler.Lista(db);
            return Ok(result);
        }
    }
}
