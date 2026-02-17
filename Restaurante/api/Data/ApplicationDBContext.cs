using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    //allows to search/specify for tables
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Prato> Pratos {get; set;}
        public DbSet<Pedido> Pedidos {get; set;}
        public DbSet<Pessoa> Pessoas {get; set;}
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Trabalhador> Trabalhadores {get; set;}
        public DbSet<PratoPedido> PratosPedido {get; set;}

        // Configuração da herança TPH através da coluna discriminadora (TipoPessoa)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasDiscriminator<TipoPessoa>("TipoPessoa")
                .HasValue<Cliente>(TipoPessoa.Cliente)
                .HasValue<Trabalhador>(TipoPessoa.Trabalhador);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Trabalhador)
                .WithMany(t => t.Pedidos)
                .HasForeignKey(p => p.TrabalhadorId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}