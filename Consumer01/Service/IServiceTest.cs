using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data;
using Consumer01.Model;

namespace Consumer01.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceTest" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceTest
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "DoWork", BodyStyle=WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        String DoWork();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "all", ResponseFormat = WebMessageFormat.Json)]
        List<Area> all();
    }
}
