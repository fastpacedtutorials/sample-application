using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class DataAccessHelper: IDataAccessHelper
    {
        private string  _connectionString;
        public DataAccessHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<T> SelectList<T>(string command)
        {
            List<T> result = new List<T>();
            using (var connection = new SqlConnection(_connectionString))
            {
                result = connection.Query<T>(command).ToList();
            }
            return result;
        }
    }
}
