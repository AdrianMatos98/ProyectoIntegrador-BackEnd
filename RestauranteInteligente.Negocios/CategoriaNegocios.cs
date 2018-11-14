using RestauranteInteligente.Datos;
using RestauranteInteligente.Datos.Interfaces;
using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Negocios
{
    public class CategoriaNegocios
    {
        private ICategoriaDatos Datos;

        public CategoriaNegocios()
        {
            Datos = new CategoriaDatos();
        }

        public List<Categoria> ListarCategoria(int estado)
        {

            return Datos.ListarCategoria(estado);
        }

        public Categoria ListarCategoriaXId(int id)
        {

            return Datos.ListarCategoriaXId(id);
        }

        public string AgregarCategoria(Categoria categoria)
        {
            string msj = "";
            try
            {
                categoria.Validar();
                Datos.AgregarCategoria(categoria);
                msj = "Categoria agregada";

            }
            catch (Exception ex)
            {
                msj = "No se agrego la categoria : " + ex.Message;
            }
            return msj;
        }


        public string ActualizarCategoria(Categoria categoria)
        {
            string msj = "";
            try
            {
                categoria.Validar();
                Datos.ActualizarCategoria(categoria);
                msj = "Categoria actualizada";

            }
            catch (Exception ex)
            {
                msj = "No se actualizo la categoria : " + ex.Message;
            }
            return msj;
        }


        public string EliminarCategoria(int id)
        {
            string msj = "";
            try
            {
                Datos.EliminarCategoria(id);
                msj = "Categoria eliminada";

            }
            catch (Exception ex)
            {
                msj = "No se elimino la categoria : " + ex.Message;
            }
            return msj;
        }



        public string RestaurarCategoria(int id)
        {
            string msj = "";
            try
            {
                Datos.RestaurarCategoria(id);
                msj = "Categoria restaurado";

            }
            catch (Exception ex)
            {
                msj = "No se restauro la categoria : " + ex.Message;
            }
            return msj;
        }
    }

}
