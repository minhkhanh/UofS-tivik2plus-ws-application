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
        #endregion
    }
}
