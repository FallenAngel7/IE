using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelphiEntities
{
    public class DelphiContext : DbContext
    {
        public DelphiContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public DbSet<AccVchHdr> AccVchHdrs { get; set; }
        public DbSet<AccVchItm> AccVchItms { get; set; }
        public DbSet<AccVchType> AccVchTypes { get; set; }
        public DbSet<DL> DLs { get; set; }
        public DbSet<SL> SLs { get; set; }
        public DbSet<DLViews> DLViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccVchType>()
                .HasKey(c => c.Code);
            modelBuilder.Entity<AccVchHdr>().HasKey(c => c.HdrVchID);
        }     
    }

}
