using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos.Interfaces
{
    public interface IUsuarioDatos
    {


        List<Usuario> ListarUsuarioXTipo(int estado, int tipo);

        Usuario ListarUsuarioXId(int id);

        void AgregarUsuario(Usuario usuario);

        void ActualizarUsuario(Usuario usuario);

        void EliminarUsuario(int id);

        void RestaurarUsuario(int id);

        Usuario Login(string nombre, string password);
    }
}
