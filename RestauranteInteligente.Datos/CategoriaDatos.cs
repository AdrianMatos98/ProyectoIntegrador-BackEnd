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
    public class CategoriaDatos : ICategoriaDatos
    {
        SqlConnection conexion;

        public CategoriaDatos()
        {
            conexion = new SqlConnection(Conexion.cadenaConexion);
        }

        public List<Categoria> ListarCategoria(int estado)
        {
            List<Categoria> tipos = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@estado", estado);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                tipos = new List<Categoria>();
                while (lector.Read())
                {
                    var categoria = new Categoria();
                    categoria.codigo = int.Parse(lector["CODIGO_CATEGORIA"].ToString());
                    categoria.descripcion = lector["DESCRIPCION_CATEGORIA"].ToString();
                    categoria.estado = int.Parse(lector["ESTADO_CATEGORIA"].ToString());
                    categoria.imagen = lector["IMAGEN_CATEGORIA"].ToString();
                    tipos.Add(categoria);
                }
            }

            conexion.Close();
            return tipos;
        }

        public Categoria ListarCategoriaXId(int id)
        {
            Categoria categoria = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarCategoriaXId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                categoria = new Categoria();
                while (lector.Read())
                {
                    categoria.codigo = int.Parse(lector["CODIGO_CATEGORIA"].ToString());
                    categoria.descripcion = lector["DESCRIPCION_CATEGORIA"].ToString();
                    categoria.estado = int.Parse(lector["ESTADO_CATEGORIA"].ToString());
                    categoria.imagen = lector["IMAGEN_CATEGORIA"].ToString();
                }
            }

            conexion.Close();
            return categoria;
        }


        public void AgregarCategoria(Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_AgregarCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@descripcion", categoria.descripcion);
            cmd.Parameters.AddWithValue("@imagen", categoria.imagen);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ActualizarCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", categoria.codigo);
            cmd.Parameters.AddWithValue("@descripcion", categoria.descripcion);
            cmd.Parameters.AddWithValue("@imagen", categoria.imagen);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void EliminarCategoria(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_EliminarCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void RestaurarCategoria(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_RestaurarCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
