using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Yicar.DAL.Models
{
    public partial class YicarContext : DbContext
    {
        public YicarContext()
        {
        }

        public YicarContext(DbContextOptions<YicarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciclomotor> Ciclomotor { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Coches> Coches { get; set; }
        public virtual DbSet<Concesionarios> Concesionarios { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<EspecialidadesMecanico> EspecialidadesMecanico { get; set; }
        public virtual DbSet<Jefe> Jefe { get; set; }
        public virtual DbSet<Mecanicos> Mecanicos { get; set; }
        public virtual DbSet<Motocicletas> Motocicletas { get; set; }
        public virtual DbSet<Reparaciones> Reparaciones { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123asd;database=yicar");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciclomotor>(entity =>
            {
                entity.HasKey(e => e.IdCiclomotor)
                    .HasName("PRIMARY");

                entity.ToTable("ciclomotor");

                entity.HasIndex(e => e.IdCiclomotor)
                    .HasName("idCiclomotor_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdVehiculo)
                    .HasName("fk_Ciclomotor_Vehiculo1_idx");

                entity.Property(e => e.IdCiclomotor)
                    .HasColumnName("idCiclomotor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVehiculo)
                    .HasColumnName("idVehiculo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Ciclomotor)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("fk_Ciclomotor_Vehiculo1");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.HasIndex(e => e.Dni)
                    .HasName("dni_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdCliente)
                    .HasName("idCliente_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(45);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(45);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(45);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasMaxLength(45);

                entity.Property(e => e.FechaNac)
                    .HasColumnName("fechaNac")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasColumnType("enum('hombre','mujer')");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(45);

                entity.Property(e => e.TipoComunicacion)
                    .IsRequired()
                    .HasColumnName("tipoComunicacion")
                    .HasColumnType("enum('sms','correo','telefono')");
            });

            modelBuilder.Entity<Coches>(entity =>
            {
                entity.HasKey(e => e.IdCoches)
                    .HasName("PRIMARY");

                entity.ToTable("coches");

                entity.HasIndex(e => e.IdCoches)
                    .HasName("idCoches_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdVehiculo)
                    .HasName("fk_Coches_Vehiculo1_idx");

                entity.Property(e => e.IdCoches)
                    .HasColumnName("idCoches")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVehiculo)
                    .HasColumnName("idVehiculo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Coches)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("fk_Coches_Vehiculo1");
            });

            modelBuilder.Entity<Concesionarios>(entity =>
            {
                entity.HasKey(e => e.IdConcesionarios)
                    .HasName("PRIMARY");

                entity.ToTable("concesionarios");

                entity.Property(e => e.IdConcesionarios)
                    .HasColumnName("idConcesionarios")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantidadVehiculo)
                    .HasColumnName("cantidadVehiculo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(45);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.NumeroVentas)
                    .HasColumnName("numeroVentas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pais)
                    .HasColumnName("pais")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidad)
                    .HasName("PRIMARY");

                entity.ToTable("especialidad");

                entity.Property(e => e.IdEspecialidad)
                    .HasColumnName("idEspecialidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EspecialidadesMecanico>(entity =>
            {
                entity.HasKey(e => new { e.IdEspecialidad, e.IdMecánicos })
                    .HasName("PRIMARY");

                entity.ToTable("especialidades_mecanico");

                entity.HasIndex(e => e.IdEspecialidad)
                    .HasName("fk_especialidad_has_mecanicos_especialidad1_idx");

                entity.HasIndex(e => e.IdMecánicos)
                    .HasName("fk_especialidad_has_mecanicos_mecanicos1_idx");

                entity.Property(e => e.IdEspecialidad)
                    .HasColumnName("idEspecialidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMecánicos)
                    .HasColumnName("idMecánicos")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEspecialidadNavigation)
                    .WithMany(p => p.EspecialidadesMecanico)
                    .HasForeignKey(d => d.IdEspecialidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_especialidad_has_mecanicos_especialidad1");

                entity.HasOne(d => d.IdMecánicosNavigation)
                    .WithMany(p => p.EspecialidadesMecanico)
                    .HasForeignKey(d => d.IdMecánicos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_especialidad_has_mecanicos_mecanicos1");
            });

            modelBuilder.Entity<Jefe>(entity =>
            {
                entity.HasKey(e => e.IdJefe)
                    .HasName("PRIMARY");

                entity.ToTable("jefe");

                entity.HasIndex(e => e.IdJefe)
                    .HasName("idJefe_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_Jefe_Usuario1_idx");

                entity.Property(e => e.IdJefe)
                    .HasColumnName("idJefe")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Jefe)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_Jefe_Usuario1");
            });

            modelBuilder.Entity<Mecanicos>(entity =>
            {
                entity.HasKey(e => e.IdMecánicos)
                    .HasName("PRIMARY");

                entity.ToTable("mecanicos");

                entity.HasIndex(e => e.IdJefe)
                    .HasName("fk_Mecánicos_Mecánicos1_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_Mecanicos_Usuario1_idx");

                entity.Property(e => e.IdMecánicos)
                    .HasColumnName("idMecánicos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdJefe)
                    .HasColumnName("idJefe")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdJefeNavigation)
                    .WithMany(p => p.InverseIdJefeNavigation)
                    .HasForeignKey(d => d.IdJefe)
                    .HasConstraintName("fk_Mecánicos_Mecánicos1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Mecanicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_Mecanicos_Usuario1");
            });

            modelBuilder.Entity<Motocicletas>(entity =>
            {
                entity.HasKey(e => e.IdMotocicletas)
                    .HasName("PRIMARY");

                entity.ToTable("motocicletas");

                entity.HasIndex(e => e.IdMotocicletas)
                    .HasName("idMotocicletas_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdVehiculo)
                    .HasName("fk_Motocicletas_Vehiculo1_idx");

                entity.Property(e => e.IdMotocicletas)
                    .HasColumnName("idMotocicletas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVehiculo)
                    .HasColumnName("idVehiculo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Motocicletas)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("fk_Motocicletas_Vehiculo1");
            });

            modelBuilder.Entity<Reparaciones>(entity =>
            {
                entity.HasKey(e => e.IdReparacion)
                    .HasName("PRIMARY");

                entity.ToTable("reparaciones");

                entity.Property(e => e.IdReparacion)
                    .HasColumnName("idReparacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Componente)
                    .IsRequired()
                    .HasColumnName("componente")
                    .HasMaxLength(45);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(45);

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fechaFin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaIni)
                    .HasColumnName("fechaIni")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMecánicos)
                    .HasColumnName("idMecánicos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVehiculo)
                    .HasColumnName("idVehiculo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Presupuesto)
                    .IsRequired()
                    .HasColumnName("presupuesto")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Dni)
                    .HasName("CIF_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("idUsuario_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(45);

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnName("contrasena")
                    .HasMaxLength(100);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(45);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("nombreUsuario")
                    .HasMaxLength(45);

                entity.Property(e => e.Salario)
                    .HasColumnName("salario")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(45);

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("enum('venta','mecanico','jefe')");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PRIMARY");

                entity.ToTable("vehiculo");

                entity.HasIndex(e => e.IdConcesionarios)
                    .HasName("fk_vehiculo_concesionarios1_idx");

                entity.HasIndex(e => e.IdVehiculo)
                    .HasName("idVehiculo_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NumeroBastidor)
                    .HasName("numeroBastidor_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdVehiculo)
                    .HasColumnName("idVehiculo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ano)
                    .HasColumnName("ano")
                    .HasColumnType("year(4)");

                entity.Property(e => e.Combustible).HasColumnType("enum('gasolina','hibrido','electrico','diesel')");

                entity.Property(e => e.FechaEntrada)
                    .HasColumnName("fechaEntrada")
                    .HasColumnType("date");

                entity.Property(e => e.FechaSalida)
                    .HasColumnName("fechaSalida")
                    .HasColumnType("date");

                entity.Property(e => e.IdConcesionarios)
                    .HasColumnName("idConcesionarios")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kilometros).HasColumnType("int(11)");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(45);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("modelo")
                    .HasMaxLength(45);

                entity.Property(e => e.NumeroBastidor)
                    .HasColumnName("numeroBastidor")
                    .HasMaxLength(45);

                entity.Property(e => e.NumeroPuertas)
                    .HasColumnName("numeroPuertas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumeroRuedas)
                    .HasColumnName("numeroRuedas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.TipoVehiculo)
                    .IsRequired()
                    .HasColumnName("tipoVehiculo")
                    .HasColumnType("enum('motocicleta','ciclomotor','coches')");

                entity.Property(e => e.Vendido)
                    .IsRequired()
                    .HasColumnName("vendido")
                    .HasColumnType("enum('vendido','en venta')");

                entity.HasOne(d => d.IdConcesionariosNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdConcesionarios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehiculo_concesionarios1");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PRIMARY");

                entity.ToTable("vendedor");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_venta_usuario_idx");

                entity.Property(e => e.IdVenta)
                    .HasColumnName("idVenta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Vendedor)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta_usuario");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => new { e.IdVentas, e.Dni })
                    .HasName("PRIMARY");

                entity.ToTable("ventas");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("fk_ventas_cliente1_idx");

                entity.HasIndex(e => e.IdVehiculo)
                    .HasName("fk_ventas_vehiculo1_idx");

                entity.HasIndex(e => e.IdVentas)
                    .HasName("idVentas_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdVentas)
                    .HasColumnName("idVentas")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasMaxLength(45);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("enum('aceptada','rechazada','pendiente')");

                entity.Property(e => e.FechaLimiteAceptación)
                    .HasColumnName("fechaLimiteAceptación")
                    .HasColumnType("date");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVehiculo)
                    .HasColumnName("idVehiculo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVendedor)
                    .HasColumnName("idVendedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasColumnName("nombreCliente")
                    .HasMaxLength(45);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("primerApellido")
                    .HasMaxLength(45);

                entity.Property(e => e.Propuesta)
                    .HasColumnName("propuesta")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ventas_cliente1");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ventas_vehiculo1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
