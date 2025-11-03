using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

public class TokenDbFilterAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var (ok, _, db, error) = await RequestHelper.ExtraerTokenYDB(context.HttpContext, null);

        if (!ok)
        {
            context.Result = new UnauthorizedObjectResult(new { mensaje = error });
            return;
        }

        // Puedes guardar la base de datos en HttpContext.Items
        context.HttpContext.Items["DB"] = db;

        // Continua con el pipeline normal
        await next();
    }
}
