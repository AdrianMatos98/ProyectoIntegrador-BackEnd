using RestauranteInteligente.Modelos;
using RestauranteInteligente.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestauranteInteligente.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReporteController : ApiController
    {

        private ReporteNegocios reporteNegocios;

        public ReporteController()
        {
            reporteNegocios = new ReporteNegocios();
        }



        [HttpGet]
        public List<ReporteTopPlatillos> ListarPlatillosXFechas(DateTime fecha1, DateTime fecha2)
        {
            return reporteNegocios.ListarPlatillosXFechas(fecha1, fecha2);

        }
    }
}
