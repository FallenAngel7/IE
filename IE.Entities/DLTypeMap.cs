using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IE.Entities
{
    public class DLTypeMap
    {
        [Key]
        public long DLTypeMapID { get; set; }
        public long Fin3DLTypeRef { get; set; }
        public int DelphiDLTypeRef { get; set; }
    }
}
