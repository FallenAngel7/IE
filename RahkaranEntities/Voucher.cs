using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RahkaranEntities
{
    [Table("Fin3.Voucher")]
    public class Voucher
    {
        [Key]
        public long VoucherID { get; set; }
        [Required]
        public long LedgerRef { get; set; }
        [Required]
        public long FiscalYearRef { get; set; }
        [Required]
        public long BranchRef { get; set; }
        public int? Number { get; set; }
        [Required]
        public int Sequence { get; set; }
        [Required]
        public int DailyNumber { get; set; }
        [MaxLength(16)]
        public string AuxiliaryNumber { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public long VoucherTypeRef { get; set; }
        [Required]
        public long Creator { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public long LastModifier { get; set; }
        [Required]
        public DateTime LastModificationDate { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
        [MaxLength(512)]
        public string Description_En { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public bool IsTemporary { get; set; }
        [Required]
        public bool IsCurrencyBased { get; set; }
        [Required]
        public bool IsExternal { get; set; }
        public long? ReferenceNumber { get; set; }
        [Required]
        public bool ShowCurrencyFields { get; set; }
        [Required]
        public Byte[] Version { get; set; }
    }
}
