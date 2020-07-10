using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formularioDeteccionSignos_Form.classes
{
    class transacciones
    {
        public transacciones()
        {

        }

        public DataTable fnConsultaTransaccionesEmpleado(string num_empleado)
        {
            DataTable dtbl_respuesta = new DataTable();
            try
            {
                string str_query = "exec spConsultaTransacciones " + num_empleado;
                conexionBD consulta = new conexionBD();
                consulta.fnAbrirConexion();
                dtbl_respuesta = consulta.fnConsultaSentencia(str_query);
                return dtbl_respuesta;
            }
            catch (Exception ex)
            {
                return dtbl_respuesta;
            }
        }

        public DataTable fnConsultaDatosTransaccion(string id_transaccion)
        {
            DataTable dtbl_respuesta = new DataTable();
            try
            {
                string str_query = "exec spConsultaDatosTransaccion " + id_transaccion;
                conexionBD consulta = new conexionBD();
                consulta.fnAbrirConexion();
                dtbl_respuesta = consulta.fnConsultaSentencia(str_query);
                return dtbl_respuesta;
            }
            catch (Exception ex)
            {
                return dtbl_respuesta;
            }
        }
    }
}
