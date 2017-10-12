using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPEyesFree
{
    /// <summary>
    /// SQL連線物件
    /// </summary>
    public class SqlHelper
    {
        //連線屬性
        SqlConnection _connection;

        public SqlHelper(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// 是否連線成功
        /// </summary>
        public bool IsConnection
        {
            get
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    try
                    {
                        _connection.Open();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        //物件清除
                        _connection.Close();
                        _connection.Dispose();
                    }
                }
                return true;
            }
        }
    }
}
