//using RMS.Models;
//using RMS.Repository;

//namespace RMS.Service.SetUp
//{
//    public interface IRentSetupService:IGenericService<RentSetupModel>
//    {
//        RentSetupModel GetByFloorId(int id);
//    }
//    public class RentSetupService : IRentSetupService
//    {
//        private readonly IRentSetupRepository repo;
//        public RentSetupService()
//        {
//            repo = new RentSetupRepository();
//        }
//        public RentSetupModel Create(RentSetupModel model)
//        {
//            throw new NotImplementedException();
//        }

//        public RentSetupModel Delete(RentSetupModel model)
//        {
//            throw new NotImplementedException();
//        }

//        public RentSetupModel Edit(RentSetupModel model)
//        {
//            throw new NotImplementedException();
//        }

//        public RentSetupModel GetById(int? id)
//        {
//            throw new NotImplementedException();
//        }
//        public RentSetupModel GetByFloorId(int id)
//        {
//            return (repo.GetByFloorId(id));
//        }
//        public List<RentSetupModel> GetList()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
