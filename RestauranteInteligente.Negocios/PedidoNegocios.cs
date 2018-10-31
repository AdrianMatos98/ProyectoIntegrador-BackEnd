using RestauranteInteligente.Datos;
using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Negocios
{
    public class PedidoNegocios
    {
        private PedidoDatos Datos;

        public PedidoNegocios()
        {
            Datos = new PedidoDatos();
        }

        public string AgregarPedido(Pedido pedido)
        {
            string msj = "";
            try
            {
                pedido.Validar();

                foreach (var dp in pedido.detallePedido)
                {
                    dp.Validar();
                }
                string res = Datos.AgregarPedido(pedido);
                if (res.Equals(""))
                {
                    msj = "Pedido agregado";
                }
                else
                {
                    msj = "No se agrego el pedido : " + res;
                }

            }
            catch (Exception ex)
            {
                msj = "No se agrego el pedido : " + ex.Message;
            }
            return msj;
        }
    }
}
