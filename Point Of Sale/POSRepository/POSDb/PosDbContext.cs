using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSRepository
{
    public class PosDbContext : DbContext
    {
        public PosDbContext() : base("name=POSDb")
        {
            Database.SetInitializer<PosDbContext>(new DropCreateDatabaseIfModelChanges<PosDbContext>());
        }

        public DbSet<VendorInfo> Vendors { get; set; }

        public DbSet<POSItemInfo> POSItems { get; set; }

        public DbSet<POSItemCategory> POSCategories { get; set; }

        public DbSet<POSItemType> POSTypes { get; set; }

        public DbSet<POSItemTransactionInfo> POSPurchases { get; set; }

        public DbSet<POSAppUser> POSAppUsers { get; set; }

        public DbSet<POSSalesMan> POSSalesMans { get; set; }

        public DbSet<POSBillInfo> POSBills { get; set; }

        public DbSet<POSBillItemInfo> POSBillItems { get; set; }

        public DbSet<POSRefundInfo> POSRefunds { get; set; }

        public DbSet<POSRefundItemInfo> POSRefundItems { get; set; }

        public DbSet<SystemSettings> SystemSettings { get; set; }

        public DbSet<POSAttendanceInfo> POSAttendanceInfo { get; set; }

        public DbSet<POSExpenseInfo> POSExpenses { get; set; }

        //internal DbSet<RepresentativeInfo> Representatives { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
