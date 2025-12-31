using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionSQL
    {
        public static string connectionString = string.Empty;

        public static void ConexionBase(string db)
        {
            connectionString =
                $"data source=.;initial catalog={db};user id=emilianop;password=Ser1ns1s@2020*;Connect Timeout=30;TrustServerCertificate=True;";
            //connectionString =
            //    $"data source=51.222.245.217;initial catalog={db};user id=emilianop;password=Ser1ns1s@2020*;Connect Timeout=30;TrustServerCertificate=True;";
        }

        // ================================
        // CONSULTA NORMAL (DataTable)
        // ================================
        public async Task<string> EjecutarConsulta(string db, string consulta, [Optional] bool lista_)
        {
            try
            {
                ConexionBase(db);

                string respuesta = null;

                using (var conexion = new SqlConnection(connectionString))
                {
                    await conexion.OpenAsync();

                    using (var cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        // 🔑 CLAVE PARA EVITAR TIMEOUT (30s por defecto)
                        cmd.CommandTimeout = 180; // 3 minutos (ajusta si necesitas más)

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            // 👉 SI NO HAY FILAS → NULL (como antes)
                            if (dt.Rows.Count == 0)
                                return null;

                            var listaDatos = new List<Dictionary<string, object>>();

                            foreach (DataRow row in dt.Rows)
                            {
                                var dict = new Dictionary<string, object>();

                                foreach (DataColumn col in dt.Columns)
                                {
                                    dict[col.ColumnName] =
                                        row[col] == DBNull.Value ? null : row[col];
                                }

                                listaDatos.Add(dict);
                            }

                            // JSON lista
                            respuesta = JsonSerializer.Serialize(
                                listaDatos,
                                new JsonSerializerOptions { WriteIndented = true }
                            );

                            // 👉 Si no es lista, devolver SOLO el primer objeto
                            if (lista_ == false)
                            {
                                var first = listaDatos.FirstOrDefault();
                                if (first == null)
                                    return null;

                                respuesta = JsonSerializer.Serialize(
                                    first,
                                    new JsonSerializerOptions { WriteIndented = true }
                                );
                            }
                        }
                    }
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null; // ✅ MISMO COMPORTAMIENTO ORIGINAL
            }
        }

        // ================================
        // CONSULTA QUE YA DEVUELVE JSON
        // ================================
        public async Task<string> EjecutarConsultaJsonDirecto(string db, string consulta)
        {
            try
            {
                ConexionBase(db);

                using (var conexion = new SqlConnection(connectionString))
                {
                    await conexion.OpenAsync();

                    using (var cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        // 🔑 Timeout para consultas largas
                        cmd.CommandTimeout = 180;

                        var result = await cmd.ExecuteScalarAsync();

                        // 👉 Si SQL no devuelve nada → NULL
                        if (result == null || result == DBNull.Value)
                            return null;

                        return result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
