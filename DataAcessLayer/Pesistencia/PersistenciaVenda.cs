using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using DataAcessLayer.Model;

namespace DataAcessLayer.Persistencia
{
    public class PersistenciaVenda : IDisposable
    {
        public object produto { get; private set; }

        public Venda obterVenda(int id)
        {
            LojaContext bd = new LojaContext();
            return bd.Vendas.Where(prop => prop.IdVenda.Equals(id)).FirstOrDefault();
        }


        public bool AtualizarVenda(Venda venda)
        {
            using (LojaContext bd = new LojaContext())
            {

                var p = bd.Vendas.Where(prop => prop.IdVenda.Equals(venda.IdVenda)).FirstOrDefault();
                p.DataVenda = venda.DataVenda;
                p.valorVenda = venda.valorVenda;
                p.produtos = venda.produtos;
                bd.Entry(p).CurrentValues.SetValues(p);
                var retorno = bd.SaveChanges();
                return (retorno > 0);
            }

        }

        public int InserirVenda(Venda venda)
        {
            using (LojaContext bd = new LojaContext())
            {
                Venda p = bd.Vendas.Add(venda);
                bd.SaveChanges();
                var retorno = p.IdVenda;
                return retorno;
            }
        }


        public bool ApagarVenda(int id)
        {
            using (LojaContext bd = new LojaContext())
            {
                var p = bd.Vendas.Where(prop => prop.IdVenda.Equals(id)).FirstOrDefault();
                bd.Vendas.Remove(p);
                var retorno = bd.SaveChanges();
                return (retorno > 0);
            }
        }

        public void Dispose()
        {
        }
    }
}