using RMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Models.Common;

namespace RMS.Models
{
   public class PaymentModel:BaseModel
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
       // public string PaidBy { get; set; }

        public int TenantId { get; set; }

       // public string TenantName { get; set; }

        public int FloorId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedDate { get; set; }

        
        
       
        public char IsDue { get; set; }
        public decimal? DueAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? Advance { get; set; }
        public List<PaymentModel> list { get; set; }

        
    }

}
