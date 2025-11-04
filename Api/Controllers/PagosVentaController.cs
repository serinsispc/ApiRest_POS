using DAL;
using DAL.Controler.Tables;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosVentaController : ControllerBase
    {
        [HttpPost("InsertPagos")]
        [TokenDbFilter]
        public async Task<IActionResult> InsertPagos(List<PagosVenta> pagos)
        {
            var db = HttpContext.Items["DB"];
            string json=JsonConvert.SerializeObject(pagos);
            json = AjustarJSON.Ajustar(json);
            var resp = await PagosVenta_controler.InsertPago($"{db}",json);
            return Ok(resp);
        }
    }
}
