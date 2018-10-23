using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class Usuario
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public int estado { get; set; }
        public Tipo tipo { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("Nombre es requerido");
            else if (nombre.Length > 25)
                throw new Exception("Nombre tiene un máximo de 25 caracteres");
            if (string.IsNullOrEmpty(password))
                throw new Exception("Contraseña es requerida");
            else if (password.Length !=8 )
                throw new Exception("Contraseña debe tener 8 caracteres");
            if (tipo.codigo == 0)
                throw new Exception("Tipo es requerido");
        }
    }
}
