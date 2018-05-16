using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelphiEntities
{
    [Table("Acc.AccVchType")]
    public class AccVchType
    {   
        [MaxLength(5)]
        [Index(IsUnique = true)]
        public string Code { get; set; }
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }
        [MaxLength(30)]
        public string LatinTitle { get; set; }
    }
}
