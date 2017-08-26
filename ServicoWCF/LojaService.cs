using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAcessLayer.Model;
using DataAcessLayer.Persistencia;

namespace ServicoWCF
{
    class LojaService : ILojaService
    {
        public bool ApagarProduto(int id, ref string mensagem)
        {
            using (PersistenciaProduto persistencia = new PersistenciaProduto())
            {
                return persistencia.ApagarProduto(id);
            }
        }

        public bool AtualizarProduto(ProdutoVendido produto, ref string mensagem)
        {
            bool resultado = false;
            // verifica se o preço é válido
            if (produto == null)
            {
                mensagem = "O produto informado esta incorreto.";
                return false;
            }
            else if (produto.PrecoProduto <= 0)
            {
                mensagem = "O Preço não pode ser menor que zero.";
                resultado = false;
            }
            else if (string.IsNullOrEmpty(produto.NomeProduto))
            {
                mensagem = "O nome do produto não pode ser vazio";
                resultado = false;
            }
            else if (produto.QuantidadeProduto <= 0)
            {
                mensagem = "A quantidade não pode ser meno que zero";
                resultado = false;
            }
            else
            {
                using (PersistenciaProduto persistencia = new PersistenciaProduto())
                {
                    var retorno = persistencia.InserirProduto(produto);
                    if (retorno > 0)
                    {
                        mensagem = "O produto foi atualizado com sucesso";
                        resultado = true;
                    }
                    else
                    {
                        mensagem = "O produto não foi incluído.";
                        resultado = false;
                    }
                }

            }
            return resultado;
        }

        public ProdutoVendido BuscarProduto(int id, ref string mensagem)
        {
            using (PersistenciaProduto p = new PersistenciaProduto())
            {
                var produto = p.obterProduto(id);
                return produto;
            }

        }

        public int InserirProduto(ProdutoVendido produto, ref string mensagem)
        {
            using (PersistenciaProduto persistencia = new PersistenciaProduto())
            {
                return persistencia.InserirProduto(produto);
            }
        }

        public bool ApagarVenda(int id, ref string mensagem)
        {
            using (PersistenciaVenda persistencia = new PersistenciaVenda())
            {
                return persistencia.ApagarVenda(id);
            }
        }


        public bool AtualizarVenda(Venda venda, ref string mensagem)
        {
            bool resultado = false;
            using (PersistenciaVenda persistencia = new PersistenciaVenda())
            {
                var retorno = persistencia.AtualizarVenda(venda);
                if (retorno)
                {
                    mensagem = "A venda foi atualizada com sucesso";
                    resultado = true;
                }
                else
                {
                    mensagem = "A venda não foi atualizada.";
                    resultado = false;
                }
            }

            return resultado;
        }


        public Venda BuscarVenda(int id, ref string mensagem)
        {
            using (PersistenciaVenda p = new PersistenciaVenda())
            {
                var produto = p.obterVenda(id);
                return produto;
            }

        }

        public int InserirVenda(Venda venda, ref string mensagem)
        {
            using (PersistenciaVenda persistencia = new PersistenciaVenda())
            {
                return persistencia.InserirVenda(venda);
            }
        }
    }
}








