using DAL;
using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionDianController : ControllerBase
    {
        [HttpGet("Consultar/{idambiente}")]
        [TokenDbFilter]
        public async Task<IActionResult> ConsultarIdAmbiente(int idambiente)
        {
            var db = HttpContext.Items["DB"];
            var rap = await ConfiguracionDian_controler.Consultar_idAmbiente(idambiente, $"{db}");
            return Ok(rap);
        }
    }
}
