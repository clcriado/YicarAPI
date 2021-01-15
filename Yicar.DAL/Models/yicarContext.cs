using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Yicar.DAL.Models
{
    public partial class yicarContext : DbContext
    {
        public yicarContext()
        {
        }

        public yicarContext(DbContextOptions<yicarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Concesionarios> Concesionarios { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Jefe> Jefe { get; set; }
        public virtual DbSet<Mecanico> Mecanico { get; set; }
        public virtual DbSet<Reparacion> Reparacion { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=yicar", x => x.ServerVersion("10.4.11-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Concesionarios>(entity =>
            {
                entity.ToTable("concesionarios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.ToTable("especialidad");

                entity.HasIndex(e => e.Idmecanico)
                    .HasName("fk_mecanico_has_tipo_mecanico1_idx");

                entity.HasIndex(e => e.Idtipo)
                    .HasName("fk_mecanico_has_tipo_tipo1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idmecanico)
                    .HasColumnName("idmecanico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idtipo)
                    .HasColumnName("idtipo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdmecanicoNavigation)
                    .WithMany(p => p.Especialidad)
                    .HasForeignKey(d => d.Idmecanico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mecanico_has_tipo_mecanico1");

                entity.HasOne(d => d.IdtipoNavigation)
                    .WithMany(p => p.Especialidad)
                    .HasForeignKey(d => d.Idtipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mecanico_has_tipo_tipo1");
            });

            modelBuilder.Entity<Jefe>(entity =>
            {
                entity.ToTable("jefe");

                entity.HasIndex(e => e.Idusuario)
                    .HasName("fk_jefe_usuario1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idusuario)
                    .HasColumnName("idusuario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Jefe)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jefe_usuario1");
            });

            modelBuilder.Entity<Mecanico>(entity =>
            {
                entity.ToTable("mecanico");

                entity.HasIndex(e => e.Idusuario)
                    .HasName("fk_mecanico_usuario1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EsJefe)
                    .HasColumnName("esJefe")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Idusuario)
                    .HasColumnName("idusuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumReparaciones)
                    .HasColumnName("numReparaciones")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Mecanico)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mecanico_usuario1");
            });

            modelBuilder.Entity<Reparacion>(entity =>
            {
                entity.ToTable("reparacion");

                entity.HasIndex(e => e.Idcliente)
                    .HasName("fk_vehiculo_has_cliente_cliente1_idx");

                entity.HasIndex(e => e.Idmecanico)
                    .HasName("fk_reparación_mecanico1_idx");

                entity.HasIndex(e => e.Idvehiculo)
                    .HasName("fk_vehiculo_has_cliente_vehiculo1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Componentes)
                    .HasColumnName("componentes")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("enum('pendiente','proceso','finalizada')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fin)
                    .HasColumnName("fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idcliente)
                    .HasColumnName("idcliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idmecanico)
                    .HasColumnName("idmecanico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idvehiculo)
                    .HasColumnName("idvehiculo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Inicio)
                    .HasColumnName("inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Presupuesto)
                    .HasColumnName("presupuesto")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Reparacion)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehiculo_has_cliente_cliente1");

                entity.HasOne(d => d.IdmecanicoNavigation)
                    .WithMany(p => p.Reparacion)
                    .HasForeignKey(d => d.Idmecanico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reparación_mecanico1");

                entity.HasOne(d => d.IdvehiculoNavigation)
                    .WithMany(p => p.Reparacion)
                    .HasForeignKey(d => d.Idvehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehiculo_has_cliente_vehiculo1");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("tipo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdConcesionario)
                    .HasName("fk_usuario_concesionarios1_idx");

                entity.HasIndex(e => e.Login)
                    .HasName("login")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Clave)
                    .HasColumnName("clave")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdConcesionario)
                    .HasColumnName("idConcesionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Salario)
                    .HasColumnName("salario")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasColumnType("enum('vendedor','mecanico','jefe')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdConcesionarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdConcesionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_concesionarios1");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("vehiculo");

                entity.HasIndex(e => e.IdConcesionario)
                    .HasName("fk_vehiculo_concesionarios_idx");

                entity.HasIndex(e => e.IdTipo)
                    .HasName("fk_vehiculo_tipo1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Combustible)
                    .HasColumnName("combustible")
                    .HasColumnType("enum('diesel','gasolina')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdConcesionario)
                    .HasColumnName("idConcesionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipo)
                    .HasColumnName("idTipo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KmRecorridos)
                    .HasColumnName("km_recorridos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Marca)
                    .HasColumnName("marca")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Matricula)
                    .HasColumnName("matricula")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Modelo)
                    .HasColumnName("modelo")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.SegundaMano).HasColumnName("segunda_mano");

                entity.HasOne(d => d.IdConcesionarioNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdConcesionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehiculo_concesionarios");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehiculo_tipo1");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("vendedor");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_venta_usuario_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumVentas)
                    .HasColumnName("numVentas")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Vendedor)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta_usuario");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.ToTable("ventas");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("FK_ventas_cliente");

                entity.HasIndex(e => e.IdVehiculo)
                    .HasName("FK_ventas_vehiculo");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("FK_ventas_vendedor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasColumnType("enum('pendiente','rechazada','aceptada')")
                    .HasDefaultValueSql("'pendiente'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FechaLimite)
                    .HasColumnName("fecha_limite")
                    .HasColumnType("date");

                entity.Property(e => e.Fin)
                    .HasColumnName("fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVehiculo)
                    .HasColumnName("idVehiculo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVendedor)
                    .HasColumnName("idVendedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Inicio)
                    .HasColumnName("inicio")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Presupuesto)
                    .HasColumnName("presupuesto")
                    .HasColumnType("decimal(12,2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_cliente");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("FK_ventas_vehiculo");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_vendedor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
