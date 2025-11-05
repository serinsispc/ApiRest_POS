using DAL.Models.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Funciones
{
    public class FiltrarV_TablaVentas
    {
        public static async Task<string> Filtrar(string db, int YEAR, [Optional] int MONTH, [Optional] int DAY)
        {
            try
            {
                string query = string.Empty;
                if (DAY > 0)
                {
                    query = $@"BEGIN
    SET NOCOUNT ON;

    DECLARE @json NVARCHAR(MAX);

    SELECT @json = (
        SELECT *
        FROM V_TablaVentas
        WHERE  YEAR(fechaVenta)={YEAR} and MONTH(fechaVenta)={MONTH} and DAY(fechaVenta)={DAY}
        FOR JSON PATH
    );

    SELECT @json AS Json;
END;";
                }
                else if (MONTH > 0)
                {
                    query = $@"BEGIN
    SET NOCOUNT ON;

    DECLARE @json NVARCHAR(MAX);

    SELECT @json = (
        SELECT *
        FROM V_TablaVentas
        WHERE  YEAR(fechaVenta)={YEAR} and MONTH(fechaVenta)={MONTH}
        FOR JSON PATH
    );

    SELECT @json AS Json;
END;";
                }
                else 
                {
                    query= $@"BEGIN
    SET NOCOUNT ON;

    DECLARE @json NVARCHAR(MAX);

    SELECT @json = (
        SELECT *
        FROM V_TablaVentas
        WHERE  YEAR(fechaVenta)={YEAR}
        FOR JSON PATH
    );

    SELECT @json AS Json;
END;";
                }


                var cn = new ConnectionSQL();
                var resp = await cn.EjecutarConsultaJsonDirecto(db,query);
                if (resp == null)
                {
                    return "null";
                }

                return resp;
            }
            catch(Exception ex)
            {
                string erro = ex.Message;
                return "null";
            }
        }
    }
}
