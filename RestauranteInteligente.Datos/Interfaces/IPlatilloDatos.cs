using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos.Interfaces
{
    public interface IPlatilloDatos
    {

        List<Platillo> ListarPlatilloXCategoria_Nombre(int estado, int categoria, string nombre);

        Platillo ListarPlatilloXId(int id);


        void AgregarPlatillo(Platillo platillo);

        void ActualizarPlatillo(Platillo platillo);

        void EliminarPlatillo(int id);

        void RestaurarPlatillo(int id);


    }

}
