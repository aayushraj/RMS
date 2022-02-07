//using RMS.Models;

//namespace RMS.Repository
//{
//    public interface IRentSetupRepository:IGenericRepository<RentSetupModel>
//    {
//        RentSetupModel GetByFloorId(int id);
//    }
//    public class RentSetupRepository : IRentSetupRepository
//    {
//        public bool Create(RentSetupModel model)
//        {
//            throw new System.NotImplementedException();
//        }

//        public bool Delete(RentSetupModel model)
//        {
//            throw new System.NotImplementedException();
//        }

//        public bool Edit(RentSetupModel model)
//        {
//            throw new System.NotImplementedException();
//        }

//        public RentSetupModel GetByFloorId(int id)
//        {
//            string sql = @"select * from RentSetup where FloorId=@id";
//            var parameter = DapperService.AddParam(id);
//            var model = DapperService.Query<RentSetupModel>(sql, parameter).FirstOrDefault();
//            return model;
//        }

//        public RentSetupModel GetById(int? id)
//        {
//            throw new System.NotImplementedException();
//        }

//        public List<RentSetupModel> GetList()
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}