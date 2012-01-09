using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiviK2Plus_WebServiceApp.DTO
{
    public class KenhTV_DTO
    {
        #region Properties
        private int _maKenh;
        public int MaKenh
        {
            get { return _maKenh; }
            set { _maKenh = value; }
        }

        private String _tenMaKenh;
        public String TenMaKenh
        {
            get { return _tenMaKenh; }
            set { _tenMaKenh = value; }
        }

        private String _moTa;
        public String MoTa
        {
            get { return _moTa; }
            set { _moTa = value; }
        }

        private String _link;
        public String Link
        {
            get { return _link; }
            set { _link = value; }
        }

        private bool _conHoatDong;
        public bool ConHoatDong
        {
            get { return _conHoatDong; }
            set { _conHoatDong = value; }
        }

        private String _reserved;
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