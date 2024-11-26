using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TpCsharpPoKEKW.Model;

public partial class GestionEtudiantsContext : DbContext
{
    public GestionEtudiantsContext()
    {
    }

    public GestionEtudiantsContext(DbContextOptions<GestionEtudiantsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Cour> Cours { get; set; }

    public virtual DbSet<Etudiant> Etudiants { get; set; }

    public virtual DbSet<Inscription> Inscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BENJAMIN-PC\\SQLEXPRESS;Database=GestionEtudiants;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClasseId).HasName("PK__Classes__B7A53B44C294F23B");

            entity.Property(e => e.ClasseId).HasColumnName("ClasseID");
            entity.Property(e => e.Niveau).HasMaxLength(20);
            entity.Property(e => e.NomClasse).HasMaxLength(50);
        });

        modelBuilder.Entity<Cour>(entity =>
        {
            entity.HasKey(e => e.CoursId).HasName("PK__Cours__DA5377A5FF73B2F6");

            entity.Property(e => e.CoursId).HasColumnName("CoursID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Enseignant).HasMaxLength(100);
            entity.Property(e => e.NomCours).HasMaxLength(100);
        });

        modelBuilder.Entity<Etudiant>(entity =>
        {
            entity.HasKey(e => e.EtudiantId).HasName("PK__Etudiant__E0BCA274BC8D8A90");

            entity.HasIndex(e => e.Email, "UQ__Etudiant__A9D10534F1EF953A").IsUnique();

            entity.Property(e => e.EtudiantId).HasColumnName("EtudiantID");
            entity.Property(e => e.ClasseId).HasColumnName("ClasseID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nom).HasMaxLength(50);
            entity.Property(e => e.Prenom).HasMaxLength(50);

            entity.HasOne(d => d.Classe).WithMany(p => p.Etudiants)
                .HasForeignKey(d => d.ClasseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Etudiants_Classes");
        });

        modelBuilder.Entity<Inscription>(entity =>
        {
            entity.HasKey(e => e.InscriptionId).HasName("PK__Inscript__3332B196162103A6");

            entity.Property(e => e.InscriptionId).HasColumnName("InscriptionID");
            entity.Property(e => e.CoursId).HasColumnName("CoursID");
            entity.Property(e => e.DateInscription).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EtudiantId).HasColumnName("EtudiantID");

            entity.HasOne(d => d.Cours).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.CoursId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inscripti__Cours__403A8C7D");

            entity.HasOne(d => d.Etudiant).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.EtudiantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inscripti__Etudi__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
