using System.Data.Entity;

namespace IPC.API.Models
{
    public partial class Entity : DbContext
    {
        public Entity()
            : base("name=Entity")
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<DetallesFactura> DetallesFactura { get; set; }
        public virtual DbSet<EncabezadoFacturas> EncabezadoFacturas { get; set; }
        public virtual DbSet<ProductoCategorias> ProductoCategorias { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TiposPago> TiposPago { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<ValoracionProducto> ValoracionProducto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Categorias>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Categorias>()
                .Property(e => e.identificador)
                .IsUnicode(false);

            modelBuilder.Entity<DetallesFactura>()
                .Property(e => e.valorUnitarioProducto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DetallesFactura>()
                .Property(e => e.valorTotalProductos)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EncabezadoFacturas>()
                .Property(e => e.totalSinImpuesto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EncabezadoFacturas>()
                .Property(e => e.totalConImpuesto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EncabezadoFacturas>()
                .Property(e => e.impuesto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EncabezadoFacturas>()
                .Property(e => e.direccionEnvio)
                .IsUnicode(false);

            modelBuilder.Entity<EncabezadoFacturas>()
                .Property(e => e.direccionFactura)
                .IsUnicode(false);

            modelBuilder.Entity<EncabezadoFacturas>()
                .HasMany(e => e.DetallesFactura)
                .WithRequired(e => e.EncabezadoFacturas)
                .HasForeignKey(e => e.idEncabezadoFactura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.precioUnitario)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.DetallesFactura)
                .WithRequired(e => e.Productos)
                .HasForeignKey(e => e.idProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.ValoracionProducto)
                .WithRequired(e => e.Productos)
                .HasForeignKey(e => e.idProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TiposPago>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TiposPago>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TiposPago>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<TiposPago>()
                .HasMany(e => e.EncabezadoFacturas)
                .WithRequired(e => e.TiposPago)
                .HasForeignKey(e => e.idTipoPago)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoUsuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoUsuario>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoUsuario>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.TipoUsuario)
                .HasForeignKey(e => e.idTipoUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.EncabezadoFacturas)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.ValoracionProducto)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);
        }
    }
}
