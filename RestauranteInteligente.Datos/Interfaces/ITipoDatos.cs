using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos.Interfaces
{
    public interface ITipoDatos
    {
        List<Tipo> ListarTipo(int estado);

        Tipo ListarTipoXId(int id);


        void AgregarTipo(Tipo tipo);

        void ActualizarTipo(Tipo tipo);


        void EliminarTipo(int id);

        void RestaurarTipo(int id);
    }
}
