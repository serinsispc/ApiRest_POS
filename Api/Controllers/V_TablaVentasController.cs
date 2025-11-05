using DAL.Controler.Views;
using DAL.Funciones;
using DAL.Models.Views;
using DAL.Requests_Responses.V_TablaVentas_rr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_TablaVentasController : ControllerBase
    {
        [HttpPost("Consultar/{id}")]
        [TokenDbFilter]
        public async Task<IActionResult> Consultar(int id)
        {
            var db=HttpContext.Items["DB"];
            var resp = await V_TablaVentas_controler.Consulta_id(id,$"{db}");
            return Ok(resp);
        }
        [HttpPost("Filtrar")]
        [TokenDbFilter]
        public async Task<IActionResult> Filtrar(Filtrar_Requests requests)
        {
            var db = HttpContext.Items["DB"];
            var lista = await FiltrarV_TablaVentas.Filtrar($"{db}",requests.year,requests.mes,requests.dia);
            return Ok(lista);
        }
    }
}
