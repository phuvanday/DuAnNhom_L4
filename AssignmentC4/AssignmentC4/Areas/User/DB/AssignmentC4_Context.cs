using AssignmentC4.Areas.User.Models;
using Microsoft.EntityFrameworkCore;
namespace AssignmentC4.Areas.User.DB
{
    public class AssignmentC4_Context:DbContext
    {
        public AssignmentC4_Context(DbContextOptions<AssignmentC4_Context> options) : base(options) { }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<BienThe> BienThe {  get; set; }
        public DbSet<HinhAnh> HinhAnh { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BienThe>().HasOne(x => x.SanPham).WithMany(x=>x.BienThes).HasForeignKey(x=>x.MaSP);
            modelBuilder.Entity<HinhAnh>().HasOne(x=>x.BienThe).WithMany(x=>x.HinhAnh).HasForeignKey(x=>x.MaBT);
        }
    }
}
