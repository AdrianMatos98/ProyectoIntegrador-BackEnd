using RestauranteInteligente.Datos;
using RestauranteInteligente.Datos.Interfaces;
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
        private IPedidoDatos Datos;

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

        public List<Pedido> ListarPedidoXEstado(int estado)
        {

            return Datos.ListarPedidoXEstado(estado);
        }

        public List<DetallePedido> ListarDetallePedido(int pedido)
        {

            return Datos.ListarDetallePedido(pedido);
        }

        public string ActualizarEstadoPedido(int codigo)
        {
            string msj = "";
            try
            {
                Datos.ActualizarEstadoPedido(codigo);
                msj = "Pedido actualizado";

            }
            catch (Exception ex)
            {
                msj = "No se actualizo el pedido : " + ex.Message;
            }
            return msj;
        }

        public bool ValidarPago(out string mensaje,
                                int tipoTarjeta,
                                string numeroTarjeta,
                                string titularTarjeta,
                                double montoConsumir,
                                string mesExpiracion,
                                string añoExpiracion,
                                string codigoSeguridad
                                )
        {
            bool ValidacionCorrecta = false;
            mensaje = "";



            //verificar que la tarjeta exista

            //llamar a la capa de datos
            TarjetaInfo tarjetaInfo = Datos.ObtenerInformacionTarjeta(tipoTarjeta, numeroTarjeta, titularTarjeta,
                                                    mesExpiracion, añoExpiracion, codigoSeguridad);

            //validar que la tarjeta exista
            if (tarjetaInfo == null)
            {
                mensaje = "Tarjeta no Existe";
            }
            //la tarjeta existe
            else
            {
                //validar que la tarjeta este habilitada
                if (!tarjetaInfo.tarjetaHabilitada)
                {
                    mensaje = "Tarjeta No Habilitada";
                }
                //si la tarjeta no esta deshabilitada
                else
                {
                    // disponible : 99 , monto : 100
                    if (tarjetaInfo.creditoDisponible < montoConsumir)
                    {
                        mensaje = "Linea de credito insuficiente";
                    }
                    else
                    {
                        ValidacionCorrecta = true;
                    }
                }
            }

            return ValidacionCorrecta;
        }
    }
}
