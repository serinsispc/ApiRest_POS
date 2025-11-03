using DAL;
using DAL.Controler.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesController : ControllerBase
    {
        [HttpPost("ConsultarGUID/{idguid}")]
        [TokenDbFilter]
        public async Task<IActionResult> ConsultarGUID(string idguid)
        {
            var db = HttpContext.Items["DB"];
            var img = await Imagenes_controler.ConsultarGUID(idguid, $"{db}");

            if(img == null) 
                return Ok(new RespuestaDAL { Data=null, Estado=false, Mensaje="error" });

            return Ok(new RespuestaDAL { Data=img, Mensaje="ok", Estado=true });
        }
    }
}
