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
    public class UsuarioController : ApiController
    {
        private UsuarioNegocios usuarioNegocios;

        public UsuarioController()
        {
            usuarioNegocios = new UsuarioNegocios();
        }

        [HttpGet]
        public List<Usuario> ListarUsuarioXTipo(int estado,int tipo)
        {
            return usuarioNegocios.ListarUsuarioXTipo(estado, tipo);

        }

        [HttpGet]
        public Usuario ListarUsuarioXId(int id)
        {
            return usuarioNegocios.ListarUsuarioXId(id);

        }

        [HttpPost]
        public string AgregarUsuario(Usuario usuario)
        {
            return usuarioNegocios.AgregarUsuario(usuario);

        }

        [HttpPut]
        public string ActualizarUsuario(Usuario usuario)
        {
            return usuarioNegocios.ActualizarUsuario(usuario);

        }

        [HttpPut]
        public string EliminarUsuario(int id)
        {
            return usuarioNegocios.EliminarUsuario(id);

        }

        [HttpPut]
        public string RestaurarUsuario(int id)
        {
            return usuarioNegocios.RestaurarUsuario(id);

        }
    }
}
