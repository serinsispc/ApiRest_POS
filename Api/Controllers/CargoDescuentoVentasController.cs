using DAL.Controler.Tables;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDescuentoVentasController : ControllerBase
    {
        [HttpPost("Lista/{idventa}")]
        [TokenDbFilter]
        public async Task<IActionResult>ListaIdVenta(int idventa)
        {
            var db = HttpContext.Items["DB"];
            var resp = await CargoDescuentoVentas_controler.Lista_idventa($"{db}",idventa);
            return Ok(resp);
        }
        [HttpPost("Crear")]
        [TokenDbFilter]
        public async Task<IActionResult> Crear(CargoDescuentoVentas objeto)
        {
            var db = HttpContext.Items["DB"];
            var resp = await CargoDescuentoVentas_controler.crud($"{db}", objeto,0);
            if (resp.estado)
            {
                int idventa = Convert.ToInt32(objeto.idVenta);
                return Ok(await CargoDescuentoVentas_controler.Lista_idventa($"{db}",  idventa));
            }
            return Ok(new List<CargoDescuentoVentas>());
        }
        [HttpPost("Editar")]
        [TokenDbFilter]
        public async Task<IActionResult> Editar(CargoDescuentoVentas objeto)
        {
            var db = HttpContext.Items["DB"];
            var resp = await CargoDescuentoVentas_controler.crud($"{db}", objeto, 1);
            if (resp.estado)
            {
                int idventa = Convert.ToInt32(objeto.idVenta);
                return Ok(await CargoDescuentoVentas_controler.Lista_idventa($"{db}", idventa));
            }
            return Ok(new List<CargoDescuentoVentas>());
        }
        [HttpPost("Eliminar")]
        [TokenDbFilter]
        public async Task<IActionResult> Eliminar(CargoDescuentoVentas objeto)
        {
            var db = HttpContext.Items["DB"];
            var resp = await CargoDescuentoVentas_controler.crud($"{db}", objeto, 2);
            if (resp.estado)
            {
                int idventa = Convert.ToInt32(objeto.idVenta);
                return Ok(await CargoDescuentoVentas_controler.Lista_idventa($"{db}", idventa));
            }
            return Ok(new List<CargoDescuentoVentas>());
        }
    }
}
