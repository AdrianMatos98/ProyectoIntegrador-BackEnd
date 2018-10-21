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
        public List<Tipo> Listatipo()
        {
            return tipoNegocios.ListaTipo();

        }

        [HttpGet]
        public Tipo ListatipoXId(int id)
        {
            return tipoNegocios.ListaTipoXId(id);

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

        [HttpDelete]
        public string EliminarTipo(int id)
        {
            return tipoNegocios.EliminarTipo(id);

        }
    }
}
