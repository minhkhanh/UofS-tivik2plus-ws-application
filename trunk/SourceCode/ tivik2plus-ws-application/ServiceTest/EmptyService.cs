using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TiviK2Plus_WebServiceApp;

namespace ServiceTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmptyService" in both code and config file together.
    public class EmptyService : IService1
    {

        public KenhTV_DTO[] GetKenhTVList()
        {
            throw new NotImplementedException();
        }

        public int Plus(int a, int b)
        {
            throw new NotImplementedException();
        }

        public TiviK2Plus_WebServiceApp.Core.AkhoiTestClass AkhoiTestOperation(string id)
        {
            throw new NotImplementedException();
        }

        public bool AddKenhTV(KenhTV_DTO kenhTV)
        {
            throw new NotImplementedException();
        }

        public string GetLichPhatSong(string tenMaKenh, int ngay, int thang, int nam)
        {
            throw new NotImplementedException();
        }

        public List<KenhTV_DTO> SearchKenhTVWithKey(string key)
        {
            throw new NotImplementedException();
        }

        public TiviK2Plus_WebServiceApp.Core.SourceTypeWrapper GetLinkPhatWithTenMaKenh(string tenMaKenh)
        {
            throw new NotImplementedException();
        }

        public void CheckErrorLink(string tenMaKenh)
        {
            throw new NotImplementedException();
        }
    }
}
