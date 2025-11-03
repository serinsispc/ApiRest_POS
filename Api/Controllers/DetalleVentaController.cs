
using DAL.Controler.Views;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        [HttpPost("Editar")]
        [TokenDbFilter]
        public async Task<IActionResult> Editar(DetalleVenta detalle)
        {
            var db = HttpContext.Items["DB"];
            var resp = await DetalleVenta_controler.GuardarEditarEliminar(detalle,1,$"{db}");
            if (resp)
            {
                var respDetalle = await V_DetalleCaja_controler.Consultar_idVenta((int)detalle.idVenta,$"{db}");
                if (respDetalle != null)
                    return Ok(respDetalle);

                return Ok(null);
            }
            else
            {
                return Ok(null);
            }
        }
    }
}
