using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RahkaranEntities
{
    [Table("Gnr3.Branch")]
    public class Branch
    {
        [Key]
        public long BranchID { get; set; }
        [MaxLength(64)]
        [Required]
        public string Code { get; set; }
        [MaxLength(128)]
        [Required]
        public string Title { get; set; }
        [MaxLength(128)]
        public string Title_En { get; set; }
        [Required]
        public bool IsStatic { get; set; }
        [Required]
        public Byte[] Version { get; set; }
    }
}
