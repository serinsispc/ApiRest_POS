using DAL.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_InventarioController : ControllerBase
    {
        [HttpPost("ConsultarLista")]
        [TokenDbFilter]
        public async Task<IActionResult> ConsultarLista()
        {
            try
            {
                var db = HttpContext.Items["DB"] as string;
                var lista = await DAL.Controler.Views.V_Inventario_controler.ConsultarLista(db);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("AjustarInvetario")]
        [TokenDbFilter]
        public async Task<IActionResult> AjustarInvetario(List<V_Inventario> inventarios)
        {
            try
            {
                var db = HttpContext.Items["DB"] as string;
                var cantidad = await DAL.Controler.Views.V_Inventario_controler.AjustarInventario(db, inventarios);
                return Ok(cantidad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
