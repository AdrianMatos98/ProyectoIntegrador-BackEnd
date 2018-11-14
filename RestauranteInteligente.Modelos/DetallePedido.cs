using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class DetallePedido
    {
        public int codigo { get; set; }
        public Platillo platillo { get; set; }        
        public decimal precio { get; set; }
        public int cantidad { get; set; }

        public void Validar()
        {
            if (platillo == null)
                throw new Exception("Platillo es requerido");
            if (cantidad == 0)
                throw new Exception("Cantidad es requerido");
            else if (cantidad <= 0)
                throw new Exception("La cantidad mínima es 1");
            if (precio == 0)
                throw new Exception("Precio es requerido");
            else if (precio < 0)
                throw new Exception("El mínimo precio aceptable es 1.00");
            else if (precio >=100000000)
                throw new Exception("El máximo precio aceptable es 99999999.99");
        }
    }
}
