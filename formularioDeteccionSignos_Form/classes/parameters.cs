using System;
using System.Collections.Generic;
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
        public bool fnIngresaDatosCamara(string marca, string dir_ip, string dir_port, string usuario, string contra, string terminal)
        {
            try
            {
                string str_query = "exec spRegistraCamara '" + marca + "', '" + dir_ip + "', '" + dir_port + "', '" + usuario + "', '" + contra + "', " + terminal + ";";
                conexionBD consulta = new conexionBD();
                consulta.fnAbrirConexion();
                return consulta.fnEjecutarSentencia(str_query);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
