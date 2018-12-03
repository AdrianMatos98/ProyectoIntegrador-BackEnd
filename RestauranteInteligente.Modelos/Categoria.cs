using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class Categoria
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
        public string imagen { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(descripcion))
                throw new Exception("Descripcion es requerido");
            else if (descripcion.Length > 25)
                throw new Exception("Descripción tiene un máximo de 25 caracteres");
            if (string.IsNullOrEmpty(imagen))
                throw new Exception("Imagen es requerido");
            else if (imagen.Length > 500)
                throw new Exception("Imagen tiene un máximo de 500 caracteres");
        }
    }
}
