using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Persistencia;

public class Teste
{
    static void Main()
    {
        PersistenciaProduto p = new PersistenciaProduto();

        
        var produto = p.obterProduto(1);
        produto.NomeProduto = "Asus";
        produto.PrecoProduto = (decimal) 1000.00;
        p.AtualizarProduto(produto);
        p.ApagarProduto(produto.IdProduto);

        produto.NomeProduto = "Produto Novo";
        produto.IdProduto = 0;
        produto.PrecoProduto = (decimal) 222.00;
        p.InserirProduto(produto);
    }

}

