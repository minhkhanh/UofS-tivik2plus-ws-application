using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TiviK2Plus_WebServiceApp.Core;

namespace TiviK2Plus_WebServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method="GET", UriTemplate="kenhtv?getlist", ResponseFormat=WebMessageFormat.Json)]
        List<KenhTV_DTO> GetKenhTVList();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "plus?a={a}&b={b}", ResponseFormat = WebMessageFormat.Json)]
        int Plus(int a, int b);

        [OperationContract]
        [WebInvoke(Method="GET", UriTemplate="test/{id}", ResponseFormat=WebMessageFormat.Json)]
        AkhoiTestClass AkhoiTestOperation(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "kenhtv?insert", ResponseFormat = WebMessageFormat.Json)]
        bool AddKenhTV(KenhTV_DTO kenhTV);
    }
}
