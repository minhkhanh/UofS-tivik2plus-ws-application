using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.OleDb;

namespace TiviK2Plus_WebServiceApp
{
    public class KenhTV_DAO : Abstract_DAO
    {
        #region Properties
        private static KenhTV_DAO _kenhTV_DAO = null;
        #endregion

        #region Constants
        private const String SQL_QUERY_GET_KENH_TV_LIST = @"SELECT MaKenh, TenMaKenh, MoTaKenh, LinkPhat, NguonGoc, MoTaRutTrich "
                                                        + @"FROM KenhTivi "
                                                        + @"WHERE ConHoatDong = " + SQL_PARA_CON_HOAT_DONG;
        private const String SQL_QUERY_ADD_KENH_TV = @"INSERT INTO KenhTivi(TenMaKenh, LinkPhat, ConHoatDong, NguonGoc, MoTaRutTrich, MoTaKenh) "
                                                   + @"VALUES ("
                                                   + SQL_PARA_TEN_MA_KENH + ", " + SQL_PARA_LINK + ", " + SQL_PARA_CON_HOAT_DONG + ", " + SQL_PARA_NGUON_GOC + ", "
                                                   + SQL_PARA_MO_TA_RUT_TRICH + ", " + SQL_PARA_MO_TA_KENH
                                                   + @")";
        private const String SQL_QUERY_GET_MA_KENH = @"SELECT MaKenh "
                                                   + @"FROM KenhTivi "
                                                   + @"WHERE ConHoatDong = " + SQL_PARA_CON_HOAT_DONG
                                                   + @" AND TenMaKenh = " + SQL_PARA_TEN_MA_KENH;
        //private const String SQL_QUERY_SEARCH_KENHTV = @"SELECT MaKenh, TenMaKenh, MoTaKenh, LinkPhat, NguonGoc, MoTaRutTrich "
        //                                             + @"FROM KenhTivi"
        //                                             + @"WHERE ((ConHoatDong = " + SQL_PARA_CON_HOAT_DONG + ")"
        //                                             + @" OR TenMaKenh LIKES"
        //                                             + @")";

        private const String SQL_PARA_MA_KENH = @"@maKenh";
        private const String SQL_PARA_TEN_MA_KENH = @"@tenMaKenh";
        private const String SQL_PARA_MO_TA_KENH = @"@moTaKenh";
        private const String SQL_PARA_LINK = @"@link";
        private const String SQL_PARA_CON_HOAT_DONG = @"@conHoatDong";
        private const String SQL_PARA_NGUON_GOC = @"@nguonGoc";
        private const String SQL_PARA_MO_TA_RUT_TRICH = @"@moTaRutTrich";
        #endregion

        #region Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        private KenhTV_DAO()
        { 
        }

        /// <summary>
        /// Get static object represent for KenhTV_DAO class
        /// </summary>
        public static KenhTV_DAO Object 
        {
            get 
            {
                if (_kenhTV_DAO == null)
                {
                    _kenhTV_DAO = new KenhTV_DAO();
                }

                return _kenhTV_DAO;
            }
        }

