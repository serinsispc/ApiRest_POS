using DAL;
using DAL.Models.Tables;
using DAL.Requests_Responses.Otros_rr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtrosController : ControllerBase
    {
        [HttpPost("CrudReporteImpuesto")]
        [TokenDbFilter]
        public async Task<IActionResult> CrudReporteImpuesto(CrudReporteImpuesto_Requests requests)
        {
            var db = HttpContext.Items["DB"];
            var query1 = $"EXEC CrudReporteImpuesto {requests.IdVenta}, {requests.Valor}";
            var cn = new ConnectionSQL();
            await cn.EjecutarConsulta($"{db}",query1);
            return Ok();
        }
        [HttpPost("HallarIdMetodoDePagoInterno/{idmediop}")]
        [TokenDbFilter]
        public async Task<IActionResult> HallarIdMetodoDePagoInterno(int idmediop)
        {
            var db = HttpContext.Items["DB"];
            string query = $"SELECT idMediosDePagoInternos FROM R_MediosDePago_MediosDePagoInternos WHERE idMedioDePago = {idmediop}";
            var cn=new ConnectionSQL();
            var result =await cn.EjecutarConsulta($"{db}",query, true);
            var lista = JsonConvert.DeserializeObject<List<R_MediosDePago_MediosDePagoInternos>>(result).FirstOrDefault();
            return Ok((int)lista.idMediosDePagoInternos);
        }
        [HttpPost("HallarMediosDePagoRelacionedos/{idmediop}")]
        [TokenDbFilter]
        public async Task<IActionResult> HallarMediosDePagoRelacionedos(int idmediop)
        {
            var db = HttpContext.Items["DB"];
            string query = $"SELECT * FROM R_MediosDePago_MediosDePagoInternos WHERE idMedioDePago = {idmediop}";
            var cn = new ConnectionSQL();
            var result = await cn.EjecutarConsulta($"{db}", query, true);
            var lista = JsonConvert.DeserializeObject<List<R_MediosDePago_MediosDePagoInternos>>(result).ToList();
            int cantidad= lista.Count;
            return Ok(cantidad);
        }

        [HttpPost("EliminarCuenta/{id}")]
        [TokenDbFilter]
        public async Task<IActionResult> EliminarCuenta(int id)
        {
            var db = HttpContext.Items["DB"];
            string query = $"EXEC EliminarCuenta {id}";
            var cn=new ConnectionSQL();
            await cn.EjecutarConsulta($"{db}", query);
            return Ok();
        }
    }
}
