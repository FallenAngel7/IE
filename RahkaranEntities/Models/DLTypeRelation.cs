using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahkaranEntities
{
    public class DLTypeRelation
    {
        public long DLTypeRelationID { get; set; }
        public long SLRef { get; set; }
        public int Level { get; set; }
        public long DLTypeRef { get; set; }
        public int ControlNature { get; set; }
    }
}
