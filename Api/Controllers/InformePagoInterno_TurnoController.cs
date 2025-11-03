using DAL.Models.Procedures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformePagoInterno_TurnoController : ControllerBase
    {
        [HttpGet("Lista/{idbase}")]
        [TokenDbFilter]
        public async Task<IActionResult> Lista(int idbase)
        {
            var db = HttpContext.Items["DB"];
            var resp = await InformePagoInterno_Turno_Result.Consultar($"{db}", idbase);
            return  Ok(resp);
        }
    }
}
