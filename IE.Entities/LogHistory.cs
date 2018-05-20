using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IE.Entities
{
    [Table("dbo.LogHistory")]
    public class LogHistory
    {
        [Key]
        public long LogHistoryID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string EntityType { get; set; }
        [Required]
        public string EntiryRef { get; set; }
        [Required]
        public DateTime Date { get; set; }
        
    }
}
