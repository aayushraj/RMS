using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Models
{
    public class DashboardModel
    {
        public string TenantName { get; set; }
        public int  TenantId { get; set; }
        public int  LastPaid { get; set; }
        public int ActiveTenant{ get; set; }
        public decimal? DueAmount { get; set; }
        public decimal? TotalReceivedAmount{ get; set; }
        public int PaidAmount { get; set; }
        public decimal? Advance { get; set; }
        public List<DashboardModel> list { get; set; }
        public  IList<SetupModel> Setuplist { get; set; }
    }
}
