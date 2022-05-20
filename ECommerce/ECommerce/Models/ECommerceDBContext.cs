using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ECommerce.Models
{
    public partial class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext()
        {
        }

        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCategory> TblCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET54;Database=ECommerceDB;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblCategory");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
