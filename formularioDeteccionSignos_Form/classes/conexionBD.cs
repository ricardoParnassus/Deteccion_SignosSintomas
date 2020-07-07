using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using formularioDeteccionSignos_Form.resources.camera.SDK.Dahua;
using iTextSharp.text;

namespace formularioDeteccionSignos_Form.classes
{
    class conexionBD
    {
        string cadenaConexion = @"Data Source=DESKTOP-M6N1B4Q\SQLEXPRESS; Initial Catalog=DeteccionDB; Integrated Security=True";
        public SqlConnection cnn = new SqlConnection();
        public SqlCommand cmd;
        public SqlDataAdapter adapter;
        public SqlDataReader reader;
        
        public conexionBD()
        {
            cnn.ConnectionString = cadenaConexion;
        }

        public void fnAbrirConexion()
        {
            try
            {
                if(!cnn.State.Equals(System.Data.ConnectionState.Open))
                    cnn.Open();
                Console.WriteLine("Conexion Abierta");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + "\n\r" + ex.StackTrace);
            }
        }

        public void fnCerrarConexion()
        {
            if (cnn.State.Equals(System.Data.ConnectionState.Open))
                cnn.Close();
        }

        public bool fnEjecutarSentencia(string query)
        {
            //** 0 -- INSERT OR UPDATE
            try
            {
                if(cnn.State == System.Data.ConnectionState.Open)
                {
                    cmd = new SqlCommand(query);
                    if (cmd.ExecuteNonQuery() > 0)
                        return true;
                }
                else
                {
                    fnAbrirConexion();
                    cmd = new SqlCommand(query);
                    if (cmd.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
                return false;
            }
        }

        public DataTable fnConsultaSentencia(string str_query)
        {
            DataTable dtbl_consulta = new DataTable();
            try
            {
                adapter = new SqlDataAdapter(str_query, cnn);
                adapter.Fill(dtbl_consulta);
                return dtbl_consulta;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
                return dtbl_consulta;
            }
        }

        public void fnInsertaIMagenBDD(int id, string pathFoto)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                FileStream fs = new FileStream(pathFoto, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                ms.SetLength(fs.Length);
                fs.Read(ms.GetBuffer(), 0, (int)fs.Length);

                byte[] arrImage = ms.GetBuffer();
                ms.Flush();
                fs.Close();

                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandText = "INSERT INTO tbl_fotoUsuarios VALUES (" +
                        " @id_user" +
                        ", @imagen" +
                        ", @descripcion" +
                        ")";
                    cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = arrImage;
                    cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = Path.GetFileName(pathFoto);

                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public System.Drawing.Image ObtenerBitmapBDD(int id)
        {
            try
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandText = "SELECT imagen FROM tbl_fotoUsuarios WHERE id_user=@id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    byte[] arrImage = (byte[])cmd.ExecuteScalar();
                    cnn.Close();
                    MemoryStream ms = new MemoryStream(arrImage);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                    ms.Close();
                    return img;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
