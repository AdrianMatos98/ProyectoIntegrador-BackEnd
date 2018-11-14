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
    public class PlatilloDatos : IPlatilloDatos
    {
        SqlConnection conexion;

        public PlatilloDatos()
        {
            conexion = new SqlConnection(Conexion.cadenaConexion);
        }

        public List<Platillo> ListarPlatilloXCategoria_Nombre(int estado, int categoria,string nombre)
        {
            List<Platillo> platillos = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarPlatilloXCategoria_Nombre";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@categoria", categoria);
            cmd.Parameters.AddWithValue("@nombre", nombre);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                platillos = new List<Platillo>();
                while (lector.Read())
                {
                    var platillo = new Platillo();
                    var _categoria = new Categoria();
                    platillo.codigo = int.Parse(lector["CODIGO_PLATILLO"].ToString());
                    platillo.nombre = lector["NOMBRE_PLATILLO"].ToString();
                    platillo.descripcion = lector["DESCRIPCION_PLATILLO"].ToString();
                    platillo.precio = decimal.Parse(lector["PRECIO_PLATILLO"].ToString());
                    platillo.estado = int.Parse(lector["ESTADO_PLATILLO"].ToString());
                    _categoria.descripcion = lector["DESCRIPCION_CATEGORIA"].ToString();
                    platillo.categoria = _categoria;
                    platillos.Add(platillo);
                }
            }

            conexion.Close();
            return platillos;
        }


        public Platillo ListarPlatilloXId(int id)
        {
            Platillo platillo = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarPlatilloXId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                platillo = new Platillo();
                var _categoria = new Categoria();
                while (lector.Read())
                {

                    platillo.codigo = int.Parse(lector["CODIGO_PLATILLO"].ToString());
                    platillo.nombre = lector["NOMBRE_PLATILLO"].ToString();
                    platillo.descripcion = lector["DESCRIPCION_PLATILLO"].ToString();
                    platillo.precio = decimal.Parse(lector["PRECIO_PLATILLO"].ToString());
                    platillo.estado = int.Parse(lector["ESTADO_PLATILLO"].ToString());
                    platillo.imagen = lector["IMAGEN_PLATILLO"].ToString();
                    _categoria.codigo = int.Parse(lector["CODIGO_CATEGORIA"].ToString());
                    _categoria.descripcion = lector["DESCRIPCION_CATEGORIA"].ToString();
                    platillo.categoria = _categoria;
                }
            }

            conexion.Close();
            return platillo;
        }


        public void AgregarPlatillo(Platillo platillo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_AgregarPlatillo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@nombre", platillo.nombre);
            cmd.Parameters.AddWithValue("@descripcion", platillo.descripcion);
            cmd.Parameters.AddWithValue("@precio", platillo.precio);
            cmd.Parameters.AddWithValue("@categoria", platillo.categoria.codigo);
            cmd.Parameters.AddWithValue("@imagen", platillo.imagen);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void ActualizarPlatillo(Platillo platillo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ActualizarPlatillo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", platillo.codigo);
            cmd.Parameters.AddWithValue("@nombre", platillo.nombre);
            cmd.Parameters.AddWithValue("@descripcion", platillo.descripcion);
            cmd.Parameters.AddWithValue("@precio", platillo.precio);
            cmd.Parameters.AddWithValue("@categoria", platillo.categoria.codigo);
            cmd.Parameters.AddWithValue("@imagen", platillo.imagen);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void EliminarPlatillo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_EliminarPlatillo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void RestaurarPlatillo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_RestaurarPlatillo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
