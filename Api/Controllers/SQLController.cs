using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SQLController : ControllerBase
    {
        [HttpPost("execute-sql")]
        [TokenDbFilter]
        public async Task<IActionResult> ExecuteSql(ConsultaSQL json)
        {
            try
            {
                var db=HttpContext.Items["DB"] as string;
                var cn=new ConnectionSQL();
                var result = await cn.EjecutarConsulta(db, json.query,true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
