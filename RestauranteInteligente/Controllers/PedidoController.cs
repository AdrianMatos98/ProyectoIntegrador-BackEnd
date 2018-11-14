using RestauranteInteligente.Modelos;
using RestauranteInteligente.Models;
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

        [HttpGet]
        public List<Pedido> ListarPedidoXEstado(int estado)
        {
            return pedidoNegocios.ListarPedidoXEstado(estado);

        }

        [HttpGet]
        public List<DetallePedido> ListarDetallePedido(int pedido)
        {
            return pedidoNegocios.ListarDetallePedido(pedido);

        }

        [HttpGet]
        public List<Pedido> ListarPedidoXFechas(DateTime fecha1, DateTime fecha2)
        {
            return pedidoNegocios.ListarPedidoXFechas(fecha1,fecha2);

        }

        [HttpPut]
        public string ActualizarEstadoPedido(int id)
        {
            return pedidoNegocios.ActualizarEstadoPedido(id);

        }

        [HttpPost]
        public ValidarPagoResponse ValidarPago(ValidarPagoRequest request)
        {
            ValidarPagoResponse response = new ValidarPagoResponse();
            string mensaje = "";

            try
            {
                request.Validar();

                response.TransaccionCompleta = pedidoNegocios.ValidarPago(out mensaje,
                                        request.TipoTarjeta, request.NumeroTarjeta,
                                        request.TitularTarjeta, request.MontoConsumir,
                                        request.MesExpiracionTarjeta, request.AñoExpiracionTarjeta,
                                        request.CodigoSeguridadTarjeta);
                response.TransaccionMensaje = mensaje;

                return response;

            }
            catch (Exception ex)
            {
                response.TransaccionCompleta = false;
                response.TransaccionMensaje = ex.Message;
                return response;
            }
        }

    }
}
