using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos.Interfaces
{
    public interface IPedidoDatos
    {

        string AgregarPedido(Pedido pedido);

        List<Pedido> ListarPedidoXEstado(int estado);

        List<DetallePedido> ListarDetallePedido(int pedido);

        List<Pedido> ListarPedidoXFechas(DateTime fecha1, DateTime fecha2);

        void ActualizarEstadoPedido(int codigo);

        TarjetaInfo ObtenerInformacionTarjeta(int tipoTarjeta, string numeroTarjeta, string titularTarjeta, string mesExpiracion, string añoExpiracion, string codigoSeguridad);
    }
}
