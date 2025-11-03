using DAL;
using DAL.Controler.Tables;
using DAL.Models.Tables;
using DAL.Requests_Responses.AutorizacionPC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizacionPCController : ControllerBase
    {
        [HttpPost("Consultar")]
        [TokenDbFilter]
        public async Task<IActionResult> Consultar(ConsultarXSerial_Requests requests)
        {
            var db = HttpContext.Items["DB"];

            // Ya tienes el nombre de la DB en dbName
            var resp =await AutorizacionPC_controler.ConsultarXSerial(requests, $"{db}");
            if (resp != null)
            {
                return Ok(new RespuestaDAL { Estado=true, Data=resp, Mensaje="ok" });
            }
            else
            {
                return Ok(new RespuestaDAL { Estado = false, Data = resp, Mensaje = "erro" });
            }
        }
        [HttpPost("InsertInto")]
        [TokenDbFilter]
        public async Task<IActionResult> InsertInto(AutorizacionPC requests)
        {
            var db = HttpContext.Items["DB"];

            var resp = await AutorizacionPC_controler.Crear_Editar_Eliminar_Equipo(requests,0, $"{db}");
            return Ok(resp);
        }
        [HttpPut("Update")]
        [TokenDbFilter]
        public async Task<IActionResult> Update(AutorizacionPC requests)
        {
            var db = HttpContext.Items["DB"];

            var resp = await AutorizacionPC_controler.Crear_Editar_Eliminar_Equipo(requests, 1,$"{db}");
            return Ok(resp);
        }
        [HttpDelete("Delete")]
        [TokenDbFilter]
        public async Task<IActionResult> Delete(AutorizacionPC requests)
        {
            var db = HttpContext.Items["DB"];

            var resp =await AutorizacionPC_controler.Crear_Editar_Eliminar_Equipo(requests, 2, $"{db}");
            return Ok(resp);
        }
    }
}
