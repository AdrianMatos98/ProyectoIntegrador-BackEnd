using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos.Interfaces
{
    public interface IReporteDatos
    {

        List<ReporteTopPlatillos> ListarPlatillosXFechas(DateTime fecha1, DateTime fecha2);

    }
}
