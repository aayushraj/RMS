using RMS.Models;
using RMS.Repository;

namespace RMS.Service.SetUp
{
    public interface IRentSetupService : IGenericService<RentSetupModel>
    {
        RentSetupModel GetByFloorId(int id);
    }
    public class RentSetupService : IRentSetupService
    {
        private readonly IRentSetupRepository _rentSer;
        public RentSetupService(IRentSetupRepository rentSetupRepository)
        {
            _rentSer =  rentSetupRepository;
        }
        public RentSetupModel Create(RentSetupModel model)
        {
            throw new NotImplementedException();
        }

        public RentSetupModel Delete(RentSetupModel model)
        {
            throw new NotImplementedException();
        }

        public RentSetupModel Edit(RentSetupModel model)
        {
            throw new NotImplementedException();
        }

        public RentSetupModel GetById(int? id)
        {
            throw new NotImplementedException();
        }
        public RentSetupModel GetByFloorId(int id)
        {
            return (_rentSer.GetByFloorId(id));
        }
        public List<RentSetupModel> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
