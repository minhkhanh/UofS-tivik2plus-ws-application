using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace TiviK2Plus_WebServiceApp
{
    [DataContract]
    public class KenhTV_DTO
    {
        #region Properties
        private int _maKenh;
        [DataMember]
        public int MaKenh
        {
            get { return _maKenh; }
            set { _maKenh = value; }
        }

        private String _tenMaKenh;
        [DataMember]
        public String TenMaKenh
        {
            get { return _tenMaKenh; }
            set { _tenMaKenh = value; }
        }

        private String _moTa;
        [DataMember]
        public String MoTa
        {
            get { return _moTa; }
            set { _moTa = value; }
        }

        private String _link;
        [DataMember]
        public String Link
        {
            get { return _link; }
            set { _link = value; }
        }

        private bool _conHoatDong;
        [DataMember]
        public bool ConHoatDong
        {
            get { return _conHoatDong; }
            set { _conHoatDong = value; }
        }

        private String _reserved;
        [DataMember]
        public String Reserved
        {
            get { return _reserved; }
            set { _reserved = value; }
        }
        #endregion

        #region Methods
        #endregion
    }
}