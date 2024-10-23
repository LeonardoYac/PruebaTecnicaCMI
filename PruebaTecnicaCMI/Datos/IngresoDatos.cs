using PruebaTecnicaCMI.Models;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace PruebaTecnicaCMI.Datos
{
    public class IngresoDatos
    {
        public List<IngresoModel> Listar()
        {

            var oLista = new List<IngresoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new IngresoModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"].ToString()), 
                            CodigoEmpleado = dr["CodigoEmpleado"].ToString(),
                            HoraEntrada = TimeSpan.Parse(dr["HoraEntrada"].ToString()), 
                            HoraSalida = TimeSpan.Parse(dr["HoraSalida"].ToString()),
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            TipoHoras = dr["TipoHoras"].ToString(),
                        });

                    }
                }
            }

            return oLista;
        }

  
        public bool Guardar(IngresoModel oIngreso)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("CH_GuardarIngreso", conexion);
                    cmd.Parameters.AddWithValue("FechaIngreso", oIngreso.Fecha);
                    cmd.Parameters.AddWithValue("CodigoEmpleado", oIngreso.CodigoEmpleado);
                    cmd.Parameters.AddWithValue("HoraEntrada", oIngreso.HoraEntrada);
                    cmd.Parameters.AddWithValue("HoraSalida", oIngreso.HoraSalida);
                    cmd.Parameters.AddWithValue("MiUsuario", "User");
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
