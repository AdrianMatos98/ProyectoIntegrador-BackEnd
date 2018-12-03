using RestauranteInteligente.Datos.Interfaces;
using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos
{
    public class PedidoDatos : IPedidoDatos
    {
        SqlConnection conexion;

        public PedidoDatos()
        {
            conexion = new SqlConnection(Conexion.cadenaConexion);
        }

        public string AgregarPedido(Pedido pedido)
        {
            using (conexion)
            {
                conexion.Open();
                
                SqlTransaction sqlTran = conexion.BeginTransaction();

                SqlCommand cmd = conexion.CreateCommand();
                cmd.Transaction = sqlTran;

                try
                {
                    cmd.CommandText = "sp_AgregarPedido";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuario", pedido.usuario.codigo);
                    cmd.Parameters.AddWithValue("@total", pedido.total);

                    SqlDataReader lector = cmd.ExecuteReader();
                    var codigoPedido = 0;
                    if (lector.HasRows)
                    {
                        
                        while (lector.Read())
                        {
                            codigoPedido = int.Parse(lector["CODIGO_PEDIDO"].ToString());
                        }
                    }
                    lector.Close();
                    foreach (var dp in pedido.detallePedido)
                    {
                        SqlCommand cmd2 = conexion.CreateCommand();
                        cmd2.Transaction = sqlTran;

                        cmd2.CommandText = "sp_AgregarDetallePedido";
                        cmd2.CommandType = CommandType.StoredProcedure;

                        cmd2.Parameters.AddWithValue("@pedido", codigoPedido);
                        cmd2.Parameters.AddWithValue("@platillo", dp.platillo.codigo);
                        cmd2.Parameters.AddWithValue("@precio", dp.precio);
                        cmd2.Parameters.AddWithValue("@cantidad", dp.cantidad);


                        cmd2.ExecuteNonQuery();

                    }
                    
                    sqlTran.Commit();
                    return ""+codigoPedido;
                }
                catch (Exception ex)
                {

                    try
                    {
                        sqlTran.Rollback();
                        return ex.Message;
                    }
                    catch (Exception exRollback)
                    {
                        
                        return exRollback.Message;
                    }
                }
            }

        }

        public List<Pedido> ListarPedidoXEstado(int estado)
        {
            List<Pedido> pedidos = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarPedidosXEstado";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@estado", estado);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                pedidos = new List<Pedido>();
                while (lector.Read())
                {
                    var pedido = new Pedido();
                    var _usuario = new Usuario();
                    pedido.codigo = int.Parse(lector["CODIGO_PEDIDO"].ToString());
                    _usuario.codigo = int.Parse(lector["CODIGO_USUARIO"].ToString());
                    _usuario.nombre = lector["NOMBRE_USUARIO"].ToString();
                    pedido.usuario = _usuario;
                    pedido.estado = int.Parse(lector["ESTADO_PEDIDO"].ToString());
                    pedido.fecha = DateTime.Parse(lector["FECHA_PEDIDO"].ToString());
                    pedido.total = decimal.Parse(lector["TOTAL_PEDIDO"].ToString());
                    pedido.detallePedido = new List<DetallePedido>();
                    pedidos.Add(pedido);
                }
            }

            conexion.Close();
            return pedidos;
        }

        public List<DetallePedido> ListarDetallePedido(int pedido)
        {
            List<DetallePedido> detallePedidos = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarDetallePedido";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@pedido", pedido);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                detallePedidos = new List<DetallePedido>();
                while (lector.Read())
                {
                    var detallePedido = new DetallePedido();
                    var _platillo = new Platillo();
                    var _categoria = new Categoria();
                    detallePedido.codigo = int.Parse(lector["CODIGO_PEDIDO"].ToString());
                    _platillo.codigo = int.Parse(lector["CODIGO_PLATILLO"].ToString());
                    _platillo.nombre = lector["NOMBRE_PLATILLO"].ToString();
                    _categoria.codigo = int.Parse(lector["CODIGO_CATEGORIA"].ToString());
                    _categoria.descripcion = lector["DESCRIPCION_CATEGORIA"].ToString();
                    _platillo.categoria = _categoria;
                    detallePedido.platillo = _platillo;
                    detallePedido.precio = decimal.Parse(lector["PRECIO"].ToString());
                    detallePedido.cantidad = int.Parse(lector["CANTIDAD"].ToString());
                    detallePedidos.Add(detallePedido);
                }
            }

            conexion.Close();
            return detallePedidos;
        }

        public void ActualizarEstadoPedido(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ActualizarEstadoPedido";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", codigo);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public TarjetaInfo ObtenerInformacionTarjeta(int tipoTarjeta, string numeroTarjeta, string titularTarjeta, string mesExpiracion, string añoExpiracion, string codigoSeguridad)
        {
            TarjetaInfo tarjetaInfo = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_GetTarjetaByInfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();
            //declarar los parametros del procedure
            cmd.Parameters.AddWithValue("@idTipoTarjeta", tipoTarjeta);
            cmd.Parameters.AddWithValue("@numeroTarjeta", numeroTarjeta);
            cmd.Parameters.AddWithValue("@nombreTarjeta", titularTarjeta);
            cmd.Parameters.AddWithValue("@securityCodeTarjeta", codigoSeguridad);
            cmd.Parameters.AddWithValue("@mesExpiracionTarjeta", mesExpiracion);
            cmd.Parameters.AddWithValue("@añoExpiracionTarjeta", añoExpiracion);

            SqlDataReader reader = cmd.ExecuteReader();
            //verificar que tenga filas
            if (reader.HasRows)
            {
                tarjetaInfo = new TarjetaInfo();
                //leer el registro
                while (reader.Read())
                {
                    tarjetaInfo.titularTarjeta = reader["NOMBRE_TARJETA"].ToString();
                    tarjetaInfo.numeroTarjeta = reader["NUMERO_TARJETA"].ToString();
                    tarjetaInfo.tarjetaHabilitada = bool.Parse(reader["TARJETA_HABILITADA"].ToString());
                    tarjetaInfo.creditoDisponible = double.Parse(reader["CREDITO_DISPONIBLE"].ToString());
                }
            }

            //cerrar conexion
            conexion.Close();

            return tarjetaInfo;
        }
    }
}
