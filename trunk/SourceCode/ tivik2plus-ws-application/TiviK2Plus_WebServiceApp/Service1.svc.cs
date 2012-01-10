using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using TiviK2Plus_WebServiceApp.Core;

namespace TiviK2Plus_WebServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {

        #region IService1 Members

        public List<KenhTV_DTO> GetKenhTVList()
        {
            return KenhTV_BUS.Object.GetKenhTVList();
        }

        public int Plus(int a, int b)
        {
            return a + b;
        }

        public AkhoiTestClass AkhoiTestOperation(string id)
        {
            AkhoiTestClass obj = new AkhoiTestClass();
            obj.Id = id;
            obj.Name = "name";

            return obj;
        }

        public bool AddKenhTV(KenhTV_DTO kenhTV)
        {
            return KenhTV_BUS.Object.AddKenhTV(kenhTV);
        }

        public string GetLichPhatSong(string tenMaKenh, int ngay, int thang, int nam)
        {
            try
            {
                DateTime _ngay = new DateTime(nam, thang, ngay);
                return LichPhatSong_BUS.Object.GetLichPhatSong(tenMaKenh, _ngay);
            }
            catch (Exception ex)
            {
                return @"";
            }
        }

        public List<KenhTV_DTO> SearchKenhTVWithKey(string key)
        {
            return KenhTV_BUS.Object.SearchKenhTVWithKey(key);
        }

        #endregion
    }
}
