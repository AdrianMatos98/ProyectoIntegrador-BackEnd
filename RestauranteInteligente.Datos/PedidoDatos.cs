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
    public class PedidoDatos
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
                    return "";
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
    }
}
