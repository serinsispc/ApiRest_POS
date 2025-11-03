using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Fuerza el alias EXACTO que usas en IIS
            app.UsePathBase("/ApiPOS");

            // Swagger siempre activo
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // Ruta ABSOLUTA con el alias para evitar 404
                c.SwaggerEndpoint("v1/swagger.json", "Api v1");
                c.RoutePrefix = "swagger"; // => /ApiPOS/swagger
            });

            // Si tu sitio en IIS solo tiene HTTP, deja comentada esta línea
            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
