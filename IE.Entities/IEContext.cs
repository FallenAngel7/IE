using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IE.Entities
{
    public class IEContext : DbContext
    {        
        public IEContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<DLTypeMap> DLTypeMaps { get; set; }
        public DbSet<VoucherTypeMap> VoucherTypeMaps { get; set; }
        public DbSet<VoucherMap> VoucherMaps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LogHistory> LogHistories { get; set; }

    }
}
