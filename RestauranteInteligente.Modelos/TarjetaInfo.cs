using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class TarjetaInfo
    {
        public string numeroTarjeta { get; set; }
        public string titularTarjeta { get; set; }
        public bool tarjetaHabilitada { get; set; }
        public double creditoDisponible { get; set; }
    }
}
