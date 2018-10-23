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
    public class TipoController : ApiController
    {
        private TipoNegocios tipoNegocios;

        public TipoController()
        {
            tipoNegocios = new TipoNegocios();
        }

        [HttpGet]
        public List<Tipo> ListarTipo(int estado)
        {
            return tipoNegocios.ListarTipo(estado);

        }

        [HttpGet]
        public Tipo ListarTipoXId(int id)
        {
            return tipoNegocios.ListarTipoXId(id);

        }

        [HttpPost]
        public string AgregarTipo(Tipo tipo)
        {
            return tipoNegocios.AgregarTipo(tipo);

        }

        [HttpPut]
        public string ActualizarTipo(Tipo tipo)
        {
            return tipoNegocios.ActualizarTipo(tipo);

        }

        [HttpPut]
        public string EliminarTipo(int id)
        {
            return tipoNegocios.EliminarTipo(id);

        }

        [HttpPut]
        public string RestaurarTipo(int id)
        {
            return tipoNegocios.RestaurarTipo(id);

        }
    }
}
