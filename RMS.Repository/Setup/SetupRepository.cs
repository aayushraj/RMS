//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;
//using Microsoft.Data.SqlClient;
//using RMS.Models;

//namespace RMS.Repository
//{
//    public interface ISetupRepository : IGenericRepository<SetupModel>
//    {

//    }
//    public class SetupRepository:ISetupRepository
//    {
//        private string connString = ConfigurationManager.ConnectionStrings["DBstring"].ToString();

//        public bool Create(SetupModel model)
//        {
//            string sql = @"Insert into RentSetup values(@FloorId,@Amount)";
//           // SqlConnection con = new SqlConnection(connString);

//            //con.Open();

//            var parameters = DapperService.AddParam(model);

//            int affectrows = DapperService.Execute(sql, parameters);

//            //con.Close();

//            if (affectrows >= 1)
//                return true;
//            else
//                return false;
//        }

//        public bool Delete(SetupModel model)
//        {
//            string sql = @"Delete from RentSetup where id=@id";
//            var parameter = DapperService.AddParam(model.Id);
//            int affectedrows = DapperService.Execute(sql, parameter);

//            if (affectedrows >= 1)
//                return true;
//            else
//                return false;
//        }

//        public bool Edit(SetupModel model)
//        {
//            string sql = @"update RentSetup set FloorId=@floorId , Amount =@Amount where id=@id";
//            SqlConnection con = new SqlConnection(connString);

//            con.Open();
//            var parameter = DapperService.AddParam(model);
//            int affectedrows = DapperService.Execute(sql, parameter);

//            if (affectedrows >= 1)
//                return true;
//            else
//                return false;

//        }

//        public SetupModel GetById(int? id)
//        {
//            string sql = @"select * from RentSetup where id=@id";
//            SqlConnection con = new SqlConnection(connString);

//            var parameter = DapperService.AddParam(id);
//            SetupModel model = new SetupModel();

//            model = DapperService.Query<SetupModel>(sql, parameter).FirstOrDefault();

//            return model;

//        }
//        public SetupModel GetByFloorId(int? id)
//        {
//            string sql = @"select * from RentSetup where FloorId=@id";
//            var parameter = DapperService.AddParam(id);
//            var model = DapperService.Query<SetupModel>(sql, parameter).FirstOrDefault();
//            return model;
//        }

//        public List<SetupModel> GetList()
//        {
//            string sql = @"Select * from RentSetup";

//            SqlConnection con = new SqlConnection(connString);

//            var list = DapperService.Query<SetupModel>(sql);

//            return list;

//        }
//    }
//}
