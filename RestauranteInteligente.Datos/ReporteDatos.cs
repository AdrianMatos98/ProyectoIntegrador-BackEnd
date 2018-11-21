using RestauranteInteligente.Datos.Interfaces;
using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos
{
    public class ReporteDatos : IReporteDatos
    {
        SqlConnection conexion;


        public ReporteDatos()
        {
            conexion = new SqlConnection(Conexion.cadenaConexion);
        }


        public List<ReporteTopPlatillos> ListarPlatillosXFechas(DateTime fecha1, DateTime fecha2)
        {
            List<ReporteTopPlatillos> reportes = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarPlatillosXFechas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@fecha1", fecha1);
            cmd.Parameters.AddWithValue("@fecha2", fecha2);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                reportes = new List<ReporteTopPlatillos>();
                while (lector.Read())
                {
                    var reporte = new ReporteTopPlatillos();

                    reporte.codigoPlatillo = int.Parse(lector["CODIGO_PLATILLO"].ToString());
                    reporte.nombrePlatillo = lector["NOMBRE_PLATILLO"].ToString();
                    reporte.precioPlatillo = decimal.Parse(lector["PRECIO_PLATILLO"].ToString());
                    reporte.cantidad = int.Parse(lector["CANTIDAD"].ToString());
                    reporte.descripcionCategoria = lector["DESCRIPCION_CATEGORIA"].ToString();

                    reportes.Add(reporte);
                }
            }

            conexion.Close();
            return reportes;
        }
    }
}
