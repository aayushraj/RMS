using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Models.Common
{
    public class BaseModel
    {
        public bool IsSuccess { get; set; }
        public string SuccessMessage { get; set; }
        public string FailureMessage { get; set; }
        public int Status { get; set; }
        public int flag { get; set; }
    }
}
