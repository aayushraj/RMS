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
        List<T> SPQuery<T>(string sql,DynamicParameters param);
        List<T> Query<T>(string sql, DynamicParameters param);
        Task<List<T>> QueryAsync<T>(string sql, DynamicParameters param);
        int Execute(string sql, DynamicParameters param);
        DynamicParameters AddParam(object param);
    }
    public class DapperService : IDapperService
    {
        private readonly string _connection;
        public DapperService(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DBString");
        }

        public List<T> Query<T>(string sql)
        {
            using (var con = new SqlConnection(_connection))
            {
                con.Open();
                return con.Query<T>(sql).ToList();
            }
        }
        public List<T> SPQuery<T>(string sp,DynamicParameters param)
        {
            using (var con = new SqlConnection(_connection))
            {
                con.Open();
                return con.Query<T>(sp,param,commandType:CommandType.StoredProcedure).ToList();
            }
        }

        public List<T> Query<T>(string sql, DynamicParameters param)
        {
            using (var con = new SqlConnection(_connection))
            {
                con.Open();
                return con.Query<T>(sql, param).ToList();
            }
        }
        public async Task<List<T>> QueryAsync<T>(string sql, DynamicParameters param)
        {
            using (var con = new SqlConnection(_connection))
            {
                con.Open();
                return (List<T>)await con.QueryAsync<T>(sql, param);
            }
        }

        public int Execute(string sql, DynamicParameters param)
        {
            using (var con = new SqlConnection(_connection))
            {
                con.Open();
                return con.Execute(sql, param);
            }
        }

        public DynamicParameters AddParam(object obj)
        {
            Type objType = obj.GetType();
            DynamicParameters param = new();

            if (objType.Name.Equals(typeof(string).Name))
            {
                param.Add("@Flag", obj);

                return param;
            }
            if (obj.GetType().IsValueType)
            {
                param.Add("id", obj);

                return param;
            }
            

            foreach (var item in obj.GetType().GetProperties())
            {
                param.Add(item.Name, item.GetValue(obj));
            }

            return param;
        }

    }
}
