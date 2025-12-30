using DAL.Controler.Views;
using DAL.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CambiarPreciosController : ControllerBase
    {
        [HttpPost("ConsultarLista")]
        [TokenDbFilter] // Filtro personalizado para validar el token de la base de datos
        public async Task<IActionResult> ConsultarLista()
        {
            // Lógica para cambiar los precios de los productos
            var db=HttpContext.Items["DB"] as string;
            var resultado =await V_CambioPrecios_controler.Lista(db);
            return Ok(resultado);
        }
        [HttpPost("CambiarPreciosGuardar")]
        [TokenDbFilter] // Filtro personalizado para validar el token de la base de datos
        public async Task<IActionResult> CambiarPreciosGuardar(List<V_CambioPrecios> listaPrecios)
        {
            // Lógica para guardar los cambios de precios de los productos
            var db=HttpContext.Items["DB"] as string;
            var resultado =await V_CambioPrecios_controler.Guardar(db, listaPrecios);
            return Ok(resultado);
        }
    }
}
