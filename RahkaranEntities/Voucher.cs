using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahkaranEntities
{
    public class Voucher
    {
        public long VoucherID { get; set; }
        public long LedgerRef { get; set; }
        public long FiscalYearRef { get; set; }
        public long BranchRef { get; set; }
        public int Number { get; set; }
        public int Sequence { get; set; }
        public int DailyNumber { get; set; }
        public string AuxiliaryNumber { get; set; }
        public DateTime Date { get; set; }
        public long VoucherTypeRef { get; set; }
        public long Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public long LastModifier { get; set; }
        public DateTime LastModificationDate { get; set; }
        public string Description { get; set; }
        public string Description_En { get; set; }
        public int State { get; set; }
        public int IsTemporary { get; set; }
        public int IsCurrencyBased { get; set; }
        public int IsExternal { get; set; }
        public long ReferenceNumber { get; set; }
        public int ShowCurrencyFields { get; set; }
    }
}
