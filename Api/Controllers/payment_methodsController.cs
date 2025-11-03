using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class payment_methodsController : ControllerBase
    {
        [HttpPost("lista")]
        [TokenDbFilter]
        public async Task<IActionResult> Lista()
        {
            var db = HttpContext.Items["DB"];
            var resp = await payment_methods_controler.Lista($"{db}");
            return Ok(resp);
        }
    }
}
