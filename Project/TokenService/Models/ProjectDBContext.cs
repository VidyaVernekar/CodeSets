using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TokenService.Models
{
    public partial class ProjectDBContext : DbContext
    {
        public ProjectDBContext()
        {
        }

        public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RoleMaster> RoleMasters { get; set; } = null!;
        public virtual DbSet<UserTable> UserTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=ProjectDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__RoleMast__8AFACE1A4E452E1D");

                entity.ToTable("RoleMaster");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserTabl__1788CC4C34ADED77");

                entity.ToTable("UserTable");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.Property(e => e.UserName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
