using RMS.Models.Common;

namespace RMS.Models
{
    public class TenantInfoModel : BaseModel  // model ma chahi data haru  declare garincha.. TenantModel is inherited rom BaseModel
    {
        public int FloorNumber { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal Contact { get; set; }
        public int State { get; set; }
        public int? District { get; set; }
        public string City { get; set; }
        public int WardNo { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        
        public List<TenantInfoModel> List { get; set; }
        public string[] Name { get; set; }

        public string dummy = "null";

        public FamilyInfoModel familyinfo { get; set; }
        public IList<FamilyInfoModel> FamilyList{ get; set; }

    }

    public class StateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }

    public class DistrictModel
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
    }

    public class FloorModel
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; }
    }

}
