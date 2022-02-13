using RMS.Models.Common;

namespace RMS.Repository
{
    public interface ICommonUtilityRepository
    {
        List<DDLModel> GetStates();
        List<DDLModel> GetDistricts(int stateId);
        List<DDLModel> GetFloor(int floorIdd);
        List<DDLModel> GetRelationships();
        string GetMonth(int id);
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

        public List<DDLModel> GetFloor(int floorId)
        {
            string sql = @"Select * from RMS_INFO where id=@Id";
            return _dapperService.Query<DDLModel>(sql, _dapperService.AddParam(floorId));
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
    }
}