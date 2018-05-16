using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RahkaranEntities
{
    [Table("Fin3.DLType")]
    public class DLType
    {
        [Key]
        public long DLTypeID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Title_En { get; set; }
        public string DefaultCode { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsStatic { get; set; }
        public int? EntityCode { get; set; }
        public string Discriminator { get; set; }
        [Required]
        public Byte[] Version { get; set; }
    }
}
