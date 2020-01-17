using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Ws
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WSUsuarios :  IWSUsuarios
    {
       
        public Usuario ObtenerUsuario(string usuario, string password)
        {
            if (password == "hola")
            {
                return new Usuario() { nombre = "hola", password = "", autentication = true };
            }
            else
            {
                return new Usuario() { nombre = "hola", password = "", autentication = false };
            }
        }


        public Productos ObtenerProductos()
        {

            return new Productos() { id = "1", Descripcion = " xxxx" };


        }



        


    }
}
