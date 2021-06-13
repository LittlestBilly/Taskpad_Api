using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {

        private readonly IConfiguration _config;

        public string ConnStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connString = _config.GetConnectionString(ConnStringName);

            using (IDbConnection conn = new SqlConnection(connString))
            {
                var data = await conn.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connString = _config.GetConnectionString(ConnStringName);

            using (IDbConnection conn = new SqlConnection(connString))
            {
                await conn.ExecuteAsync(sql, parameters);
            }
        }
    }
}
