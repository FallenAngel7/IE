using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelphiEntities
{
    public class AccVchHdr
    {             
        public long HdrVchID { get; set; }
        public int Num { get; set; }
        public DateTime VchDate { get; set; }
        public int LocalNum { get; set; }
        public string Ctgry { get; set; }
        public string State { get; set; }
        public float Amount { get; set; }
        public string SystemsRef { get; set; }
        public int ExchHdrRef { get; set; }
        public char Exchangable { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int DailyId { get; set; }
        public int TempNum { get; set; }
        public int Creator { get; set; }
        public int Confirmer { get; set; }
        public int BranchCode { get; set; }
        public string HdrDesc { get; set; }
        public string HdrLatinDesc { get; set; }
        public int GroupRef { get; set; }
    }
}
