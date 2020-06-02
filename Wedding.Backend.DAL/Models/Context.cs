using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Wedding.Backend.DAL.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Contribution> Contribution { get; set; }
        public virtual DbSet<Contributor> Contributor { get; set; }
        public virtual DbSet<Package> Package { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=192.168.0.254;port=3306;user=marco;password=mg1988;database=wedding", x => x.ServerVersion("10.4.13-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contribution>(entity =>
            {
                entity.HasIndex(e => e.ContributorId)
                    .HasName("FK__Contributor");

                entity.HasIndex(e => e.PackageId)
                    .HasName("FK__Package");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Contribution1).HasColumnName("Contribution");

                entity.Property(e => e.ContributorId).HasColumnType("int(11)");

                entity.Property(e => e.Message)
                    .HasColumnType("mediumtext")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PackageId).HasColumnType("int(11)");

                entity.HasOne(d => d.Contributor)
                    .WithMany(p => p.Contribution)
                    .HasForeignKey(d => d.ContributorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contributor");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Contribution)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Package");
            });

            modelBuilder.Entity<Contributor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(1024)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Thumbnail)
                    .HasColumnType("varchar(1024)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(1024)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
