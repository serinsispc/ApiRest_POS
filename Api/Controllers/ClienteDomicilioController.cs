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
        [HttpPost("Filtrar/{telefono}")]
        [TokenDbFilter]
        public async Task<IActionResult> FiltarTelefono(string telefono)
        {
            var db = HttpContext.Items["DB"];
            var resp = await ClienteDomicilio_controler.FiltrarTelefono($"{db}",telefono);
            return Ok(resp);
        }
        [HttpPost("CRUD/{boton}")]
        public async Task<IActionResult> Insert(int boton,ClienteDomicilio cliente)
        {
            var db = HttpContext.Items["DB"];
            var resp = await ClienteDomicilio_controler.CRUD($"{db}",cliente,boton);
            return Ok(resp);
        }
    }
}
