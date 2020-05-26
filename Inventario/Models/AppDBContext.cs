namespace Inventario
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppDBContext : DbContext
    {
        public AppDBContext()
            : base("name=AppDBContext")
        {
        }

        public virtual DbSet<Cabecera> Cabecera { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ClienteContacto> ClienteContacto { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Contacto_Proveedor> Contacto_Proveedor { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<EmpleadoContacto> EmpleadoContacto { get; set; }
        public virtual DbSet<Movimiento> Movimiento { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabecera>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Cabecera>()
                .HasMany(e => e.Detalle)
                .WithRequired(e => e.Cabecera)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Empresa)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Cabecera)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.ClienteContacto)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClienteContacto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Contacto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Contacto>()
                .HasMany(e => e.ClienteContacto)
                .WithRequired(e => e.Contacto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contacto>()
                .HasMany(e => e.Contacto_Proveedor)
                .WithRequired(e => e.Contacto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contacto>()
                .HasMany(e => e.EmpleadoContacto)
                .WithRequired(e => e.Contacto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contacto_Proveedor>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Cabecera)
                .WithRequired(e => e.Departamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Detalle>()
                .Property(e => e.Cantidad)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Detalle>()
                .Property(e => e.Total)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Direccion>()
                .Property(e => e.Pais)
                .IsUnicode(false);

            modelBuilder.Entity<Direccion>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Direccion>()
                .Property(e => e.Ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Direccion>()
                .Property(e => e.Colonia)
                .IsUnicode(false);

            modelBuilder.Entity<Direccion>()
                .Property(e => e.Calle)
                .IsUnicode(false);

            modelBuilder.Entity<Direccion>()
                .HasMany(e => e.Persona)
                .WithRequired(e => e.Direccion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Sueldo)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Cabecera)
                .WithRequired(e => e.Empleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.EmpleadoContacto)
                .WithRequired(e => e.Empleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmpleadoContacto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Movimiento>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Movimiento>()
                .HasMany(e => e.Cabecera)
                .WithRequired(e => e.Movimiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Apellido1)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Apellido2)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Cliente)
                .WithRequired(e => e.Persona)
                .HasForeignKey(e => e.IdPersona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Empleado)
                .WithOptional(e => e.Persona)
                .HasForeignKey(e => e.IdPersona);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CostoUnitario)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Unidad)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Detalle)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.Contacto_Proveedor)
                .WithRequired(e => e.Proveedor)
                .WillCascadeOnDelete(false);
        }
    }
}
