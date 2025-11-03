using DAL;
using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminControlController : ControllerBase
    {
        [HttpGet("Consultar")]
        [TokenDbFilter]
        public async Task<IActionResult> Consultar()
        {
            var db = HttpContext.Items["DB"];
            var resp = await AdminControl_controler.Consultar($"{db}");
            return Ok(resp);
        }
    }
}
