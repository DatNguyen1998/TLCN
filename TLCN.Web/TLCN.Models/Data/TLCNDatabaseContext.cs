using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.Models
{
    public partial class TLCNDatabaseContext:DbContext
    {
        public TLCNDatabaseContext()
        {

        }

        public TLCNDatabaseContext(DbContextOptions<TLCNDatabaseContext> options):base(options)
        {

        }

        public virtual DbSet<AuthUser> AuthUsers { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<DetailBill> DetailBills { get; set; }
        public virtual DbSet<MetadataType> MetadataTypes { get; set; }
        public virtual DbSet<MetadataValue> MetadataValues { get; set; }
        public virtual DbSet<Product> Products{ get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<ReviewProduct> ReviewProducts { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }


}
