using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalwareTest.Entity
{
    public class DigitalWareContext : DbContext
    {
        public DigitalWareContext()
        {

        }
        public DigitalWareContext(DbContextOptions<DigitalWareContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Producto> producto { get; set; }
        public virtual DbSet<Cliente> cliente { get; set; }

        public virtual DbSet<Movimiento> movimiento { get; set; }
        public virtual DbSet<Inventario> inventario { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Builder tables*/
            modelBuilder.Entity<Producto>(Entity =>
            {
                Entity.ToTable("productos");
                Entity.Property(e => e.descripcion)
                      .HasColumnName("descripcion")
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);

                Entity.Property(e => e.precio)
                      .HasColumnName("precio")
                      .IsRequired()
                      .HasColumnType("decimal(11,2)");
                

                      
            });
            modelBuilder.Entity<Cliente>(Entity =>
            {
                Entity.ToTable("clientes");

                Entity.Property(e => e.apellido)
                      .HasColumnName("apellido")
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);

                Entity.Property(e => e.nombre)
                      .HasColumnName("nombre")
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);

                Entity.Property(e => e.edad)
                      .HasColumnName("edad")
                      .IsRequired()
                      .IsUnicode(false);

            });
            modelBuilder.Entity<Movimiento>(Entity =>
            {
                Entity.ToTable("movimientos");
                Entity.Property(m => m.productoId).HasColumnName("productoId").IsRequired();
                Entity.Property(m => m.clienteId).HasColumnName("clienteId").IsRequired();

                Entity.Property(m => m.cantidad)
                      .HasColumnName("cantidad")
                      .IsRequired();


                Entity.Property(m => m.precio)
                      .HasColumnName("precio")
                      .IsRequired()
                      .HasColumnType("decimal(11,2)");

                Entity.Property(m => m.fecha)
                      .HasColumnName("fecha")
                      .IsRequired();

                Entity.HasOne(c => c.cliente)
                      .WithMany(m => m.movimientos)
                      .HasForeignKey(c => c.clienteId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_MOVIMIENTO_CLIENTE");

                Entity.HasOne(p => p.producto)
                      .WithMany(m => m.movimientos)
                      .HasForeignKey(p => p.productoId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_MOVIMIENTO_PRODUCTO");

                      
            });
            modelBuilder.Entity<Inventario>(Entity =>
            {
                Entity.ToTable("inventarios");

                Entity.Property(i => i.productoId).HasColumnName("productoId").IsRequired();

                Entity.Property(i => i.cantidad)
                      .HasColumnName("cantidad")
                      .IsRequired();

                Entity.Property(i => i.precio)
                      .HasColumnName("precio")
                      .IsRequired()
                      .HasColumnType("decimal(11,2)");

                Entity.Property(i => i.fecha)
                      .HasColumnName("fecha")
                      .IsRequired();

                Entity.HasOne(p => p.producto)
                      .WithMany(i => i.inventarios)
                      .HasForeignKey(p => p.productoId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_INVENTARIO_PRODUCTO");



            });




            /*Seeding tables*/
            List<Producto> Productos = new List<Producto>()
            {
                new Producto {Id = 1, descripcion = "Televisor 14 pulgadas", precio = 15000 },
                new Producto {Id = 2, descripcion = "Televisor 18 pulgadas", precio = 19800 },
                new Producto {Id = 3, descripcion = "Radio", precio = 5000 }
            };
            List<Cliente> Clientes = new List<Cliente>()
            {
                new Cliente {Id = 1, nombre = "Juan carlos", apellido = "Romero", edad = 28},
                new Cliente {Id = 2, nombre = "Faby alberto", apellido = "freitte", edad = 30},
                new Cliente {Id = 3, nombre = "Cinthia Cristina", apellido = "Machado Arrieta", edad = 36},
                new Cliente {Id = 4, nombre = "Cesar", apellido = "Machado", edad = 71},
                new Cliente {Id = 5, nombre = "Maryory", apellido = "Machado", edad = 46}
            };
            List<Movimiento> Movimientos = new List<Movimiento>()
            {
                new Movimiento{Id = 1, productoId = 1, cantidad = 2, precio = 30000, clienteId = 5, fecha = DateTime.Now }
            };
            List<Inventario> Inventarios = new List<Inventario>()
            {
                new Inventario {Id = 1, fecha = DateTime.Now, precio = 30000, cantidad = 2, productoId = 1, tipo = Tipo.entrada}
            };

            modelBuilder.Entity<Producto>(Entity =>
            {
                Entity.HasData(Productos);
            });
            modelBuilder.Entity<Cliente>(Entity =>
            {
                Entity.HasData(Clientes);
            });
            modelBuilder.Entity<Movimiento>(Entity =>
            {
                Entity.HasData(Movimientos);
            });
            modelBuilder.Entity<Inventario>(Entity =>
            {
                Entity.HasData(Inventarios);
            });
        }
      
    }

  
}
