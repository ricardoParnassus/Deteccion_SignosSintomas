using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formularioDeteccionSignos_Form.classes
{
    class usuarioClass
    {
        public string id_actual = string.Empty;
        public usuarioClass()
        {

        }

        public DataTable fnSeleccionaUsuario(string num_empleado)
        {
            DataTable dtbl_consulta = new DataTable();
            try
            {
                string str_query = "exec spConsultaEmpleado " + num_empleado;
                conexionBD consulta = new conexionBD();
                consulta.fnAbrirConexion();
                dtbl_consulta = consulta.fnConsultaSentencia(str_query);
                return dtbl_consulta;
            }
            catch (Exception ex)
            {
                return dtbl_consulta;
            }
        }

        public DataTable fnSeleccionaUsuarioNombre(string match)
        {
            DataTable dtbl_consulta = new DataTable();
            try
            {
                string str_query = "exec spConsultaEmpleadoNombre " + match;
                conexionBD consulta = new conexionBD();
                consulta.fnAbrirConexion();
                dtbl_consulta = consulta.fnConsultaSentencia(str_query);
                return dtbl_consulta;
            }
            catch (Exception ex)
            {
                return dtbl_consulta;
            }
        }
        public bool fnLogeoSistema(string usuario, string contrasenia)
        {
            DataTable dtbl_consulta = new DataTable();
            try
            {
                string str_query = "exec spLogeoSistema '" + usuario + "', '" + contrasenia + "'";
                conexionBD consulta = new conexionBD();
                consulta.fnAbrirConexion();
                dtbl_consulta = consulta.fnConsultaSentencia(str_query);
                foreach (DataRow item in dtbl_consulta.Rows)
                {
                    object[] array = item.ItemArray;
                    if (array.Count() >= 10)
                    {
                        id_actual = array[0].ToString();
                        return true;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
                return false;
            }
        }
        public Image fnRecuperaFotoBDDUsuario(string id)
        {
            conexionBD cnn = new conexionBD();
            
            Image imagen_usuario = cnn.ObtenerBitmapBDD(Int32.Parse(id));

            return imagen_usuario;
        }
    }
}
