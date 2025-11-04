using DAL.Controler.Tables;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class R_VentaUsuarioController : ControllerBase
    {
        [HttpPost("Consultar/{IdVenta}")]
        [TokenDbFilter]
        public async Task<IActionResult> Consultar(int IdVenta)
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_VentaUsuario_controler.Consultar_idVenta($"{db}",IdVenta);
            return Ok(resp);
        }

        [HttpPost("CRUD/Insert")]
        [TokenDbFilter]
        public async Task<IActionResult>CRUD_Insert(R_VentaUsuario relacion)
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_VentaUsuario_controler.Crud($"{db}", relacion, 0);
            return Ok(resp);
        }

        [HttpPost("CRUD/Update")]
        [TokenDbFilter]
        public async Task<IActionResult> CRUD_Update(R_VentaUsuario relacion)
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_VentaUsuario_controler.Crud($"{db}", relacion, 1);
            return Ok(resp);
        }

        [HttpPost("CRUD/Delete")]
        [TokenDbFilter]
        public async Task<IActionResult> CRUD_Delete(R_VentaUsuario relacion)
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_VentaUsuario_controler.Crud($"{db}", relacion, 2);
            return Ok(resp);
        }
    }
}
