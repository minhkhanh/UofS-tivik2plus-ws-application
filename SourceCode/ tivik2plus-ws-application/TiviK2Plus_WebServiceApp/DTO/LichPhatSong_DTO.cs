using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiviK2Plus_WebServiceApp.DTO
{
    public class LichPhatSong_DTO
    {
        #region Properties
        private int _maLichPhatSong;
        public int MaLichPhatSong
        {
            get { return _maLichPhatSong; }
            set { _maLichPhatSong = value; }
        }

        private int _maKenh;
        public int MaKenh
        {
            get { return _maKenh; }
            set { _maKenh = value; }
        }

        private DateTime _ngay;
        public DateTime Ngay
        {
            get { return _ngay; }
            set { _ngay = value; }
        }

        private String _lichPhatSong;
        public String LichPhatSong
        {
            get { return _lichPhatSong; }
            set { _lichPhatSong = value; }
        }
        #endregion

        #region Methods
        #endregion
    }
}