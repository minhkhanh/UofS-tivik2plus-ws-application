using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AdminClient
{
    [Serializable]
    [DataContract(Namespace = "")]
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

        private String _moTaKenh;
        [DataMember]
        public String MoTaKenh
        {
            get { return _moTaKenh; }
            set { _moTaKenh = value; }
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

        private String _nguonGoc;
        [DataMember]
        public String NguonGoc
        {
            get { return _nguonGoc; }
            set { _nguonGoc = value; }
        }

        private String _moTaRutTrich;
        [DataMember]
        public String MoTaRutTrich
        {
            get { return _moTaRutTrich; }
            set { _moTaRutTrich = value; }
        }

        private int _linkHong;
        [DataMember]
        public int LinkHong
        {
            get { return _linkHong; }
            set { _linkHong = value; }
        }

        private int _lichHong;
        [DataMember]
        public int LichHong
        {
            get { return _lichHong; }
            set { _lichHong = value; }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public KenhTV_DTO()
        {
            _conHoatDong = false;
            _link = @"";
            _maKenh = 0;
            _moTaKenh = @"";
            _moTaRutTrich = @"";
            _nguonGoc = @"";
            _tenMaKenh = @"";
        }
        #endregion
    }
}