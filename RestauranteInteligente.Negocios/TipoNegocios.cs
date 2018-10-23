using RestauranteInteligente.Datos;
using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Negocios
{
    public class TipoNegocios
    {
        private TipoDatos Datos;

        public TipoNegocios()
        {
            Datos = new TipoDatos();
        }

        public List<Tipo> ListarTipo(int estado)
        {

            return Datos.ListarTipo(estado);
        }

        public Tipo ListarTipoXId(int id)
        {

            return Datos.ListarTipoXId(id);
        }

        public string AgregarTipo(Tipo tipo)
        {
            string msj = "";
            try
            {
                tipo.Validar();
                Datos.AgregarTipo(tipo);
                msj = "Tipo agregado";

            }
            catch (Exception ex)
            {
                msj = "No se agrego el tipo : " + ex.Message;
            }
            return msj;
        }


        public string ActualizarTipo(Tipo tipo)
        {
            string msj = "";
            try
            {
                tipo.Validar();
                Datos.ActualizarTipo(tipo);
                msj = "Tipo actualizado";

            }
            catch (Exception ex)
            {
                msj = "No se actualizo el tipo : " + ex.Message;
            }
            return msj;
        }


        public string EliminarTipo(int id)
        {
            string msj = "";
            try
            {
                Datos.EliminarTipo(id);
                msj = "Tipo eliminado";

            }
            catch (Exception ex)
            {
                msj = "No se elimino el tipo : " + ex.Message;
            }
            return msj;
        }



        public string RestaurarTipo(int id)
        {
            string msj = "";
            try
            {
                Datos.RestaurarTipo(id);
                msj = "Tipo restaurado";

            }
            catch (Exception ex)
            {
                msj = "No se restauro el tipo : " + ex.Message;
            }
            return msj;
        }
    }
}
