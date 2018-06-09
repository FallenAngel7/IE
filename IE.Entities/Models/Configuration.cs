using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IE.Entities
{
    public class Configuration
    {
        [Key]
        public long ConfigurationID { get; set; }
        [MaxLength(100)]
        [Index(IsUnique =true)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
