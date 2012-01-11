using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.OleDb;

namespace TiviK2Plus_WebServiceApp
{
    public class LichPhatSong_DAO : Abstract_DAO
    {
        #region Properties
        private static LichPhatSong_DAO _lichPhatSong_DAO = null;
        #endregion

        #region Constants
        private const String SQL_QUERY_GET_LICH_PHAT = @"SELECT NoiDung "
                                                     + @"FROM LichPhatSong "
                                                     + @"WHERE MaKenh = " + SQL_PARA_MA_KENH
                                                     + " AND (DateDiff(\"y\", Ngay, " + SQL_PARA_NGAY + ") = \"0\")";

        private const String SQL_PARA_MA_LICH_PHAT_SONG = @"@maLichPhatSong";
        private const String SQL_PARA_MA_KENH = @"@maKenh";
        private const String SQL_PARA_NGAY = @"@ngay";
        private const String SQL_PARA_NOI_DUNG = @"@noiDung";
        #endregion

        #region Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        private LichPhatSong_DAO()
        { 
        }

        /// <summary>
        /// Get object represent for LichPhatSong_DAO class
        /// </summary>
        public static LichPhatSong_DAO Object
        {
            get
            {
                if (_lichPhatSong_DAO == null)
                {
                    _lichPhatSong_DAO = new LichPhatSong_DAO();
                }

                return _lichPhatSong_DAO;
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
            OleDbConnection _connection = null;
            String _lichPhatSong = @"";
            int maKenh = KenhTV_DAO.Object.GetMaKenh(tenMaKenh);

            try
            {
                _connection = Connect();
                OleDbCommand _command = new OleDbCommand(SQL_QUERY_GET_LICH_PHAT, _connection);

                OleDbParameter _parameter = new OleDbParameter(SQL_PARA_MA_KENH, OleDbType.Integer);
                _parameter.Value = maKenh;
                _command.Parameters.Add(_parameter);

                _parameter = new OleDbParameter(SQL_PARA_NGAY, OleDbType.Date);
                _parameter.Value = ngay;
                _command.Parameters.Add(_parameter);

                OleDbDataReader _dataReader = _command.ExecuteReader();
                while (_dataReader.Read())
                {
                    _lichPhatSong = _dataReader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                _lichPhatSong = @"";
            }
            finally
            {
                if ((_connection != null) && (_connection.State == System.Data.ConnectionState.Open))
                {
                    _connection.Close();
                }
            }

            return _lichPhatSong;
        }
        #endregion
    }
}
