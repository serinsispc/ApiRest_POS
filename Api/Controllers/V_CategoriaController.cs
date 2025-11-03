using DAL.Controler.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_CategoriaController : ControllerBase
    {
        [HttpGet("ListaActiva")]
        [TokenDbFilter]
        public async Task<IActionResult> ListaActiva()
        {
            var db = HttpContext.Items["DB"];
            var resp = await V_Categoria_controler.ListaActivas($"{db}");
            if (resp == null) { return Ok(null); }
            return Ok(resp);
        }
    }
}
