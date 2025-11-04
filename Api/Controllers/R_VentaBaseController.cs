using DAL.Controler.Tables;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class R_VentaBaseController : ControllerBase
    {
        [HttpPost("Consultar/{idVenta}")]
        [TokenDbFilter]
        public async Task<IActionResult> Consultar(int idVenta)
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_VentaBase_controler.Consultar($"{db}", idVenta);
            return Ok(resp);
        }

        [HttpPost("CRUD/Insert")]
        [TokenDbFilter]
        public async Task<IActionResult> CRUD_Insert(R_VentaBase ventaBase)
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_VentaBase_controler.CRUD($"{db}", 0,ventaBase);
            return Ok(resp);
        }

        [HttpPost("CRUD/Update")]
        [TokenDbFilter]
        public async Task<IActionResult> CRUD_Update(R_VentaBase ventaBase)
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_VentaBase_controler.CRUD($"{db}", 1, ventaBase);
            return Ok(resp);
        }
        [HttpPost("CRUD/Delete")]
        [TokenDbFilter]
        public async Task<IActionResult> CRUD_Delete(R_VentaBase ventaBase)
        {
            var db = HttpContext.Items["DB"];
            var resp = await R_VentaBase_controler.CRUD($"{db}", 2, ventaBase);
            return Ok(resp);
        }

    }

}
