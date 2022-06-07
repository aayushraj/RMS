using RMS.Models;
using RMS.Models.Common;
using System.Linq;

namespace RMS.Repository
{
    public interface ICommonUtilityRepository
    {
        List<DDLModel> GetStates();
        List<DDLModel> GetDistricts(int stateId);
        TenantInfoModel GetFloor(int floorIdd);
        List<DDLModel> GetRelationships();
        string GetMonth(int id);
        List<DDLModel> GetTenantList();
    }
    public class CommonUtilityRepository : ICommonUtilityRepository
    {
        private readonly IDapperService _dapperService;
        public CommonUtilityRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
        public List<DDLModel> GetDistricts(int stateId)
        {
            string sql = @"Select DistrictId AS [Value],DistrictName AS [Text] from RMS_INFO_DISTRICT where StateId = @id";
            return _dapperService.Query<DDLModel>(sql, _dapperService.AddParam(stateId));
        }

        public TenantInfoModel GetFloor(int floorId)
        {
            string sql = @"Select rf.FloorId,f.FloorName from RMS_INFO rf
                            inner join RMS_INFO_Floor as f on f.FloorId = rf.FloorId
                            where id=@Id";
            var model= _dapperService.Query<TenantInfoModel>(sql, _dapperService.AddParam(floorId)).FirstOrDefault();
            return model;
        }

        public string GetMonth(int id)
        {
            var Month = "a";
            switch (id)
            {
                case 1:
                    Month = "January";
                    break;

                case 2:
                    Month = "February";
                    break;
                case 3:
                    Month = "March";
                    break;
                case 4:
                    Month = "April";
                    break;
                case 5:
                    Month = "May";
                    break;
                case 6:
                    Month = "June";
                    break;
                case 7:
                    Month = "July";
                    break;
                case 8:
                    Month = "August";
                    break;
                case 9:
                    Month = "September";
                    break;
                case 10:
                    Month = "October";
                    break;
                case 11:
                    Month = "November";
                    break;
                case 12:
                    Month = "December";
                    break;
            };

            return Month;
        }

        public List<DDLModel> GetRelationships()
        {
            var relationshipList = new List<DDLModel>()
                {
                    new DDLModel(){Text = "Mother", Value = "Mother"},
                    new DDLModel(){Text = "Father", Value = "Father"},
                    new DDLModel(){Text = "Brother", Value = "Brother"},
                    new DDLModel(){Text = "Sister", Value = "Sister"},
                    new DDLModel(){Text = "Daughter", Value = "Daughter"},
                    new DDLModel(){Text = "Son", Value = "Son"},
                };

            return relationshipList;
        }

        public List<DDLModel> GetStates()
        {
            string sql = @"SELECT StateId AS Value,StateName AS Text FROM RMS_INFO_STATE";
            return _dapperService.Query<DDLModel>(sql);
        }

        public List<DDLModel> GetTenantList()
        {
            string sql = @"select Id as Value, FirstName As Text From RMS_INFO";
            return _dapperService.Query<DDLModel>(sql);
        }
    }
}