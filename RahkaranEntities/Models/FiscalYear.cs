using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RahkaranEntities
{
    [Table("Gnr3.FiscalYear")]
    public class FiscalYear
    {
        [Key]
        public long FiscalYearID { get; set; }
        [MaxLength(128)]
        [Required]
        public string Title { get; set; }
        [MaxLength(128)]
        public string Title_En { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
        [Required]
        public Byte[] Version { get; set; }
    }
}
