using System.Configuration;
using System.Data;
using System.Data.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace RMS.Repository
{
    public interface IDapperService
    {
        List<T> Query<T>(string sql);
        List<T> Query<T>(string sql, DynamicParameters param);
        int Execute(string sql, DynamicParameters param);
        DynamicParameters AddParam(object param);
    }
    public class DapperService : IDapperService
    {
        private readonly IConfiguration _configuration;
        private static string? connstring;
        public DapperService(IConfiguration configuration)
        {
            _configuration = configuration;
            connstring = _configuration.GetConnectionString("DBString");
        }

        public List<T> Query<T>(string sql)
        {
            using (IDbConnection con = new SqlConnection(connstring))
            {
                con.Open();
                return con.Query<T>(sql).ToList();
            }
        }

        public List<T> Query<T>(string sql, DynamicParameters param)
        {
            using (IDbConnection con = new SqlConnection(connstring))
            {
                con.Open();
                return con.Query<T>(sql, param).ToList();
            }
        }

        public int Execute(string sql, DynamicParameters param)
        {
            using (IDbConnection con = new SqlConnection(connstring))
            {
                con.Open();
                return con.Execute(sql, param);
            }
        }

        public DynamicParameters AddParam(object param)
        {
            // param.GetType().GetProperties();

            DynamicParameters tset = new DynamicParameters();
            if (param.GetType().IsValueType)
            {
                tset.Add("id", param);

                return tset;
            }


            foreach (var item in param.GetType().GetProperties())
            {
                tset.Add(item.Name, item.GetValue(param));
            }

            return tset;


        }

    }
}
