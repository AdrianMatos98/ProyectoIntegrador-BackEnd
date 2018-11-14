using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteInteligente.Models
{
    public class ValidarPagoRequest
    {
        public string NumeroTarjeta { get; set; }
        public int TipoTarjeta { get; set; }
        public string CodigoSeguridadTarjeta { get; set; }
        public string TitularTarjeta { get; set; }
        public string MesExpiracionTarjeta { get; set; }
        public string AñoExpiracionTarjeta { get; set; }
        public double MontoConsumir { get; set; }
    }
}