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
    public class CategoriaController : ApiController
    {
        private CategoriaNegocios categoriaNegocios;

        public CategoriaController()
        {
            categoriaNegocios = new CategoriaNegocios();
        }

        [HttpGet]
        public List<Categoria> ListarCategoria(int estado)
        {
            return categoriaNegocios.ListarCategoria(estado);

        }

        [HttpGet]
        public Categoria ListarCategoriaXId(int id)
        {
            return categoriaNegocios.ListarCategoriaXId(id);

        }

        [HttpPost]
        public string AgregarCategoria(Categoria categoria)
        {
            return categoriaNegocios.AgregarCategoria(categoria);

        }

        [HttpPut]
        public string ActualizarCategoria(Categoria categoria)
        {
            return categoriaNegocios.ActualizarCategoria(categoria);

        }

        [HttpPut]
        public string EliminarCategoria(int id)
        {
            return categoriaNegocios.EliminarCategoria(id);

        }

        [HttpPut]
        public string RestaurarCategoria(int id)
        {
            return categoriaNegocios.RestaurarCategoria(id);

        }
    }
}
