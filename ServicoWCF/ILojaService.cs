using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAcessLayer.Model;

namespace ServicoWCF
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface ILojaService
    {
        [OperationContract]
        ProdutoVendido BuscarProduto(int id, ref string mensagem);

        [OperationContract]
        bool AtualizarProduto(ProdutoVendido produto, ref string mensagem);

        [OperationContract]
        bool ApagarProduto(int id, ref string mensagem);

        [OperationContract]
        int InserirProduto(ProdutoVendido produto, ref string mensagem);
        
        [OperationContract]
        Venda BuscarVenda(int id, ref string mensagem);

        [OperationContract]
        bool AtualizarVenda(Venda venda, ref string mensagem);

        [OperationContract]
        bool ApagarVenda(int id, ref string mensagem);

        [OperationContract]
        int InserirVenda(Venda venda, ref string mensagem);



        // TODO: Adicione suas operações de serviço aqui
    }


    //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
    // Use um contrato de dados como ilustrado no exemplo abaixo para adicionar tipos compostos a operações de serviço.
    // Você pode adicionar arquivos XSD ao projeto. Depois de criar o projeto, use os tipos de dados definidos nele diretamente, com o namespace "ServicoWCF.ContractType".
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
