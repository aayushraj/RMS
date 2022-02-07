using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Models.Common;

namespace RMS.Models
{
    public class SetupModel :BaseModel
    {
        public int Id { get; set; }

        public int FloorId { get; set; }
        public int Amount { get; set; }

        public List<SetupModel> list { get; set; }

    }
    public class RentSetupModel : BaseModel
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public int Amount { get; set; }
        public List<RentSetupModel> List { get; set; }

    }

    public class FloorSetup:BaseModel
    {

    }
}
