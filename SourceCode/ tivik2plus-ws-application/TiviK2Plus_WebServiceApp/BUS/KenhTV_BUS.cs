using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.Collections.Generic;

namespace TiviK2Plus_WebServiceApp
{
    [DataContract]
    public class KenhTV_BUS
    {
        #region Properties
        private static KenhTV_DAO _kenhTV_DAO = null;
        private static KenhTV_BUS _kenhTV_BUS = null;
        #endregion

        #region Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        private KenhTV_BUS()
        {
            _kenhTV_DAO = KenhTV_DAO.Object;
        }

        /// <summary>
        /// Get static object represent for KenhTV_BUS class
        /// </summary>
        [DataMember]
        public static KenhTV_BUS Object
        {
            get
            {
                if (_kenhTV_BUS == null)
                {
                    _kenhTV_BUS = new KenhTV_BUS();
                }

                return _kenhTV_BUS;
            }
        }

        /// <summary>
        /// Lấy danh sách các kênh TV đang còn hoạt động từ CSDL
        /// </summary>
        /// <returns> List<KenhTV_DTO> </returns>
        public List<KenhTV_DTO> GetKenhTVList()
        {
            return _kenhTV_DAO.GetKenhTVList();
        }

        /// <summary>
        /// Thêm 1 record vào bảng KenhTivi
        /// </summary>
        /// <param name="kenhTV">Đối tượng KenhTV_DTO chứa thông tin record cần thêm vào CSDL</param>
        /// <returns>
        ///     true:   Thêm thành công
        ///     false:  Thêm thất bại
        /// </returns>
        public bool AddKenhTV(KenhTV_DTO kenhTV)
        {
            return _kenhTV_DAO.AddKenhTV(kenhTV);
        }

        /// <summary>
        /// Lấy mã kênh dựa vào tên mã kênh
        /// </summary>
        /// <param name="tenMaKenh"></param>
        /// <returns>
        ///     null:           Tìm kiếm thất bại
        ///     Giá trị khác:   Tìm kiếm thành công
        /// </returns>
        public int GetMaKenh(String tenMaKenh)
        {
            return _kenhTV_DAO.GetMaKenh(tenMaKenh);
        }

        /// <summary>
        /// Tìm kiếm kênh TV với khóa gần đúng
        /// </summary>
        /// <param name="key">Từ khóa tìm kiếm</param>
        /// <returns>List<KenhTV_DTO></returns>
        public List<KenhTV_DTO> SearchKenhTVWithKey(String key)
        {
            return _kenhTV_DAO.SearchKenhTVWithKey(key);
        }

        /// <summary>
        /// Lấy link phát với tên mã kênh (tìm kiếm đúng)
        /// </summary>
        /// <param name="tenMaKenh">tên mã kênh cần lấy link</param>
        /// <returns>String</returns>
        public String GetLinkPhatWithTenMaKenh(String tenMaKenh)
        {
            return _kenhTV_DAO.GetLinkPhatWithTenMaKenh(tenMaKenh);
        }
        #endregion
    }
}
