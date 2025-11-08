using DAL.Controler.Views;
using DAL.Requests_Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_CompraController : ControllerBase
    {
        [HttpPost("Lista/{estado}")]
        [TokenDbFilter]
        public async Task<IActionResult>Lista(int estado)
        {
            var db = HttpContext.Items["DB"];
            var resp = await V_Compra_controler.ListaCompleta_Sede(estado,$"{db}");
            return Ok(resp);
        }
        [HttpPost("Filtrar/Dia")]
        [TokenDbFilter]
        public async Task<IActionResult> FiltrarDia(V_Compra_rr rr)
        {
            var db = HttpContext.Items["DB"];
            var resp = await V_Compra_controler.FiltarFecha_dia(2, rr.Fecha, $"{db}");
            return Ok(resp);
        }
        [HttpPost("Filtrar/Mes")]
        [TokenDbFilter]
        public async Task<IActionResult> FiltrarMes(V_Compra_rr rr)
        {
            var db = HttpContext.Items["DB"];
            var resp = await V_Compra_controler.FiltarFecha_mes(2, rr.Fecha, $"{db}");
            return Ok(resp);
        }
        [HttpPost("Filtrar/Year")]
        [TokenDbFilter]
        public async Task<IActionResult> FiltrarYear(V_Compra_rr rr)
        {
            var db = HttpContext.Items["DB"];
            var resp = await V_Compra_controler.FiltarFecha_ano(2, rr.Fecha, $"{db}");
            return Ok(resp);
        }
    }
}
