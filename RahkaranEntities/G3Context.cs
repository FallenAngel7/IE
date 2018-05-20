using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RahkaranEntities
{
    public class G3Context : DbContext
    {
        public G3Context(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public DbSet<DL> DLs { get; set; }
        public DbSet<SL> SLs { get; set; }
        public DbSet<DLType> DLTypes { get; set; }
        public DbSet<DLTypeRelation> DLTypeRelations { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherItem> VoucherItems { get; set; }
        public DbSet<VoucherType> VoucherTypes { get; set; }
        public DbSet<FiscalYear> FiscalYears { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
    }
}
