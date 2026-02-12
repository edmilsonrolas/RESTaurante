using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    //allows to search/specify for tables
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Prato> Pratos {get; set;}
        public DbSet<Pedido> Pedidos {get; set;}
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Trabalhador> Trabalhadores {get; set;}
        public DbSet<PratoPedido> PratosPedido {get; set;}
    }
}