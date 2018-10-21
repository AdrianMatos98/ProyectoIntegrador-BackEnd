using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class Tipo
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(descripcion))
                throw new Exception("Descripcion es requerido");
            else if(descripcion.Length>25)
                throw new Exception("Descripción tiene un máximo de 25 caracteres");
        }
    }
}
