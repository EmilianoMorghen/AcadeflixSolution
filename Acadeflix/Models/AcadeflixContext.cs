using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Acadeflix.Models
{
    public partial class AcadeflixContext : DbContext
    {
        public AcadeflixContext()
        {
        }

        public AcadeflixContext(DbContextOptions<AcadeflixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Credit> Credits { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Media> Medias { get; set; }
        public virtual DbSet<Opened> Openeds { get; set; }
        public virtual DbSet<Preferred> Preferreds { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Watcher> Watchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=KEVIN;Initial Catalog=Acadeflix;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cast>(entity =>
            {
                entity.HasKey(e => e.PkIdCast)
                    .HasName("PK__Casts__21C763F7779FCC9E");

                entity.Property(e => e.PkIdCast).HasColumnName("pk_id_cast");

                entity.Property(e => e.FkIdContent).HasColumnName("fk_id_content");

                entity.Property(e => e.FkIdCredit).HasColumnName("fk_id_credit");

                entity.Property(e => e.FkIdRole).HasColumnName("fk_id_role");

                entity.HasOne(d => d.FkIdContentNavigation)
                    .WithMany(p => p.Casts)
                    .HasForeignKey(d => d.FkIdContent)
                    .HasConstraintName("FK__Casts__fk_id_con__3C69FB99");

                entity.HasOne(d => d.FkIdCreditNavigation)
                    .WithMany(p => p.Casts)
                    .HasForeignKey(d => d.FkIdCredit)
                    .HasConstraintName("FK__Casts__fk_id_cre__3D5E1FD2");

                entity.HasOne(d => d.FkIdRoleNavigation)
                    .WithMany(p => p.Casts)
                    .HasForeignKey(d => d.FkIdRole)
                    .HasConstraintName("FK__Casts__fk_id_rol__3E52440B");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.HasKey(e => new { e.FkIdContent, e.FkIdParent })
                    .HasName("PK__Catalogs__3A216642D9A1DE6B");

                entity.HasIndex(e => e.FkIdContent, "UQ__Catalogs__F581674A6D2748F5")
                    .IsUnique();

                entity.Property(e => e.FkIdContent).HasColumnName("fk_id_content");

                entity.Property(e => e.FkIdParent).HasColumnName("fk_id_parent");

                entity.HasOne(d => d.FkIdContentNavigation)
                    .WithOne(p => p.CatalogFkIdContentNavigation)
                    .HasForeignKey<Catalog>(d => d.FkIdContent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Catalogs__fk_id___3F466844");

                entity.HasOne(d => d.FkIdParentNavigation)
                    .WithMany(p => p.CatalogFkIdParentNavigations)
                    .HasForeignKey(d => d.FkIdParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Catalogs__fk_id___403A8C7D");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.HasKey(e => e.PkIdContent)
                    .HasName("PK__Contents__F56096A95370D122");

                entity.Property(e => e.PkIdContent).HasColumnName("pk_id_content");

                entity.Property(e => e.ContentType).HasColumnName("content_type");

                entity.Property(e => e.FkIdPrevious).HasColumnName("fk_id_previous");

                entity.Property(e => e.Plot)
                    .HasColumnType("ntext")
                    .HasColumnName("plot");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("publish_date");

                entity.Property(e => e.Runtime).HasColumnName("runtime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("title");

                entity.HasOne(d => d.FkIdPreviousNavigation)
                    .WithMany(p => p.InverseFkIdPreviousNavigation)
                    .HasForeignKey(d => d.FkIdPrevious)
                    .HasConstraintName("FK__Contents__fk_id___412EB0B6");
            });

            modelBuilder.Entity<Credit>(entity =>
            {
                entity.HasKey(e => e.PkIdCredit)
                    .HasName("PK__Credits__1446D50E6B5752A0");

                entity.Property(e => e.PkIdCredit).HasColumnName("pk_id_credit");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Sirname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("sirname");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.PkIdGenre)
                    .HasName("PK__Genres__52C3E1474279A525");

                entity.Property(e => e.PkIdGenre).HasColumnName("pk_id_genre");

                entity.Property(e => e.FkIdContent).HasColumnName("fk_id_content");

                entity.Property(e => e.GenreType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("genre_type");

                entity.HasOne(d => d.FkIdContentNavigation)
                    .WithMany(p => p.Genres)
                    .HasForeignKey(d => d.FkIdContent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Genres__fk_id_co__4222D4EF");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => e.PkIdMedia)
                    .HasName("PK__Medias__3B21094EDE9CCCFF");

                entity.Property(e => e.PkIdMedia).HasColumnName("pk_id_media");

                entity.Property(e => e.FkIdContent).HasColumnName("fk_id_content");

                entity.Property(e => e.MediaType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("media_type");

                entity.Property(e => e.MediaUrl)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("media_url");

                entity.HasOne(d => d.FkIdContentNavigation)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.FkIdContent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medias__fk_id_co__4316F928");
            });

            modelBuilder.Entity<Opened>(entity =>
            {
                entity.HasKey(e => e.PkIdOpened)
                    .HasName("PK__Opened__AFF09EA0EA1AA71C");

                entity.ToTable("Opened");

                entity.Property(e => e.PkIdOpened).HasColumnName("pk_id_opened");

                entity.Property(e => e.FkIdContent).HasColumnName("fk_id_content");

                entity.Property(e => e.FkIdWatcher).HasColumnName("fk_id_watcher");

                entity.Property(e => e.LastEdit).HasColumnName("last_edit");

                entity.Property(e => e.ViewCount)
                    .HasColumnName("view_count")
                    .HasDefaultValueSql("('00:00:00:0000')");

                entity.Property(e => e.Watched)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("watched")
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FkIdContentNavigation)
                    .WithMany(p => p.Openeds)
                    .HasForeignKey(d => d.FkIdContent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Opened__fk_id_co__440B1D61");

                entity.HasOne(d => d.FkIdWatcherNavigation)
                    .WithMany(p => p.Openeds)
                    .HasForeignKey(d => d.FkIdWatcher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Opened__fk_id_wa__44FF419A");
            });

            modelBuilder.Entity<Preferred>(entity =>
            {
                entity.HasKey(e => e.PkIdPreferred)
                    .HasName("PK__Preferre__B6D7D87C8599D3D3");

                entity.ToTable("Preferred");

                entity.Property(e => e.PkIdPreferred).HasColumnName("pk_id_preferred");

                entity.Property(e => e.FkIdContent).HasColumnName("fk_id_content");

                entity.Property(e => e.FkIdWatcher).HasColumnName("fk_id_watcher");

                entity.HasOne(d => d.FkIdContentNavigation)
                    .WithMany(p => p.Preferreds)
                    .HasForeignKey(d => d.FkIdContent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preferred__fk_id__45F365D3");

                entity.HasOne(d => d.FkIdWatcherNavigation)
                    .WithMany(p => p.Preferreds)
                    .HasForeignKey(d => d.FkIdWatcher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preferred__fk_id__46E78A0C");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.PkIdRole)
                    .HasName("PK__Roles__C662872AEA32CAC1");

                entity.Property(e => e.PkIdRole).HasColumnName("pk_id_role");

                entity.Property(e => e.RoleType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("role_type");
            });

            modelBuilder.Entity<Watcher>(entity =>
            {
                entity.HasKey(e => e.PkIdWatcher)
                    .HasName("PK__Watchers__FC0031939423F510");

                entity.Property(e => e.PkIdWatcher).HasColumnName("pk_id_watcher");

                entity.Property(e => e.AvatarUrl)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("avatar_url")
                    .HasDefaultValueSql("('/placeholder.png')");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nickname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
