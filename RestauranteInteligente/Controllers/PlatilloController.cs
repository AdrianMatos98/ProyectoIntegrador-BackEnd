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
    public class PlatilloController : ApiController
    {
        private PlatilloNegocios platilloNegocios;

        public PlatilloController()
        {
            platilloNegocios = new PlatilloNegocios();
        }
        

        [HttpGet]
        public List<Platillo> ListarPlatilloXCategoria_Nombre(int estado, int categoria,string nombre)
        {
            return platilloNegocios.ListarPlatilloXCategoria_Nombre(estado, categoria, nombre);

        }

        [HttpGet]
        public Platillo ListarPlatilloXId(int id)
        {
            return platilloNegocios.ListarPlatilloXId(id);

        }

        [HttpPost]
        public string AgregarPlatillo(Platillo platillo)
        {
            return platilloNegocios.AgregarPlatillo(platillo);

        }

        [HttpPut]
        public string ActualizarPlatillo(Platillo platillo)
        {
            return platilloNegocios.ActualizarPlatillo(platillo);

        }

        [HttpPut]
        public string EliminarPlatillo(int id)
        {
            return platilloNegocios.EliminarPlatillo(id);

        }

        [HttpPut]
        public string RestaurarPlatillo(int id)
        {
            return platilloNegocios.RestaurarPlatillo(id);

        }
        
    }
}
