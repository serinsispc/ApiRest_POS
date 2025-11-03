using DAL.Controler.Views;
using DAL.Requests_Responses.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class v_UsuarioController : ControllerBase
    {
        [HttpPost("Login")]
        [TokenDbFilter]
        public async Task<IActionResult> Login(loginRequests requests)
        {
            var db = HttpContext.Items["DB"];
            var resp = await v_Usuario_controler.ConsultaUsuarioYClave(requests,$"{db}");
            return Ok(resp);
        }
    }
}
