using DAL.Controler.Tables;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablaVentasController : ControllerBase
    {
        [HttpPost("Cosultar/{id}")]
        [TokenDbFilter]
        public async Task<IActionResult>ConsultarID(int id)
        {
            var db = HttpContext.Items["DB"];
            var resp = await TablaVentas_controler.ConsultarId(id,$"{db}");
            return Ok(resp);
        }
        [HttpPost("CRUD/Insert")]
        [TokenDbFilter]
        public async Task<IActionResult> CRUDInsert(TablaVentas tablaVentas)
        {
            var db = HttpContext.Items["DB"];
            var resp = await TablaVentas_controler.Crud(tablaVentas,0, $"{db}");
            return Ok(resp);
        }
        [HttpPost("CRUD/Update")]
        [TokenDbFilter]
        public async Task<IActionResult> CRUDUpdate(TablaVentas tablaVentas)
        {
            var db = HttpContext.Items["DB"];
            var resp = await TablaVentas_controler.Crud(tablaVentas, 1, $"{db}");
            return Ok(resp);
        }
        [HttpPost("CRUD/Detele")]
        [TokenDbFilter]
        public async Task<IActionResult> CRUDDetele(TablaVentas tablaVentas)
        {
            var db = HttpContext.Items["DB"];
            var resp = await TablaVentas_controler.Crud(tablaVentas, 2, $"{db}");
            return Ok(resp);
        }
        [HttpPost("Consecutivo/{idResolucion}")]
        [TokenDbFilter]
        public async Task<IActionResult> Consecutivo(int idResolucion)
        {
            var db = HttpContext.Items["DB"];
            var resp = await TablaVentas_controler.Consecutivo(idResolucion,$"{db}");
            return Ok(resp);
        }
    }
}
