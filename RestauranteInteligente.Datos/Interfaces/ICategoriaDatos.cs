using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos.Interfaces
{
    public interface ICategoriaDatos
    {
        List<Categoria> ListarCategoria(int estado);

        Categoria ListarCategoriaXId(int id);


        void AgregarCategoria(Categoria categoria);

        void ActualizarCategoria(Categoria categoria);

        void EliminarCategoria(int id);

        void RestaurarCategoria(int id);
    }
}
