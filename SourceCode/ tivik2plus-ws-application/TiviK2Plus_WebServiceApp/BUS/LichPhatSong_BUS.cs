using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace TiviK2Plus_WebServiceApp
{
    public class LichPhatSong_BUS
    {
        #region Properties
        private static LichPhatSong_DAO _lichPhatSong_DAO = null;
        private static LichPhatSong_BUS _lichPhatSong_BUS = null;
        #endregion

        #region Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        private LichPhatSong_BUS()
        {
            _lichPhatSong_DAO = LichPhatSong_DAO.Object;
        }

        /// <summary>
        /// Get static object represent for LichPhatSong_BUS class
        /// </summary>
        public static LichPhatSong_BUS Object
        {
            get
            {
                if (_lichPhatSong_BUS == null)
                {
                    _lichPhatSong_BUS = new LichPhatSong_BUS();
                }

                return _lichPhatSong_BUS;
            }
        }

        /// <summary>
        /// Lấy nội dung lịch chiếu phim
        /// </summary>
        /// <param name="maKenh">mã kênh</param>
        /// <param name="ngay"></param>
        /// <returns></returns>
        public String GetLichPhatSong(String tenMaKenh, DateTime ngay)
        {
            return _lichPhatSong_DAO.GetLichPhatSong(tenMaKenh, ngay);
        }
        #endregion
    }
}
