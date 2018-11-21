using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class ReporteTopPlatillos
    {
        public int codigoPlatillo { get; set; }
        public String nombrePlatillo { get; set; }
        public decimal precioPlatillo { get; set; }
        public int cantidad { get; set; }
        public String descripcionCategoria { get; set; }
    }
}
