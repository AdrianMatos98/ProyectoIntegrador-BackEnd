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
    public class TipoDatos : ITipoDatos
    {
        
        SqlConnection conexion;

        public TipoDatos()
        {
            conexion = new SqlConnection(Conexion.cadenaConexion);
        }

        public List<Tipo> ListarTipo(int estado)
        {
            List<Tipo> tipos = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarTipo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@estado", estado);

            SqlDataReader lector = cmd.ExecuteReader();
            
            if (lector.HasRows)
            {
                tipos = new List<Tipo>();
                while (lector.Read())
                {
                    var tipo = new Tipo();
                    tipo.codigo = int.Parse(lector["CODIGO_TIPO"].ToString());
                    tipo.descripcion = lector["DESCRIPCION_TIPO"].ToString();
                    tipo.estado = int.Parse(lector["ESTADO_TIPO"].ToString());
                    tipos.Add(tipo);
                }
            }

            conexion.Close();
            return tipos;
        }

        public Tipo ListarTipoXId(int id)
        {
            Tipo tipo = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarTipoXId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                tipo = new Tipo();
                while (lector.Read())
                {
                    tipo.codigo = int.Parse(lector["CODIGO_TIPO"].ToString());
                    tipo.descripcion = lector["DESCRIPCION_TIPO"].ToString();
                    tipo.estado = int.Parse(lector["ESTADO_TIPO"].ToString());
                }
            }

            conexion.Close();
            return tipo;
        }
        

        public void AgregarTipo(Tipo tipo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_AgregarTipo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@descripcion", tipo.descripcion);

            cmd.ExecuteNonQuery();
           
            conexion.Close();
        }

        public void ActualizarTipo(Tipo tipo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ActualizarTipo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", tipo.codigo);
            cmd.Parameters.AddWithValue("@descripcion", tipo.descripcion);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void EliminarTipo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_EliminarTipo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();
            
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void RestaurarTipo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_RestaurarTipo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
