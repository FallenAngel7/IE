using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahkaranEntities
{
    [Table("Fin3.VoucherType")]
    public class VoucherType
    {
        [Key]
        [Required]
        public long VoucherTypeID { get; set; }
        public int? Code { get; set; }
        [Required]
        public string Title { get; set; }
        public string Title_En { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsStatic { get; set; }
        [Required]
        public Byte[] Version { get; set; }        
        public string OwnerSystem { get; set; }
    }
}
