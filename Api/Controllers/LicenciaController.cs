using DAL;
using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenciaController : ControllerBase
    {
        [HttpPost("Consultar/{claveLicencia}")]
        [TokenDbFilter]
        public async Task<IActionResult>Consultar(string claveLicencia)
        {
            var db=HttpContext.Items["DB"];
            var resp = await Licencia_controler.ConsultarLicencia(claveLicencia,$"{db}");

            if (resp == null)
                return Ok(new RespuestaDAL { Data=null, Estado=false, Mensaje="no se encontro la licencia" });

            return Ok(new RespuestaDAL { Data = resp, Estado = true, Mensaje = "ok" });
        }
    }
}
