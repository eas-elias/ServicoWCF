using System;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Model;
using System.Data.Entity.Core;

namespace DataAcessLayer.Persistencia
{
    class LojaContext : DbContext 
    {
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ProdutoVendido> Produtos { get; set; }

        
        public LojaContext()
        : base("name=LojaContext")
        {
            this.Database.CreateIfNotExists();
        }

    }


}
