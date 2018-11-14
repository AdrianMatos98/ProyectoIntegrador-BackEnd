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
    public class PlatilloNegocios
    {
        private IPlatilloDatos Datos;

        public PlatilloNegocios()
        {
            Datos = new PlatilloDatos();
        }
        

        public List<Platillo> ListarPlatilloXCategoria_Nombre(int estado, int categoria,string nombre)
        {
            if (nombre == null)
            {
                nombre = "";
            }
            return Datos.ListarPlatilloXCategoria_Nombre(estado, categoria, nombre);
        }

        public Platillo ListarPlatilloXId(int id)
        {

            return Datos.ListarPlatilloXId(id);
        }

        public string AgregarPlatillo(Platillo platillo)
        {
            string msj = "";
            try
            {
                platillo.Validar();
                Datos.AgregarPlatillo(platillo);
                msj = "Platillo agregado";

            }
            catch (Exception ex)
            {
                msj = "No se agrego el platillo : " + ex.Message;
            }
            return msj;
        }

        public string ActualizarPlatillo(Platillo platillo)
        {
            string msj = "";
            try
            {
                platillo.Validar();
                Datos.ActualizarPlatillo(platillo);
                msj = "Platillo actualizado";

            }
            catch (Exception ex)
            {
                msj = "No se actualizo el platillo : " + ex.Message;
            }
            return msj;
        }

        public string EliminarPlatillo(int id)
        {
            string msj = "";
            try
            {
                Datos.EliminarPlatillo(id);
                msj = "Platillo eliminado";

            }
            catch (Exception ex)
            {
                msj = "No se elimino el platillo : " + ex.Message;
            }
            return msj;
        }



        public string RestaurarPlatillo(int id)
        {
            string msj = "";
            try
            {
                Datos.RestaurarPlatillo(id);
                msj = "Platillo restaurado";

            }
            catch (Exception ex)
            {
                msj = "No se restauro el platillo : " + ex.Message;
            }
            return msj;
        }
    }
}
