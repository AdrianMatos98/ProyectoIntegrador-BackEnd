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
    public class PedidoController : ApiController
    {
        private PedidoNegocios pedidoNegocios;

        public PedidoController()
        {
            pedidoNegocios = new PedidoNegocios();
        }

        [HttpPost]
        public string AgregarPedido(Pedido pedido)
        {
            return pedidoNegocios.AgregarPedido(pedido);

        }
    }
}
