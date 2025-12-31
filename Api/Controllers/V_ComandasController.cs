using DAL.Controler.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_ComandasController : ControllerBase
    {
        [HttpPost("Lista")]
        [TokenDbFilter]
        public async Task<IActionResult> Lista()
        {
            var db= HttpContext.Items["DB"] as string;
            var result = await V_Comandas_controler.Lista(db);
            return Ok(result);
        }
    }
}
