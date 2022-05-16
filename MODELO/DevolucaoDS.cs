using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class DevolucaoDS
    {
        //--------------INFORMAÇÕES ADICIONADAS NA DATAGRIDVIEW dadoDC------------------
        private string codiBarra;
        private string nomeProduto;
        private Int64 qtdItemVenda;
        private Double valorItemVenda;
        private Double descontoVenda;
        private Double percTaxaImposto;
        private Double valorTotal;
        //--------------------------------------------------------------------------------
        private Int64 nDoc;
        private string dataDevolucao;
        private Int64 devfatnDoc; // Armazena o número do Doc. faturação Devolvido pelo Cliente
        private string nomeCliente;
        private string nifCliente;
        private string formaPag;
        private Int64 idProd;
        private Int64 idItemVenda;
        //----------INFORMAÇÕES ORGANIZADA POR COLUNA  ADICIONADAS NA DATAGRIDVIEW dadoDC-
        public string CodiBarra { get => codiBarra; set => codiBarra = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public Int64 QtdItemVenda { get => qtdItemVenda; set => qtdItemVenda = value; }
        public double ValorItemVenda { get => valorItemVenda; set => valorItemVenda = value; }
        public double DescontoVenda { get => descontoVenda; set => descontoVenda = value; }
        public double PercTaxaImposto { get => percTaxaImposto; set => percTaxaImposto = value; }
        public double ValorTotal { get => valorTotal; set => valorTotal = value; }

        //-----------------------DADOS NÃO VISUALIZADOS NA DATAGRIDVIEW-------------------------
        public Int64 NDoc { get => nDoc; set => nDoc = value; }
        public string DataDevolucao { get => dataDevolucao; set => dataDevolucao = value; }
        public Int64 DevfatnDoc { get => devfatnDoc; set => devfatnDoc = value; }
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public string NifCliente { get => nifCliente; set => nifCliente = value; }
        public long IdProd { get => idProd; set => idProd = value; }
        public string FormaPag { get => formaPag; set => formaPag = value; }
        public long IdItemVenda { get => idItemVenda; set => idItemVenda = value; }
    }
}
