using Consumer01.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Consumer01.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceTest" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceTest.svc o ServiceTest.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceTest : IServiceTest
    {
        public string DoWork()
        {
            return "Hola mundo";
        }

        public List<Area> all()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            List<Area> list = new List<Area>();
            Area area = new Area();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["testWebServiceConnectionString"].ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_read_areas", con))
                    {
                        //Using DataSet
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //ad.SelectCommand = cmd;
                        //ad.Fill(ds);

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            area.Id = reader.GetInt32(0);
                            area.Name = reader.GetString(1);
                            list.Add(area);
                        }

 
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }

            return list;
            //return ds.t;
        }
    }
}
