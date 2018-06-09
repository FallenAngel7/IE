using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelphiEntities
{
    public class DL
    {
        public string AccNum { get; set; }
        public string Title { get; set; }
        public int DLType { get; set; }
        public string LatinTitle { get; set; }
        public string Definition { get; set; }
        public char HasCurrency { get; set; }
        public int CurrencyRef { get; set; }
        public int Active { get; set; }
    }
}
