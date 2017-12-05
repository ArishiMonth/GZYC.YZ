using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZYC.YZ.Models.Common
{
    public  class LogInfo
    {
        public int OID { get; set; }
        public int? Ltype { get; set; }
        public int? Ltitle { get; set; }
        public string Luser { get; set; }
        public string Lip { get; set; }
        public string Lcontent { get; set; }
        public System.DateTime? Ldate { get; set; }
        public bool? DeleteMark { get; set; }
        public System.DateTime? BeginTime { get; set; }

        public System.DateTime? EndTime { get; set; }

        public string Ldatestr { get; set; }

        public string LtypeStr { get; set; }
    }
}
