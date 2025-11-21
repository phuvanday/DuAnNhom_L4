using AssignmentC4.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentC4.Data
{
    public class AssignmentC4_Context : DbContext
    {
        public AssignmentC4_Context(DbContextOptions<AssignmentC4_Context> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Variant>()
                .HasOne(v => v.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(v => v.MaSP)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Variant)
                .WithMany(v => v.Images)
                .HasForeignKey(i => i.MaBT)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
