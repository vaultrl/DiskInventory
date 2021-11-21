using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiskInventory.Models
{
    public partial class disk_inventoryjcContext : DbContext
    {
        public disk_inventoryjcContext()
        {
        }

        public disk_inventoryjcContext(DbContextOptions<disk_inventoryjcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistType> ArtistType { get; set; }
        public virtual DbSet<Borrower> Borrower { get; set; }
        public virtual DbSet<Disk> Disk { get; set; }
        public virtual DbSet<DiskArtist> DiskArtist { get; set; }
        public virtual DbSet<DiskHasBorrower> DiskHasBorrower { get; set; }
        public virtual DbSet<DiskType> DiskType { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<ViewIndividualArtist> ViewIndividualArtist { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
////            if (!optionsBuilder.IsConfigured)
////            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
////                optionsBuilder.UseSqlServer("Server=.\\SQLDEV01;Database=disk_inventoryjc;Trusted_Connection=True;");
////            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.ArtistId)
                    .HasColumnName("artist_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtistTypeId).HasColumnName("artist_type_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.HasOne(d => d.ArtistType)
                    .WithMany(p => p.Artist)
                    .HasForeignKey(d => d.ArtistTypeId)
                    .HasConstraintName("FK__artist__artist_t__2E1BDC42");
            });

            modelBuilder.Entity<ArtistType>(entity =>
            {
                entity.ToTable("artist_type");

                entity.Property(e => e.ArtistTypeId)
                    .HasColumnName("artist_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Borrower>(entity =>
            {
                entity.ToTable("borrower");

                entity.Property(e => e.BorrowerId)
                    .HasColumnName("borrower_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(20);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<Disk>(entity =>
            {
                entity.ToTable("disk");

                entity.Property(e => e.DiskId)
                    .HasColumnName("disk_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdName)
                    .IsRequired()
                    .HasColumnName("cd_name")
                    .HasMaxLength(30);

                entity.Property(e => e.DiskStatusId).HasColumnName("disk_status_id");

                entity.Property(e => e.DiskTypeId).HasColumnName("disk_type_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.DiskStatus)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.DiskStatusId)
                    .HasConstraintName("FK__disk__disk_statu__31EC6D26");

                entity.HasOne(d => d.DiskType)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.DiskTypeId)
                    .HasConstraintName("FK__disk__disk_type___30F848ED");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__disk__genre_id__32E0915F");
            });

            modelBuilder.Entity<DiskArtist>(entity =>
            {
                entity.ToTable("disk_artist");

                entity.Property(e => e.DiskArtistId)
                    .HasColumnName("disk_artist_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.DiskId).HasColumnName("disk_id");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.DiskArtist)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__disk_arti__artis__35BCFE0A");

                entity.HasOne(d => d.Disk)
                    .WithMany(p => p.DiskArtist)
                    .HasForeignKey(d => d.DiskId)
                    .HasConstraintName("FK__disk_arti__disk___36B12243");
            });

            modelBuilder.Entity<DiskHasBorrower>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("disk_has_borrower");

                entity.Property(e => e.BorrowDate)
                    .HasColumnName("borrow_date")
                    .HasColumnType("date");

                entity.Property(e => e.BorrowStatus)
                    .IsRequired()
                    .HasColumnName("borrow_status")
                    .HasMaxLength(1);

                entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");

                entity.Property(e => e.DiskId).HasColumnName("disk_id");

                entity.Property(e => e.ReturnDate)
                    .HasColumnName("return_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Borrower)
                    .WithMany()
                    .HasForeignKey(d => d.BorrowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk_has___borro__398D8EEE");

                entity.HasOne(d => d.Disk)
                    .WithMany()
                    .HasForeignKey(d => d.DiskId)
                    .HasConstraintName("FK__disk_has___disk___38996AB5");
            });

            modelBuilder.Entity<DiskType>(entity =>
            {
                entity.ToTable("disk_type");

                entity.Property(e => e.DiskTypeId)
                    .HasColumnName("disk_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.DiskStatusId)
                    .HasName("PK__status__46F9977E34E57E0A");

                entity.ToTable("status");

                entity.Property(e => e.DiskStatusId)
                    .HasColumnName("disk_status_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ViewIndividualArtist>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Individual_Artist");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
