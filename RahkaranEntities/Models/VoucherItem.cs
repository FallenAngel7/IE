using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RahkaranEntities
{
    [Table("Fin3.VoucherItem")]
    public class VoucherItem
    {
        [Key]
        public long VoucherItemID { get; set; }
        public long VoucherRef { get; set; }
        public long BranchRef { get; set; }
        public int RowNumber { get; set; }
        public long AccountGroupRef { get; set; }
        public long GLRef { get; set; }
        public long SLRef { get; set; }
        public string SLCode { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public long CurrencyRef { get; set; }
        public long BaseCurrencyRef { get; set; }
        public long TargetCurrencyRef { get; set; }
        public decimal TargetCurrencyDebit { get; set; }
        public decimal TargetCurrencyCredit { get; set; }
        public int IsCurrencyBased { get; set; }
        public string Description { get; set; }
        public string Description_En { get; set; }
        public string FollowUpNumber { get; set; }
        public DateTime FollowUpDate { get; set; }
        public string DLLevel4 { get; set; }
        public string DLLevel5 { get; set; }
        public string DLLevel6 { get; set; }
        public string DLLevel7 { get; set; }
        public string DLLevel8 { get; set; }
        public string DLLevel9 { get; set; }
        public long DLTypeRef4 { get; set; }
        public long DLTypeRef5 { get; set; }
        public long DLTypeRef6 { get; set; }
        public long DLTypeRef7 { get; set; }
        public long DLTypeRef8 { get; set; }
        public long DLTypeRef9 { get; set; }
    }
}
