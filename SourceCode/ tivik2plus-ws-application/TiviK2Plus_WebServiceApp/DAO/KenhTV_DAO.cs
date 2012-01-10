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
        private const String SQL_QUERY_GET_KENH_TV_LIST = @"SELECT MaKenh, TenMaKenh "
                                                  + @"FROM KenhTivi ";
                                                  //+ @"WHERE ";
        #endregion

        #region Methods
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

                    _kenhTVList.Add(buffer);
                }

            }
            catch (Exception ex)
            {
                _kenhTVList = new List<KenhTV_DTO>();
                return _kenhTVList;
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
        #endregion
    }
}
