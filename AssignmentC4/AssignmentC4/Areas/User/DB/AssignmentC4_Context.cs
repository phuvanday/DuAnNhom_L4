using AssignmentC4.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using AssignmentC4.Areas.User.Models;

namespace AssignmentC4.Areas.User.DB
{
    public class AssignmentC4_Context : DbContext
    {
        public AssignmentC4_Context(DbContextOptions<AssignmentC4_Context> options) : base(options) { }

        public DbSet<Product> Products { get; set; }  // Product là chính
        public DbSet<BienThe> BienThe { get; set; }
        public DbSet<HinhAnh> HinhAnh { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BienThe>()
                .HasOne(bt => bt.Product)
                .WithMany(p => p.BienThes)
                .HasForeignKey(bt => bt.MaSP);

            modelBuilder.Entity<HinhAnh>()
                .HasOne(ha => ha.BienThe)
                .WithMany(bt => bt.HinhAnh)
                .HasForeignKey(ha => ha.MaBT);
        }
    }
}
