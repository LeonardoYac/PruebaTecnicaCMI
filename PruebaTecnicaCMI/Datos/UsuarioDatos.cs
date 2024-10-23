using PruebaTecnicaCMI.Models;
using System.Data.SqlClient;
using System.Data;

namespace PruebaTecnicaCMI.Datos
{
    public class UsuarioDatos
    {
      
        public bool Autenticar(UsuarioModel ousuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Autenticar", conexion);
                    cmd.Parameters.AddWithValue("Usuario", ousuario.Usuario);
                    cmd.Parameters.AddWithValue("Pass", ousuario.Contrasenya);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }

    }
}
