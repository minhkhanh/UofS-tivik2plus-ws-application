using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;
using System.Data.OleDb;
using System.ServiceModel;

namespace TiviK2Plus_WebServiceApp
{
    public abstract class Abstract_DAO
    {
        #region Properties
        private static String CONNECTION_STRING = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                                                + HttpContext.Current.Server.MapPath(".")
                                                + @"/App_Data/tivik2plus.mdb";
        #endregion

        #region Methods
        protected OleDbConnection Connect()
        {
            OleDbConnection _connection = new OleDbConnection(CONNECTION_STRING);
            _connection.Open();
            return _connection;
        }
        #endregion
    }
}