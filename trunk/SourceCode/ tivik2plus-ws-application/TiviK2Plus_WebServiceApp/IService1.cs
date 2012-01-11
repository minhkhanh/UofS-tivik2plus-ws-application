using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TiviK2Plus_WebServiceApp.Core;
using System.Xml.Serialization;

namespace TiviK2Plus_WebServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "kenhtv/getlist", ResponseFormat = WebMessageFormat.Json)]
        KenhTV_DTO[] GetKenhTVList();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "plus?a={a}&b={b}", ResponseFormat = WebMessageFormat.Json)]
        int Plus(int a, int b);

        [OperationContract]
        [WebInvoke(Method="GET", UriTemplate="test/{id}", ResponseFormat=WebMessageFormat.Json)]
        AkhoiTestClass AkhoiTestOperation(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertkenhtv", ResponseFormat = WebMessageFormat.Xml)]
        bool AddKenhTV(KenhTV_DTO kenhTV);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "lichphatsong?tenMaKenh={tenMaKenh}&ngay={ngay}&thang={thang}&nam={nam}", ResponseFormat = WebMessageFormat.Json)]
        String GetLichPhatSong(String tenMaKenh, int ngay, int thang, int nam);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "searchkenhtv?key={key}", ResponseFormat = WebMessageFormat.Json)]
        List<KenhTV_DTO> SearchKenhTVWithKey(String key);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "kenhtv/getlink?tenmakenh={tenMaKenh}", ResponseFormat = WebMessageFormat.Json)]
        SourceTypeWrapper GetLinkPhatWithTenMaKenh(String tenMaKenh);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "kenhtv/errorlink?tenmakenh={tenMaKenh}", ResponseFormat = WebMessageFormat.Json)]
        void CheckErrorLink(String tenMaKenh);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "kenhtv/update", ResponseFormat = WebMessageFormat.Json)]
        bool UpdateKenhTV(KenhTV_DTO kenhTV);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "kenhtv/delete?makenh={maKenh}", ResponseFormat = WebMessageFormat.Json)]
        bool DeleteKenhTV(int maKenh);
    }
}
