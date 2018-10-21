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

        public List<Tipo> ListaTipo()
        {

            return Datos.ListaTipo();
        }

        public Tipo ListaTipoXId(int id)
        {

            return Datos.ListaTipoXId(id);
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
            catch(Exception ex)
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
    }
}
