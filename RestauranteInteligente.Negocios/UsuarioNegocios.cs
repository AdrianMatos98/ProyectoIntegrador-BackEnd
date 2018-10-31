using RestauranteInteligente.Datos;
using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Negocios
{
    public class UsuarioNegocios
    {
        private UsuarioDatos Datos;

        public UsuarioNegocios()
        {
            Datos = new UsuarioDatos();
        }

        public List<Usuario> ListarUsuarioXTipo(int estado,int tipo)
        {

            return Datos.ListarUsuarioXTipo(estado,tipo);
        }

        public Usuario ListarUsuarioXId(int id)
        {

            return Datos.ListarUsuarioXId(id);
        }

        public string AgregarUsuario(Usuario usuario)
        {
            string msj = "";
            try
            {
                usuario.Validar();
                Datos.AgregarUsuario(usuario);
                msj = "Usuario agregado";

            }
            catch (SqlException ex)
            {
                if(ex.Number == 2627)
                msj = "No se agrego el usuario : Ya existe un usuario con el mismo nombre";
            }
            catch (Exception ex)
            {
                msj = "No se agrego el usuario : " + ex.Message;
            }
            return msj;
        }

        public string ActualizarUsuario(Usuario usuario)
        {
            string msj = "";
            try
            {
                usuario.Validar();
                Datos.ActualizarUsuario(usuario);
                msj = "Usuario actualizado";

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    msj = "No se agrego el usuario : Ya existe un usuario con el mismo nombre";
            }
            catch (Exception ex)
            {
                msj = "No se actualizo el usuario : " + ex.Message;
            }
            return msj;
        }

        public string EliminarUsuario(int id)
        {
            string msj = "";
            try
            {
                Datos.EliminarUsuario(id);
                msj = "Usuario eliminado";

            }
            catch (Exception ex)
            {
                msj = "No se elimino el usuario : " + ex.Message;
            }
            return msj;
        }



        public string RestaurarUsuario(int id)
        {
            string msj = "";
            try
            {
                Datos.RestaurarUsuario(id);
                msj = "Usuario restaurado";

            }
            catch (Exception ex)
            {
                msj = "No se restauro el usuario : " + ex.Message;
            }
            return msj;
        }

        public Usuario Login(string nombre,string password)
        {

            return Datos.Login(nombre,password);
        }
    }
}
