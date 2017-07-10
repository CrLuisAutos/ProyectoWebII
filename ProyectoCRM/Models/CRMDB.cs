namespace ProyectoCRM.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CRMDB : DbContext
    {
        public CRMDB()
            : base("name=CRMDB")
        {
        }
        
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Reunion> Reunion { get; set; }
        public virtual DbSet<Support> Support { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUserRoles)
                .WithRequired(e => e.AspNetRoles)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserRoles)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Support)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.nombre)
                .IsUnicode(false);


            modelBuilder.Entity<Cliente>()
                .Property(e => e.pagina_web)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            

            modelBuilder.Entity<Cliente>()
                .Property(e => e.sector)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Contacto)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.id_cliente)
                .WillCascadeOnDelete(false);
      

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Support)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.id_cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contacto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Contacto>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Contacto>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Contacto>()
                .Property(e => e.puesto)
                .IsUnicode(false);

            modelBuilder.Entity<Reunion>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Support>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Support>()
                .Property(e => e.detalle)
                .IsUnicode(false);

            modelBuilder.Entity<Support>()
                .Property(e => e.estado)
                .IsUnicode(false);
        }
    }
}