        /// <summary>
        /// Lấy danh sách các Kênh TV còn hoạt động (đã được check)
        /// </summary>
        /// <returns> List<KenhTV_DTO> </returns>
        public List<KenhTV_DTO> GetKenhTVList()
        {
            List<KenhTV_DTO> _kenhTVList = new List<KenhTV_DTO>();
            OleDbConnection _connection = null;

            try
            {
                _connection = Connect();
                OleDbCommand _command = new OleDbCommand(SQL_QUERY_GET_KENH_TV_LIST, _connection);
                
                OleDbParameter _parameter = new OleDbParameter(SQL_PARA_CON_HOAT_DONG, OleDbType.Boolean);
                _parameter.Value = Constants.KENH_TV_CON_HOAT_DONG;
                _command.Parameters.Add(_parameter);
                
                OleDbDataReader _dataReader = _command.ExecuteReader();
                KenhTV_DTO buffer;
                while (_dataReader.Read())
                {
                    buffer = new KenhTV_DTO();
                    
                    buffer.MaKenh = _dataReader.GetInt32(0);

                    if (!_dataReader.IsDBNull(1))
                    {
                        buffer.TenMaKenh = _dataReader.GetString(1);
                    }

                    if (!_dataReader.IsDBNull(2))
                    {
                        buffer.MoTaKenh = _dataReader.GetString(2);
                    }

                    if (!_dataReader.IsDBNull(3))
                    {
                        buffer.Link = _dataReader.GetString(3);
                    }

                    if (!_dataReader.IsDBNull(4))
                    {
                        buffer.NguonGoc = _dataReader.GetString(4);
                    }

                    if (!_dataReader.IsDBNull(5))
                    {
                        buffer.MoTaRutTrich = _dataReader.GetString(5);
                    }

                    _kenhTVList.Add(buffer);
                }

            }
            catch (Exception ex)
            {
                _kenhTVList = new List<KenhTV_DTO>();
            }
            finally
            {
                if ((_connection != null) && (_connection.State == System.Data.ConnectionState.Open))
                {
                    _connection.Close();
                }
            }

            return _kenhTVList;
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
            //Nếu đối tượng kenhTV là null thì thoát khỏi phương thức và trả về giá trị thất bại
            if (kenhTV == null)
            {
                return Constants.ADD_KENH_TV_FAIL;            
            }

            OleDbConnection _connection = null;
            int _result = 0;

            try
            {
                _connection = Connect();
                OleDbCommand _command = new OleDbCommand(SQL_QUERY_ADD_KENH_TV, _connection);

                //Add parameters into command
                OleDbParameter _parameter;
                _parameter = new OleDbParameter(SQL_PARA_TEN_MA_KENH, OleDbType.VarChar);
                _parameter.Value = kenhTV.TenMaKenh;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_LINK, OleDbType.VarChar);
                _parameter.Value = kenhTV.Link;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_CON_HOAT_DONG, OleDbType.Boolean);
                _parameter.Value = kenhTV.ConHoatDong;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_NGUON_GOC, OleDbType.VarChar);
                _parameter.Value = kenhTV.NguonGoc;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_MO_TA_RUT_TRICH, OleDbType.VarChar);
                _parameter.Value = kenhTV.MoTaRutTrich;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_MO_TA_KENH, OleDbType.VarChar);
                _parameter.Value = kenhTV.MoTaKenh;
                _command.Parameters.Add(_parameter);

                _result = _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _result = 0;
            }
            finally
            {
                if ((_connection != null) && (_connection.State == System.Data.ConnectionState.Open))
                {
                    _connection.Close();
                }
            }

            if (_result == 0)
            {
                return Constants.ADD_KENH_TV_FAIL;
            }
            else
            {
                return Constants.ADD_KENH_TV_SUCCEED;
            }
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
            OleDbConnection _connection = null;
            int _maKenh = Constants.GET_MA_KENH_FAIL;

            try
            {
                _connection = Connect();
                OleDbCommand _command = new OleDbCommand(SQL_QUERY_GET_MA_KENH, _connection);

                OleDbParameter _parameter = new OleDbParameter(SQL_PARA_TEN_MA_KENH, OleDbType.VarChar);
                _parameter.Value = tenMaKenh;
                _command.Parameters.Add(_parameter);

                OleDbDataReader _dataReader = _command.ExecuteReader();
                while (_dataReader.Read())
                {
                    _maKenh = _dataReader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                _maKenh = Constants.GET_MA_KENH_FAIL;
            }
            finally
            {
                if ((_connection != null) && (_connection.State == System.Data.ConnectionState.Open))
                {
                    _connection.Close();
                }
            }

            return _maKenh;
        }
        #endregion
    }
}
