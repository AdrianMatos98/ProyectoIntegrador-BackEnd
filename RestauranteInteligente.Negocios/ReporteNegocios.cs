using RestauranteInteligente.Datos;
using RestauranteInteligente.Datos.Interfaces;
using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Negocios
{
    public class ReporteNegocios
    {
        private IReporteDatos Datos;

        public ReporteNegocios()
        {
            Datos = new ReporteDatos();
        }



        public List<ReporteTopPlatillos> ListarPlatillosXFechas(DateTime fecha1, DateTime fecha2)
        {

            return Datos.ListarPlatillosXFechas(fecha1, fecha2);
        }
    }
}
