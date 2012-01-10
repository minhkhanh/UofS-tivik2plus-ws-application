using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.OleDb;

namespace TiviK2Plus_WebServiceApp
{
    public struct Constants
    {
        /// <summary>
        /// ConHoatDong attribute constant value
        /// </summary>
        public const bool KENH_TV_CON_HOAT_DONG = true;
        public const bool KENH_TV_KHONG_HOAT_DONG = !KENH_TV_CON_HOAT_DONG;

        /// <summary>
        /// Adding one record into KenhTivi's result
        /// </summary>
        public const bool ADD_KENH_TV_SUCCEED = true;
        public const bool ADD_KENH_TV_FAIL = !ADD_KENH_TV_SUCCEED;

        /// <summary>
        /// GetMaKenh method fail return value
        /// </summary>
        public const int GET_MA_KENH_FAIL = -1;
    }
}
