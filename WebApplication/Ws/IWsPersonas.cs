using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Ws
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWSUsuarios
    {

        [OperationContract]
        Usuario ObtenerUsuario(string usuario, string password);


        [OperationContract]
        Productos ObtenerProductos();

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Usuario
    {

        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string password { get; set; }

        public bool autentication { get; set; }

    }


    [DataContract]
    public class Productos
    {

        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }


    }
}
