using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Models.Common;

namespace RMS.Models
{

    public class FamilyInfoModel:BaseModel
    {
        
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal Contact { get; set; }
        public string City { get; set; }
        public int  State { get; set; }
        public int District { get; set; }
        public int WardNo { get; set; }
        public int FloorId { get; set; }

        public string Gender { get; set; }
        public string Relationship { get; set; }
        public DateTime DOB { get; set; }

        public List<FamilyInfoModel> List { get; set; }
    }

    public class FamilyInfoViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
