using DAL.Controler.Tables;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteDomicilioController : ControllerBase
    {
        [HttpPost("lista")]
        [TokenDbFilter]
        public async Task<IActionResult> FiltarTelefono()
        {
            var db = HttpContext.Items["DB"];
            var resp = await ClienteDomicilio_controler.lista($"{db}");
            return Ok(resp);
        }
        [HttpPost("CRUD/{boton}")]
        [TokenDbFilter]
        public async Task<IActionResult> Insert(int boton,ClienteDomicilio cliente)
        {
            var db = HttpContext.Items["DB"];
            var resp = await ClienteDomicilio_controler.CRUD($"{db}",cliente,boton);
            return Ok(resp);
        }
    }
}
