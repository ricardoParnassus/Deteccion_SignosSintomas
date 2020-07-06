using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formularioDeteccionSignos_Form.classes
{
    class incidenciaDeteccionClass
    {
        /// <summary>
        /// variables
        /// </summary>
        private string encuestado = string.Empty;
        private string encuestador = string.Empty;
        private string fecha = string.Empty;
        private bool fiebre = false;
        private bool tos_estornudos = false;
        private bool malestar_general = false;
        private bool dolor_cabeza = false;
        private bool dificultad_resp = false;
        private bool sintomas = false;
        public incidenciaDeteccionClass()
        {
        }

        public bool fnInsertaIncidenciaDeteccion()
        {
            try
            {
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public DataTable fnSeleccionaIncidencias()
        {
            try
            {
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool fnActualizaIncidenciaDeteccion()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
