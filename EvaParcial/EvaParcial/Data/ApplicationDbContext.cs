using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EvaParcial.Models;

namespace EvaParcial.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IdentityRole> IdentityRole { get; set; }
        public DbSet<EvaParcial.Models.Clientes> Cliente { get; set; }
        public DbSet<EvaParcial.Models.Distribuidores> Distribuidores { get; set; }
        public DbSet<EvaParcial.Models.Detalle> Detalle { get; set; }
        public DbSet<EvaParcial.Models.Pedidos> Pedidos { get; set; }
        public DbSet<EvaParcial.Models.RealizarPedido> RealizarPedido { get; set; }
        public DbSet<EvaParcial.Models.Entrega> Entrega { get; set; }
        public DbSet<EvaParcial.Models.EstableserEntrega> EstableserEntrega { get; set; }
    }
}
