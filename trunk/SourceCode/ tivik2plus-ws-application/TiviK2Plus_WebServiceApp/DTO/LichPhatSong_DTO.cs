using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace TiviK2Plus_WebServiceApp
{
    [DataContract]
    public class LichPhatSong_DTO
    {
        #region Properties
        private int _maLichPhatSong;
        [DataMember]
        public int MaLichPhatSong
        {
            get { return _maLichPhatSong; }
            set { _maLichPhatSong = value; }
        }

        private int _maKenh;
        [DataMember]
        public int MaKenh
        {
            get { return _maKenh; }
            set { _maKenh = value; }
        }

        private DateTime _ngay;
        [DataMember]
        public DateTime Ngay
        {
            get { return _ngay; }
            set { _ngay = value; }
        }

        private String _noiDung;
        [DataMember]
        public String NoiDung
        {
            get { return _noiDung; }
            set { _noiDung = value; }
        }
        #endregion

        #region Methods
        #endregion
    }
}