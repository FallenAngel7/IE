using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelphiEntities
{
    public class AccVchItm
    {
        public long VchItmId { get; set; }
        public int Seq { get; set; }
        public long HdrRef { get; set; }
        public string SLRef { get; set; }
        public string DLRef { get; set; }
        public string Descr { get; set; }
        public float Debit { get; set; }
        public float Credit { get; set; }
        public float CurVal { get; set; }
        public string DlFive { get; set; }
        public string DlSix { get; set; }
        public int Num { get; set; }
        public DateTime VchDate { get; set; }
        public string Ctgry { get; set; }
        public string State { get; set; }
        public string SystemsRef { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int TempNum { get; set; }
        public int branch_code { get; set; }
    }
}
