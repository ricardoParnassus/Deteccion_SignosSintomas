using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formularioDeteccionSignos_Form.classes
{
    class parameters
    {
        public parameters()
        {

        }
        public bool fnIngresaDatosCamara(string marca, string dir_ip, string dir_port, string usuario, string contra, string terminal, string tipo_visor)
        {
            try
            {
                string str_query = "exec spRegistraCamara '" + marca + "', '" + dir_ip + "', '" + dir_port + "', '" + usuario + "', '" + contra + "', '" + terminal + "', '" + tipo_visor + "';";
                conexionBD consulta = new conexionBD();
                consulta.fnAbrirConexion();
                return consulta.fnEjecutarSentencia(str_query);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable fnRecuperaDatosCamara()
        {
            try
            {
                conexionBD consulta = new conexionBD();
                return consulta.fnConsultaSentencia("select * from tbl_camaras");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
