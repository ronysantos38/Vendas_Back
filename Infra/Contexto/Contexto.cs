using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexto
{
    public  class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaRealizada> VendaRealizadas { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public Contexto()
        {

        }
    }
}
