using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class Platillo
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int estado { get; set; }
        public Categoria categoria { get; set; }
        public string imagen { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("Nombre es requerido");
            else if (nombre.Length > 25)
                throw new Exception("Nombre tiene un máximo de 25 caracteres");
            if (string.IsNullOrEmpty(descripcion))
                throw new Exception("Descripción es requerido");
            else if (descripcion.Length > 500)
                throw new Exception("Descripción tiene un máximo de 500 caracteres");
            if (precio==0)
                throw new Exception("Precio es requerido");
            else if (precio < 0)
                throw new Exception("El mínimo precio aceptable es 1.00");
            else if (precio>=100000000)
                throw new Exception("El máximo precio aceptable es 99999999.99");
            if (categoria.codigo == 0)
                throw new Exception("Categoria es requerido");
            if (string.IsNullOrEmpty(imagen))
                throw new Exception("Imagen es requerido");
            else if(imagen.Length>500)
                throw new Exception("Imagen tiene un máximo de 500 caracteres");
        }
    }
}
