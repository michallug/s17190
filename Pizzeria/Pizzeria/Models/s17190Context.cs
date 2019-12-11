using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria.Models
{
    public partial class s17190Context : DbContext
    {
        public s17190Context()
        {
        }

        public s17190Context(DbContextOptions<s17190Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dostawa> Dostawa { get; set; }
        public virtual DbSet<Napoj> Napoj { get; set; }
        public virtual DbSet<NapojZamowienie> NapojZamowienie { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual DbSet<PizzaZamowienie> PizzaZamowienie { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Sos> Sos { get; set; }
        public virtual DbSet<SposobPlatnosci> SposobPlatnosci { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17190;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Dostawa>(entity =>
            {
                entity.HasKey(e => e.IdDostawcy)
                    .HasName("Dostawa_pk");

                entity.Property(e => e.IdDostawcy).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Napoj>(entity =>
            {
                entity.HasKey(e => e.IdNapoj)
                    .HasName("Napoj_pk");

                entity.Property(e => e.IdNapoj).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NapojZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.IdZamowienie, e.IdNapoj })
                    .HasName("NapojZamowienie_pk");

                entity.HasOne(d => d.IdNapojNavigation)
                    .WithMany(p => p.NapojZamowienie)
                    .HasForeignKey(d => d.IdNapoj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NapojZamowienie_Napoj");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.NapojZamowienie)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NapojZamowienie_Zamowienie");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza).ValueGeneratedNever();

                entity.Property(e => e.Dodatek)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PodwojneCiasto)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaSkladnik>(entity =>
            {
                entity.HasKey(e => new { e.IdPizza, e.IdSkladnik })
                    .HasName("PizzaSkladnik_pk");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaSkladnik_Pizza");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaSkladnik_Skladnik");
            });

            modelBuilder.Entity<PizzaZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.IdZamowienie, e.IdPizza })
                    .HasName("PizzaZamowienie_pk");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaZamowienie)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaZamowienie_Pizza");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.PizzaZamowienie)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaZamowienie_Zamowienie");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sos>(entity =>
            {
                entity.HasKey(e => e.IdSos)
                    .HasName("Sos_pk");

                entity.Property(e => e.IdSos).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SposobPlatnosci>(entity =>
            {
                entity.HasKey(e => e.IdPlatnoscTyp)
                    .HasName("SposobPlatnosci_pk");

                entity.Property(e => e.IdPlatnoscTyp).ValueGeneratedNever();

                entity.Property(e => e.Rodzaj)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TerminDostawy).HasColumnType("datetime");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDostawcyNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdDostawcy)
                    .HasConstraintName("Zamowienie_Dostawa");

                entity.HasOne(d => d.IdPlatnoscTypNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPlatnoscTyp)
                    .HasConstraintName("Zamowienie_SposobPlatnosci");

                entity.HasOne(d => d.IdSosNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdSos)
                    .HasConstraintName("Zamowienie_Sos");
            });
        }
    }
}
