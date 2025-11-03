using Api.Filters;
using DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

public static class RequestHelper
{
    /// <summary>
    /// Extrae y valida el token y el nombre de la base de datos desde el HttpContext.
    /// </summary>
    public static async Task<(bool isValid, string token, string dbName, string errorMessage)> ExtraerTokenYDB(HttpContext http, object requestModel = null, string dbPropName = "nombreDB")
    {
        // 1️⃣ Extraer token
        var auth = http.Request.Headers["Authorization"].ToString();
        var token = (!string.IsNullOrWhiteSpace(auth) && auth.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    ? auth.Substring(7).Trim()
                    : http.Request.Query["token"].ToString();

        if (string.IsNullOrWhiteSpace(token) || !await ClassToken.VereficarToken(token))
        {
            return (false, null, null, "¡El token no es válido o ha expirado!");
        }

        http.Items["BearerToken"] = token;

        // 2️⃣ Extraer nombre de la DB
        string dbName = null;

        if (requestModel != null)
        {
            var prop = requestModel.GetType().GetProperty(dbPropName);
            if (prop != null && prop.PropertyType == typeof(string))
            {
                dbName = prop.GetValue(requestModel) as string;
            }
        }

        if (string.IsNullOrWhiteSpace(dbName))
        {
            dbName = http.Request.Headers["X-NombreDB"].ToString()?.Trim();
        }

        if (string.IsNullOrWhiteSpace(dbName))
        {
            return (false, token, null, "No se recibió el nombre de la base de datos.");
        }

        if(!await ClassToken.VereficarToken(token))
        {
            return (false, token, null, "Token invalido.");
        }

        return (true, token, dbName, null);
    }
}