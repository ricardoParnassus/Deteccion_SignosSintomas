﻿using System;
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

        public DataTable fnSeleccionaUsuarioCorreo(string match)
        {
            DataTable dtbl_consulta = new DataTable();
            try
            {
                string str_query = "exec spConsultaUsuarioCorreo '" + match + "'";
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
            Image imagen_usuario = cnn.ObtenerBitmapBDD(Int32.Parse(id), "tbl_fotoUsuarios", "id_user=@id");
            return imagen_usuario;
        }

        public bool fnIngresaUsuario(string nombre, string a_paterno, string a_materno, string genero, string edad, string rol, string puesto, string correo, string contrasenia, string path_imagen)
        {
            try
            {
                conexionBD consulta = new conexionBD();
                string query_aux = "select max(id_jorbee) from tbl_usuarios";
                string id_jorbee = string.Empty;
                DataTable tbl_aux = consulta.fnConsultaSentencia(query_aux);
                foreach (DataRow item in tbl_aux.Rows)
                {
                    id_jorbee = item.Field<int>("Column1").ToString();
                }
                string str_query = "exec sp_insertaUsuario " + id_jorbee + ", '" + nombre + "', '" + a_paterno + "', '" + a_materno + "', '" + genero + "', " + edad + ", " + rol + ", " + puesto + ", '" + correo + "', '" + contrasenia + "';";
                consulta.fnAbrirConexion();
                if (consulta.fnEjecutarSentencia(str_query))
                {
                    DataTable tbl_respuesta = consulta.fnConsultaSentencia("SELECT id_user FROM tbl_usuarios WHERE nombre = '" + nombre + "' AND apellido_uno = '" + a_paterno + "' AND apellido_dos = '" + a_materno + "' AND genero = '" + genero + "' AND correo = '" + correo + "'");
                    foreach (DataRow item in tbl_respuesta.Rows)
                    {
                        object[] obj = item.ItemArray;
                        consulta.fnInsertaIMagenBDD(Int32.Parse(obj[0].ToString()), path_imagen);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
