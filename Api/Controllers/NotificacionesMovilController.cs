using DAL.Controler.Tables;
using DAL.Models.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesMovilController : ControllerBase
    {
        // ✅ NO SE TOCA: ya funciona
        [HttpPost("CRUDNotificacionesMovil/{funcion}")]
        [TokenDbFilter]
        public async Task<IActionResult> CRUDNotificacionesMovil([FromBody] NotificacionesMovil notificaciones, [FromRoute] int funcion)
        {
            var db = HttpContext.Items["DB"] as string;
            var resp = await NotificacionesMovil_controler.CRUD(db, notificaciones, funcion);
            return Ok(resp);
        }

        // ⚠️ Este GET con TokenDbFilter NO te sirve para links de email (no envían headers)
        // Si lo necesitas para consumo interno con tu app (que sí manda headers), lo dejamos.
        [HttpGet("Aprobar/{codigo}")]
        [TokenDbFilter]
        public async Task<IActionResult> Aprobar([FromRoute] string codigo)
        {
            var db = HttpContext.Items["DB"] as string;

            // ✅ Corrección: aquí debe aprobar por codigo (no "notificaciones")
            //var resp = await NotificacionesMovil_controler.Aprobar(db, codigo);

            return Ok("resp");
        }

        // ✅ NUEVO: Endpoint puente para el botón del HTML (funciona desde navegador/email)
        // Mínimo viable: recibe db por query.
        // Luego lo mejoramos a token seguro de un solo uso.
        [HttpGet("AprobarLink")]
        public async Task<IActionResult> AprobarLink([FromQuery] string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return BadRequest(new { estado = false, mensaje = "Código requerido." });

            // Opcional: normalizar
            codigo = codigo.Trim();

            var aprobarNotificacion = new AprobarNotificacionMovil
            {
                id = 0,
                fecha = DateTime.Now,
                codigo = codigo
            };

            // ✅ OJO: esto debe coincidir con la firma real de tu método Aprobar
            var resp = await NotificacionesMovil_controler.Aprobar("DBNotificacionesMovil", aprobarNotificacion);
            if (resp.estado == false)
            {
                return Content(HtmlError(resp.mensaje), "text/html");
            }

            return Content(HtmlSuccess("Aprobación realizada correctamente"), "text/html");

        }

        private string HtmlSuccess(string mensaje)
        {
            return $@"
<!DOCTYPE html>
<html lang=""es"">
<head>
<meta charset=""UTF-8"">

<!-- 🔴 CLAVE PARA RESPONSIVE -->
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">

<title>Aprobado</title>

<style>
* {{
    box-sizing: border-box;
}}

body {{
    margin: 0;
    min-height: 100vh;
    display: flex;
    align-items: center;
    justify-content: center;
    background: linear-gradient(135deg, #16a34a, #22c55e);
    font-family: Arial, sans-serif;
    padding: 15px; /* espacio en móviles */
}}

.card {{
    background: #ffffff;
    padding: 30px 40px;
    border-radius: 14px;
    box-shadow: 0 20px 40px rgba(0, 0, 0, 0.25);
    text-align: center;
    width: 100%;
    max-width: 420px;
}}

.icon {{
    font-size: 64px;
    color: #16a34a;
}}

h1 {{
    margin: 15px 0 10px;
    color: #14532d;
    font-size: 26px;
}}

p {{
    color: #334155;
    font-size: 16px;
    line-height: 1.5;
}}

.btn {{
    display: block;
    width: 100%;
    margin-top: 20px;
    padding: 14px;
    background: #16a34a;
    color: #ffffff;
    border-radius: 8px;
    text-decoration: none;
    font-weight: bold;
    font-size: 16px;
}}

/* 📱 Ajustes para pantallas pequeñas */
@media (max-width: 480px) {{
    .card {{
        padding: 24px 20px;
    }}

    .icon {{
        font-size: 56px;
    }}

    h1 {{
        font-size: 22px;
    }}

    p {{
        font-size: 15px;
    }}
}}
</style>
</head>

<body>
    <div class=""card"">
        <div class=""icon"">✅</div>
        <h1>Aprobado</h1>
        <p>{{mensaje}}</p>
        <a class=""btn"" onclick=""window.close()"">Cerrar</a>
    </div>
</body>
</html>
";
        }

        private string HtmlError(string mensaje)
        {
            return $@"
<!DOCTYPE html>
<html lang=""es"">
<head>
<meta charset=""UTF-8"">

<!-- 🔴 CLAVE PARA RESPONSIVE -->
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">

<title>Error</title>

<style>
* {{
    box-sizing: border-box;
}}

body {{
    margin: 0;
    min-height: 100vh;
    display: flex;
    align-items: center;
    justify-content: center;
    background: linear-gradient(135deg, #dc2626, #ef4444);
    font-family: Arial, sans-serif;
    padding: 15px; /* espacio en móviles */
}}

.card {{
    background: #fff;
    padding: 30px 40px;
    border-radius: 14px;
    box-shadow: 0 20px 40px rgba(0, 0, 0, 0.25);
    text-align: center;
    width: 100%;
    max-width: 420px;
}}

.icon {{
    font-size: 64px;
    color: #dc2626;
}}

h1 {{
    margin: 15px 0 10px;
    color: #7f1d1d;
    font-size: 26px;
}}

p {{
    color: #334155;
    font-size: 16px;
    line-height: 1.5;
}}

/* 📱 Ajustes para pantallas pequeñas */
@media (max-width: 480px) {{
    .card {{
        padding: 24px 20px;
    }}

    .icon {{
        font-size: 56px;
    }}

    h1 {{
        font-size: 22px;
    }}

    p {{
        font-size: 15px;
    }}
}}
</style>
</head>

<body>
    <div class=""card"">
        <div class=""icon"">❌</div>
        <h1>Error</h1>
        <p>{{mensaje}}</p>
    </div>
</body>
</html>
";
        }


    }
}
