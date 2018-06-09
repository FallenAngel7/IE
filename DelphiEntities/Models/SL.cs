using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelphiEntities
{
    public class SL
    {
        public string AccNum { get; set; }
        public string Title { get; set; }
        public string GLRef { get; set; }
        public string BalanceType { get; set; }
        public string Definition { get; set; }
        public char HasCurrency { get; set; }
        public int CurrencyRef { get; set; }
        public int Active { get; set; }
        public char HasExchange { get; set; }
        public int DLGroups { get; set; }
        public string DlFive { get; set; }
        public string DLSix { get; set; }
        public char HasWarranty { get; set; }
        public char HasQty { get; set; }
        public char HasCash { get; set; }
        public int OpositNatureSLRef { get; set; }
    }
}
