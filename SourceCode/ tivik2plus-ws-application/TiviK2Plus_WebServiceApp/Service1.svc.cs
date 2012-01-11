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
    //[KnownType(typeof(MmsSourceType))]
    //[KnownType(typeof(RtmpSourceType))]
    public class Service1 : IService1
    {

        #region IService1 Members

        public KenhTV_DTO[] GetKenhTVList()
        {
            return KenhTV_BUS.Object.GetKenhTVList().ToArray();
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
                //DateTime _ngay = DateTime.Now;
                string schedule = LichPhatSong_BUS.Object.GetLichPhatSong(tenMaKenh, _ngay);
                if (schedule == "")
                {
                    return Extractor.ExtractSchedule(_ngay, KenhTV_DAO.Object.LayLinkNguon(tenMaKenh), KenhTV_DAO.Object.LayMoTaRutTrich(tenMaKenh));
                }

                return schedule;
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

        public SourceTypeWrapper GetLinkPhatWithTenMaKenh(string tenMaKenh)
        {
            string result = KenhTV_BUS.Object.GetLinkPhatWithTenMaKenh(tenMaKenh);

            // mms source type need only the url
            if (result.Contains("mms"))
            {
                MmsSourceType mms = new MmsSourceType();
                mms.Url = result;

                SourceTypeWrapper sourceType = new SourceTypeWrapper();
                sourceType.Type = mms;

                return sourceType;
            }
            else if (result.Contains("rtmp"))       // rtmp need 'streamer' and 'file' param
            {
                string[] parts = result.Split('&'); // stored format: rtmp://xxx&yyy
                if (parts.Length == 2)
                {
                    RtmpSourceType rtmp = new RtmpSourceType();
                    rtmp.ParamStreamer = (parts[0].Contains("streamer") ? parts[0] : parts[1]).Replace("streamer=", "");
                    rtmp.ParamFile = (parts[0].Contains("file") ? parts[0] : parts[0]).Replace("file=", "");

                    SourceTypeWrapper sourceType = new SourceTypeWrapper();
                    sourceType.Type = rtmp;

                    return sourceType;
                }
            }

            return new SourceTypeWrapper();
        }

        public void CheckErrorLink(string tenMaKenh)
        {
            throw new NotImplementedException();
        }

        public bool UpdateKenhTV(KenhTV_DTO kenhTV)
        {
            return KenhTV_BUS.Object.UpdateKenhTV(kenhTV);
        }

        public bool DeleteKenhTV(int maKenh)
        {
            return KenhTV_BUS.Object.DeleteKenhTV(maKenh);
        }

        #endregion
    }
}
