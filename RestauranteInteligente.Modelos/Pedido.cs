using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class Pedido
    {
        public int codigo { get; set; }
        public Usuario usuario { get; set; }
        public DateTime fecha { get; set; }
        public int estado { get; set; }
        public decimal total { get; set; }
        public List<DetallePedido> detallePedido { get; set; }
        

        public void Validar()
        {
            if (fecha==null)
                throw new Exception("Fecha es requerido");
            if (usuario == null)
                throw new Exception("Usuario es requerido");
            if (total== 0)
                throw new Exception("Total es requerido");
        }
          
    }
}
