using DAL.Controler.Tables;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCajaController : ControllerBase
    {
        [HttpPost("ConsultarActiva/{idusuario}")]
        [TokenDbFilter]
        public async Task<IActionResult> ConsultarActiva(int idusuario)
        {
            var db=HttpContext.Items["DB"];
            var resp = await BaseCaja_controler.ConultarIdUsuario(idusuario,$"{db}");
            if (resp == null)
                return Ok(0);
            return Ok(resp.id);
        }
        [HttpPost("Consultar/{id}")]
        [TokenDbFilter]
        public async Task<IActionResult> Consultar(int id)
        {
            var db = HttpContext.Items["DB"];
            var resp = await BaseCaja_controler.ConultarId(id, $"{db}");
            if (resp == null)
                return Ok(null);
            return Ok(resp);
        }
        [HttpPost("Insert")]
        [TokenDbFilter]
        public async Task<IActionResult> Insert(BaseCaja baseCaja)
        {
            var db = HttpContext.Items["DB"];
            var resp = await BaseCaja_controler.CrearEditarEliminarBaseCaja(baseCaja,0, $"{db}");
            return Ok(resp);
        }
        [HttpPost("Update")]
        [TokenDbFilter]
        public async Task<IActionResult> Update(BaseCaja baseCaja)
        {
            var db = HttpContext.Items["DB"];
            var resp = await BaseCaja_controler.CrearEditarEliminarBaseCaja(baseCaja, 1, $"{db}");
            return Ok(resp);
        }
    }
}
