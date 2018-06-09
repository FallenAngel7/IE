using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IE.Entities
{
    public class VoucherMap
    {
        [Key]       
        public long VoucherMapID { get; set; }
        public long Fin3VoucherRef { get; set; }
        public string Fin3Sequence { get; set; }
        public long GNR3FiscalYearRef { get; set; }
        public long DelphiVoucherRef { get; set; }
        public string DelphiTempNum { get; set; }        
        public int DelphiYear { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
