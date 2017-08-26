using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Model;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using System.Data.Entity;

namespace DataAcessLayer.Persistencia
{
    public class PersistenciaProduto : IDisposable
    {
        public ProdutoVendido obterProduto(int id)
        {
            LojaContext bd = new LojaContext();
            return bd.Produtos.Where(prop => prop.IdProduto.Equals(id)).FirstOrDefault();
        }


        public bool AtualizarProduto(ProdutoVendido produto)
        {
            using (LojaContext bd = new LojaContext())
            {
                var p = bd.Produtos.Where(prop => prop.IdProduto.Equals(produto.IdProduto)).FirstOrDefault();
                p.NomeProduto = produto.NomeProduto;
                p.PrecoProduto = produto.PrecoProduto;
                p.QuantidadeProduto = produto.QuantidadeProduto;
                p.StatusProduto = produto.StatusProduto;
                bd.Entry(p).CurrentValues.SetValues(p);
                var retorno = bd.SaveChanges();
                return (retorno > 0);
            }

        }

        public int InserirProduto(ProdutoVendido produto)
        {
            using (LojaContext bd = new LojaContext())
            {
                ProdutoVendido p = bd.Produtos.Add(produto);
                bd.SaveChanges();
                var retorno = p.IdProduto;
                return retorno;
            }
        }


        public bool ApagarProduto(int id)
        {
            using (LojaContext bd = new LojaContext())
            {
                var p = bd.Produtos.Where(prop => prop.IdProduto.Equals(id)).FirstOrDefault();
                bd.Produtos.Remove(p);
                var retorno = bd.SaveChanges();
                return (retorno > 0);
            }
        }

        public void Dispose()
        {
        }
    }
}
