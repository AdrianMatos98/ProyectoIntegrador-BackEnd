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

        public void Validar()
        {
            if (TipoTarjeta == 0)
                throw new Exception("Tipo de tarjeta es requerido");
            if (string.IsNullOrEmpty(NumeroTarjeta))
                throw new Exception("Numero de tarjeta es requerido");
            else if (NumeroTarjeta.Length != 16)
                throw new Exception("Numero de tarjeta debe tener 16 caracteres");
            if (string.IsNullOrEmpty(CodigoSeguridadTarjeta))
                throw new Exception("CVV es requerido");
            else if (CodigoSeguridadTarjeta.Length != 3)
                throw new Exception("CVV debe tener 3 caracteres");
            if (string.IsNullOrEmpty(TitularTarjeta))
                throw new Exception("Titular de la tarjeta es requerido");
            else if (TitularTarjeta.Length > 50)
                throw new Exception("Titular de la tarjeta tiene un máximo de 50 caracteres");
            if (string.IsNullOrEmpty(MesExpiracionTarjeta))
                throw new Exception("Mes de expiracion es requerido");
            else if (MesExpiracionTarjeta.Length != 2)
                throw new Exception("Mes de expiracion debe tener 2 caracteres");
            if (string.IsNullOrEmpty(AñoExpiracionTarjeta))
                throw new Exception("Año de expiracion es requerido");
            else if (AñoExpiracionTarjeta.Length != 4)
                throw new Exception("Año de expiracion debe tener 4 caracteres");
            if (MontoConsumir == 0)
                throw new Exception("Monto a consumir es requerido");
        }
    }
}