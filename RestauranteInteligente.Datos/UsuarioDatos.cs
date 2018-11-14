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
    public class UsuarioDatos : IUsuarioDatos
    {
        SqlConnection conexion;

        public UsuarioDatos()
        {
            conexion = new SqlConnection(Conexion.cadenaConexion);
        }

        public List<Usuario> ListarUsuarioXTipo(int estado,int tipo)
        {
            List<Usuario> usuarios = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarUsuarioXTipo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@tipo", tipo);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                usuarios = new List<Usuario>();
                while (lector.Read())
                {
                    var usuario = new Usuario();
                    var _tipo = new Tipo();
                    usuario.codigo = int.Parse(lector["CODIGO_USUARIO"].ToString());
                    usuario.nombre = lector["NOMBRE_USUARIO"].ToString();
                    usuario.estado = int.Parse(lector["ESTADO_USUARIO"].ToString());
                    _tipo.descripcion = lector["DESCRIPCION_TIPO"].ToString();
                    usuario.tipo = _tipo;
                    usuarios.Add(usuario);
                }
            }

            conexion.Close();
            return usuarios;
        }

        public Usuario ListarUsuarioXId(int id)
        {
            Usuario usuario = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarUsuarioXId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                usuario = new Usuario();
                var _tipo = new Tipo();
                while (lector.Read())
                {
                    
                    usuario.codigo = int.Parse(lector["CODIGO_USUARIO"].ToString());
                    usuario.nombre = lector["NOMBRE_USUARIO"].ToString();
                    usuario.estado = int.Parse(lector["ESTADO_USUARIO"].ToString());
                    _tipo.codigo = int.Parse(lector["CODIGO_TIPO"].ToString());
                    _tipo.descripcion = lector["DESCRIPCION_TIPO"].ToString();
                    usuario.tipo = _tipo;
                }
            }

            conexion.Close();
            return usuario;
        }


        public void AgregarUsuario(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_AgregarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
            cmd.Parameters.AddWithValue("@password", usuario.password);
            cmd.Parameters.AddWithValue("@tipo", usuario.tipo.codigo);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ActualizarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", usuario.codigo);
            cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
            cmd.Parameters.AddWithValue("@password", usuario.password);
            cmd.Parameters.AddWithValue("@tipo", usuario.tipo.codigo);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void EliminarUsuario(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_EliminarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void RestaurarUsuario(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_RestaurarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public Usuario Login(string nombre, string password)
        {

            Usuario usuario = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_Login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                usuario = new Usuario();
                var _tipo = new Tipo();
                while (lector.Read())
                {

                    usuario.codigo = int.Parse(lector["CODIGO_USUARIO"].ToString());
                    usuario.nombre = lector["NOMBRE_USUARIO"].ToString();
                    usuario.estado = int.Parse(lector["ESTADO_USUARIO"].ToString());
                    _tipo.codigo = int.Parse(lector["CODIGO_TIPO"].ToString());
                    _tipo.descripcion = lector["DESCRIPCION_TIPO"].ToString();
                    usuario.tipo = _tipo;
                }
            }

            conexion.Close();
            return usuario;
        }
    }
}
