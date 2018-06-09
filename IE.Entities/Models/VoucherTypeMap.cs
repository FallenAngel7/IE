using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IE.Entities
{
    [Table("dbo.VoucherTypeMap")]
    public class VoucherTypeMap
    {
        [Key]
        public long VoucherTypeMapID { get; set; }
        public long Fin3VoucherTypeRef { get; set; }
        public string Fin3Title { get; set; }
        public int DelphiVoucherTypeRef { get; set; }
        public string DelphiTitle { get; set; }
        public DateTime CreationDate { get ; set; }      
    }
}
