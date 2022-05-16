using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class VendaDS
    {
        private String codiBarra;
        private String nomeProduto;
        private Int64 qtdVenda;
        private Double valorUnitario;
        private Double valorTotal;
        private String valorGeral;
        private Int64 numDocs;
        private Double pImposto;
        private Double pDesconto;
        private Double valorEntregue;
        private Double valorTroco;
        private String nomeCliente;
        private String nomeUtilizador;
        private string nifCliente;

        public string CodiBarra { get => codiBarra; set => codiBarra = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public Int64 QtdVenda { get => qtdVenda; set => qtdVenda = value; }
        public double ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
        public double ValorTotal { get => valorTotal; set => valorTotal = value; }
        public string ValorGeral { get => valorGeral; set => valorGeral = value; }
        public Int64 NumDocs { get => numDocs; set => numDocs = value; }
        public double PImposto { get => pImposto; set => pImposto = value; }
        public double PDesconto { get => pDesconto; set => pDesconto = value; }
        public double ValorEntregue { get => valorEntregue; set => valorEntregue = value; }
        public double ValorTroco { get => valorTroco; set => valorTroco = value; }
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }

        public string NomeUtilizador { get => nomeUtilizador; set => nomeUtilizador = value; }
        public string NifCliente { get => nifCliente; set => nifCliente = value; }
    }
}