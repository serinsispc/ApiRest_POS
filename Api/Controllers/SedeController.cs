using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        [HttpGet("Consultar")]
        [TokenDbFilter]
        public async Task<IActionResult> Conultar()
        {
            var db=HttpContext.Items["DB"];
            var resp = await Sede_controler.Consultar($"{db}");
            return Ok(resp);
        }
    }
}
