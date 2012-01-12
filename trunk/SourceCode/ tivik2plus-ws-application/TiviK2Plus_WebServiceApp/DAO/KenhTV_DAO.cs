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
        private const String SQL_QUERY_GET_KENH_TV_LIST = @"SELECT MaKenh, TenMaKenh, MoTaKenh, LinkPhat, NguonGoc, MoTaRutTrich, LinkHong, LichHong, ConHoatDong "
                                                        + @"FROM KenhTivi";
        private const String SQL_QUERY_ADD_KENH_TV = @"INSERT INTO KenhTivi(TenMaKenh, LinkPhat, ConHoatDong, NguonGoc, MoTaRutTrich, MoTaKenh, LinkHong, LichHong) "
                                                   + @"VALUES ("
                                                   + SQL_PARA_TEN_MA_KENH + ", " + SQL_PARA_LINK + ", " + SQL_PARA_CON_HOAT_DONG + ", " + SQL_PARA_NGUON_GOC + ", " + SQL_PARA_MO_TA_RUT_TRICH+ ", "
                                                   + SQL_PARA_MO_TA_KENH + ", " + SQL_PARA_LINK_HONG + ", " + SQL_PARA_LICH_HONG
                                                   + @")";
        private const String SQL_QUERY_GET_MA_KENH = @"SELECT MaKenh "
                                                   + @"FROM KenhTivi "
                                                   + @"WHERE ConHoatDong = " + SQL_PARA_CON_HOAT_DONG
                                                   + @" AND TenMaKenh = " + SQL_PARA_TEN_MA_KENH;
        private const String SQL_QUERY_SEARCH_KENHTV = @"SELECT MaKenh, TenMaKenh, MoTaKenh, LinkPhat, NguonGoc, MoTaRutTrich, LinkHong, LichHong "
                                                     + @"FROM KenhTivi "
                                                     + @"WHERE ((ConHoatDong = " + SQL_PARA_CON_HOAT_DONG + ")"
                                                     + " AND ((TenMaKenh Like " + SQL_PARA_TEN_MA_KENH + ")"
                                                     + " OR (MoTaKenh Like " + SQL_PARA_MO_TA_KENH + ")"
                                                     + " OR (LinkPhat Like " + SQL_PARA_LINK + ")"
                                                     + " OR (NguonGoc Like " + SQL_PARA_NGUON_GOC + ")"
                                                     + " OR (MoTaRutTrich Like " + SQL_PARA_MO_TA_RUT_TRICH + ")"
                                                     + @"))";
        private const String SQL_QUERY_GET_LINK = @"SELECT LinkPhat "
                                                + @"FROM KenhTivi "
                                                + @"WHERE ((ConHoatDong = " + SQL_PARA_CON_HOAT_DONG + ")"
                                                + " AND (TenMaKenh Like " + SQL_PARA_TEN_MA_KENH + ")"
                                                + @")";
        private const String SQL_QUERY_UPDATE_KENHTV = @"UPDATE KenhTivi "
                                                     + @"SET TenMaKenh = " + SQL_PARA_TEN_MA_KENH + ", "
                                                     + @"LinkPhat = " + SQL_PARA_LINK + ", "
                                                     + @"ConHoatDong = " + SQL_PARA_CON_HOAT_DONG + ", "
                                                     + @"NguonGoc = " + SQL_PARA_NGUON_GOC + ", "
                                                     + @"MoTaRutTrich = " + SQL_PARA_MO_TA_RUT_TRICH + ", "
                                                     + @"MoTaKenh = " + SQL_PARA_MO_TA_KENH + ", "
                                                     + @"LinkHong = " + SQL_PARA_LINK_HONG + ", "
                                                     + @"LichHong = " + SQL_PARA_LICH_HONG + " "
                                                     + @"WHERE MaKenh = " + SQL_PARA_MA_KENH;
        private const String SQL_QUERY_DELETE_KENHTV = @"UPDATE KenhTivi "
                                                     + @"SET ConHoatDong = " + SQL_PARA_CON_HOAT_DONG + " "
                                                     + @"WHERE MaKenh = " + SQL_PARA_MA_KENH;

        private const String SQL_PARA_MA_KENH = @"@maKenh";
        private const String SQL_PARA_TEN_MA_KENH = @"@tenMaKenh";
        private const String SQL_PARA_MO_TA_KENH = @"@moTaKenh";
        private const String SQL_PARA_LINK = @"@link";
        private const String SQL_PARA_CON_HOAT_DONG = @"@conHoatDong";
        private const String SQL_PARA_NGUON_GOC = @"@nguonGoc";
        private const String SQL_PARA_MO_TA_RUT_TRICH = @"@moTaRutTrich";
        private const String SQL_PARA_LINK_HONG = @"@linkHong";
        private const String SQL_PARA_LICH_HONG = @"@lichHong";
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

                    if (!_dataReader.IsDBNull(6))
                    {
                        buffer.LinkHong = _dataReader.GetInt32(6);
                    }

                    if (!_dataReader.IsDBNull(7))
                    {
                        buffer.LichHong = _dataReader.GetInt32(7);
                    }

                    if (!_dataReader.IsDBNull(8))
                    {
                        buffer.ConHoatDong = _dataReader.GetBoolean(8);
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

                _parameter = new OleDbParameter(SQL_PARA_LINK_HONG, OleDbType.Integer);
                _parameter.Value = kenhTV.LinkHong;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_LICH_HONG, OleDbType.Integer);
                _parameter.Value = kenhTV.LichHong;
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

                OleDbParameter _parameter;
                _parameter = new OleDbParameter(SQL_PARA_CON_HOAT_DONG, OleDbType.Boolean);
                _parameter.Value = Constants.KENH_TV_CON_HOAT_DONG;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_TEN_MA_KENH, OleDbType.VarChar);
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

        /// <summary>
        /// Tìm kiếm kênh TV với khóa gần đúng
        /// </summary>
        /// <param name="key">Từ khóa tìm kiếm</param>
        /// <returns>List<KenhTV_DTO></returns>
        public List<KenhTV_DTO> SearchKenhTVWithKey(String key)
        {
            OleDbConnection _connection = null;
            List<KenhTV_DTO> _kenhTVList = new List<KenhTV_DTO>();

            try
            {
                _connection = Connect();
                OleDbCommand _command = new OleDbCommand(SQL_QUERY_SEARCH_KENHTV, _connection);

                OleDbParameter _parameter;
                _parameter = new OleDbParameter(SQL_PARA_CON_HOAT_DONG, OleDbType.Boolean);
                _parameter.Value = Constants.KENH_TV_CON_HOAT_DONG;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_TEN_MA_KENH, OleDbType.VarChar);
                _parameter.Value = "%" + key + "%";
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_MO_TA_KENH, OleDbType.VarChar);
                _parameter.Value = "%" + key + "%";
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_LINK, OleDbType.VarChar);
                _parameter.Value = "%" + key + "%";
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_NGUON_GOC, OleDbType.VarChar);
                _parameter.Value = "%" + key + "%";
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_MO_TA_RUT_TRICH, OleDbType.VarChar);
                _parameter.Value = "%" + key + "%";
                _command.Parameters.Add(_parameter);

                OleDbDataReader _dataReader = _command.ExecuteReader();
                KenhTV_DTO _buffer;
                while (_dataReader.Read())
                {
                    _buffer = new KenhTV_DTO();

                    _buffer.MaKenh = _dataReader.GetInt32(0);

                    if (!_dataReader.IsDBNull(1))
                    {
                        _buffer.TenMaKenh = _dataReader.GetString(1);
                    }

                    if (!_dataReader.IsDBNull(2))
                    {
                        _buffer.MoTaKenh = _dataReader.GetString(2);
                    }

                    if (!_dataReader.IsDBNull(3))
                    {
                        _buffer.Link = _dataReader.GetString(3);
                    }

                    if (!_dataReader.IsDBNull(4))
                    {
                        _buffer.NguonGoc = _dataReader.GetString(4);
                    }

                    if (!_dataReader.IsDBNull(5))
                    {
                        _buffer.MoTaRutTrich = _dataReader.GetString(5);
                    }

                    if (!_dataReader.IsDBNull(6))
                    {
                        _buffer.LinkHong = _dataReader.GetInt32(6);
                    }

                    if (_dataReader.IsDBNull(7))
                    {
                        _buffer.LichHong = _dataReader.GetInt32(7);
                    }

                    _kenhTVList.Add(_buffer);
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
        /// Lấy link phát với tên mã kênh (tìm kiếm đúng)
        /// </summary>
        /// <param name="tenMaKenh">tên mã kênh cần lấy link</param>
        /// <returns>String</returns>
        public String GetLinkPhatWithTenMaKenh(String tenMaKenh)
        {
            String _linkPhat = @"";
            OleDbConnection _connection = null;

            try
            {
                _connection = Connect();
                OleDbCommand _command = new OleDbCommand(SQL_QUERY_GET_LINK, _connection);

                OleDbParameter _parameter;
                _parameter = new OleDbParameter(SQL_PARA_CON_HOAT_DONG, OleDbType.Boolean);
                _parameter.Value = Constants.KENH_TV_CON_HOAT_DONG;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_TEN_MA_KENH, OleDbType.VarChar);
                _parameter.Value = tenMaKenh;
                _command.Parameters.Add(_parameter);

                OleDbDataReader _dataReader = _command.ExecuteReader();
                while (_dataReader.Read())
                {
                    _linkPhat = _dataReader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                _linkPhat = @"";
            }
            finally
            {
                if ((_connection != null) && (_connection.State == System.Data.ConnectionState.Open))
                {
                    _connection.Close();
                }
            }

            return _linkPhat;
        }

        /// <summary>
        /// Cập nhật thông tin Kênh TV
        /// </summary>
        /// <param name="kenhTV">Thông tin kênh TV dùng để update</param>
        /// <returns>
        ///     true:   Update thành công
        ///     false:  Update thất bại
        /// </returns>
        public bool UpdateKenhTV(KenhTV_DTO kenhTV)
        {
            OleDbConnection _connection = null;
            int _result = 0;

            try
            {
                _connection = Connect();
                OleDbCommand _command = new OleDbCommand(SQL_QUERY_UPDATE_KENHTV, _connection);

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

                _parameter = new OleDbParameter(SQL_PARA_LINK_HONG, OleDbType.Integer);
                _parameter.Value = kenhTV.LinkHong;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_LICH_HONG, OleDbType.Integer);
                _parameter.Value = kenhTV.LichHong;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_MA_KENH, OleDbType.Integer);
                _parameter.Value = kenhTV.MaKenh;
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
                return Constants.UPDATE_KENH_TV_FAIL;
            }

            return Constants.UPDATE_KENH_TV_SUCCEED;
        }

        /// <summary>
        /// Xóa thông tin kênh tv không còn hữu hiệu nữa
        /// </summary>
        /// <param name="maKenh">mã kênh cần xóa</param>
        /// <returns>
        ///     true:   Xóa thành công
        ///     false:  Xóa thất bại
        /// </returns>
        public bool DeleteKenhTV(int maKenh)
        {
            OleDbConnection _connection = null;
            int _result = 0;

            try
            {
                _connection = Connect();
                OleDbCommand _command = new OleDbCommand(SQL_QUERY_DELETE_KENHTV, _connection);

                OleDbParameter _parameter;
                _parameter = new OleDbParameter(SQL_PARA_CON_HOAT_DONG, OleDbType.Boolean);
                _parameter.Value = Constants.DELETED_RECORD;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_MA_KENH, OleDbType.Integer);
                _parameter.Value = maKenh;
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
                return Constants.DELETE_KENH_TV_FAIL;
            }

            return Constants.DELETE_KENH_TV_SUCCEED;
        }
        #endregion

        #region Akhoi operations

        public string LayLinkNguon(string tenMaKenh)
        {
            OleDbConnection connection = null;
            string result = "";

            try
            {
                connection = Connect();
                OleDbCommand _command = new OleDbCommand("select NguonGoc from KenhTivi where TenMaKenh = @tenMaKenh", connection);

                OleDbParameter _parameter = new OleDbParameter("@tenMaKenh", OleDbType.VarChar);
                _parameter.Value = tenMaKenh;
                _command.Parameters.Add(_parameter);

                OleDbDataReader _dataReader = _command.ExecuteReader();
                if (_dataReader.Read())
                {
                    if (!_dataReader.IsDBNull(0))
                        result = _dataReader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                result = "";
            }
            finally
            {
                if ((connection != null) && (connection.State == System.Data.ConnectionState.Open))
                {
                    connection.Close();
                }
            }

            return result;
        }

        public string LayMoTaRutTrich(string tenMaKenh)
        {
            OleDbConnection connection = null;
            string result = "";

            try
            {
                connection = Connect();
                OleDbCommand _command = new OleDbCommand("select MoTaRutTrich from KenhTivi where TenMaKenh = @tenMaKenh", connection);

                OleDbParameter _parameter = new OleDbParameter("@tenMaKenh", OleDbType.VarChar);
                _parameter.Value = tenMaKenh;
                _command.Parameters.Add(_parameter);

                OleDbDataReader _dataReader = _command.ExecuteReader();
                if (_dataReader.Read())
                {
                    if (!_dataReader.IsDBNull(0))
                        result = _dataReader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                result = "";
            }
            finally
            {
                if ((connection != null) && (connection.State == System.Data.ConnectionState.Open))
                {
                    connection.Close();
                }
            }

            return result;
        }

        #endregion
    }
}
