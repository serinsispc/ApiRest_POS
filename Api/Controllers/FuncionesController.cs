using DAL.Controler.Tables;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {
        [HttpGet("ConsultarVendedor/{idventa}")]
        [TokenDbFilter]
        public async Task<IActionResult> ConsultarVendedor(int idventa)
        {
            var db = HttpContext.Items["DB"];
            R_VentaVendedor r_Venta = new R_VentaVendedor();
            r_Venta =await R_VentaVendedor_controler.Consultar_IdVenta($"{db}",idventa);
            if (r_Venta != null)
            {
                Vendedor vendedor = new Vendedor();
                vendedor =await Vendedor_controler.ConsultarID($"{db}", (int)r_Venta.idVendedor);
                if (vendedor != null)
                {
                    return Ok($"{vendedor.nombreVendedor}");
                }
                else
                {
                    return Ok($"--");
                }
            }
            else
            {
                return Ok($"--");
            }
        }
    }
}
