using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahkaranEntities
{
    public class SL
    {
        public long SLID { get; set; }
        public long GLRef { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Title_En { get; set; }
        public int Nature { get; set; }
        public int IsTraceable { get; set; }
        public int IsMultiCurrency { get; set; }
        public int HasCurrencyConversion { get; set; }
        public string Description { get; set; }
        public long DefaultCurrencyRef { get; set; }
        public int State { get; set; }
        public int Type { get; set; }
        public int VATSLType { get; set; }
        public int TaxAccountType { get; set; }
        public int IsQuantifiable { get; set; }
        public long LedgerRef { get; set; }
    }
}
