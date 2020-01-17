using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public Usuario ObtenerUsuario(string usuario, string password)
        {



            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {

                string query = "SELECT * FROM Usuarios WHERE  usuario= @usuario";
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.Add("@usuario", SqlDbType.VarChar, 100).Value = usuario;
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = command;
                    sda.Fill(ds);
                    if (ds.Tables[0].Rows[0]["password"].ToString() == password)
                    {
                        return new Usuario() { nombre = ds.Tables[0].Rows[0]["nombre"].ToString(), password = "", autentication = true };
                    }
                    else
                    {
                        return new Usuario() { nombre = ds.Tables[0].Rows[0]["nombre"].ToString(), password = "", autentication = false };

                    }

                }
                catch (Exception ex)
                {

                    con.Close();
                    con.Dispose();
                    throw;

                }
                finally
                {
                    con.Close();

                }
            }


        }


        public List<Productos> ObtenerProductos()
        {

            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {

                string query = "SELECT * FROM Productos";
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = command;
                    sda.Fill(ds);
                    var list = ds.Tables[0].AsEnumerable().Select(dataRow =>
                                 new Productos
                                 {
                                     id = dataRow.Field<string>("id"),
                                     Descripcion = dataRow.Field<string>("Descripcion")

                                 }).ToList();

                    return list;
                }
                catch (Exception ex)
                {

                    con.Close();
                    con.Dispose();
                    throw;

                }
                finally
                {
                    con.Close();

                }
            }


        }
    }
}
