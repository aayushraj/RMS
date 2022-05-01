using RMS.Models;

namespace RMS.Repository
{
    public interface IRentSetupRepository
    {
        RentSetupModel GetByFloorId(int id);
        bool Create(RentSetupModel model); 
        bool Delete(RentSetupModel model);
        bool Edit(RentSetupModel model);
        RentSetupModel GetById(int? id);
        List<RentSetupModel> GetList();


    }
    public class RentSetupRepository : IRentSetupRepository
    {
        private readonly IDapperService _dapper;
        public RentSetupRepository(IDapperService Dapper)
        {
            _dapper = Dapper;
        }
        public bool Create(RentSetupModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(RentSetupModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(RentSetupModel model)
        {
            throw new System.NotImplementedException();
        }

        public RentSetupModel GetByFloorId(int id)
        {
            string sql = @"select * from RentSetup where FloorId=@id";
            var parameter = _dapper.AddParam(id);
            var model = _dapper.Query<RentSetupModel>(sql, parameter).FirstOrDefault();
            return model;
        }

        public RentSetupModel GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public List<RentSetupModel> GetList()
        {
            throw new System.NotImplementedException();
        }
    }
}