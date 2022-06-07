using RMS.Models;
using RMS.Models.Common;
using RMS.Repository;

namespace RMS.Service.Helpers
{
    public interface ICommonUtilityService
    {
        List<DDLModel> GetStates();
        List<DDLModel> GetDistricts(int stateId);
        TenantInfoModel GetFloor(int id);
        List<DDLModel> GetRelationship();
        string GetMonth(int id);
        List<DDLModel> GetTenantList();
    }
    public class CommonUtilityService : ICommonUtilityService
    {
        private readonly ICommonUtilityRepository _commonUtilities;
        public CommonUtilityService(ICommonUtilityRepository commonUtilities)
        {
            _commonUtilities = commonUtilities;
        }


        public List<DDLModel> GetDistricts(int stateId)
        {
            return _commonUtilities.GetDistricts(stateId);
        }

        public TenantInfoModel GetFloor(int id)
        {
            return _commonUtilities.GetFloor(id);
        }

        public string GetMonth(int id)
        {
            return _commonUtilities.GetMonth(id);
        }

        public List<DDLModel> GetRelationship()
        {
            return _commonUtilities.GetRelationships();
        }

        public List<DDLModel> GetStates()
        {
            return _commonUtilities.GetStates();
        }

        public List<DDLModel> GetTenantList()
        {
            return _commonUtilities.GetTenantList();
        }
    }


}
