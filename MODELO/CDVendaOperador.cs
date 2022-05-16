using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class CDVendaOperador
    {
        private Int64 nDoc;
        private String nomeCompleto;
        private String nomeUtilizador;
        private String nomeProduto;
        private String codiBarra;
        private Int64 qtdItemVenda;
        private Double valorItemVenda;
        private String nomeCliente;
        private Double descontoVenda;

        public Int64 NDoc { get => nDoc; set => nDoc = value; }
        public string NomeCompleto { get => nomeCompleto; set => nomeCompleto = value; }
        public string NomeUtilizador { get => nomeUtilizador; set => nomeUtilizador = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public string CodiBarra { get => codiBarra; set => codiBarra = value; }
        public Int64 QtdItemVenda { get => qtdItemVenda; set => qtdItemVenda = value; }
        public double ValorItemVenda { get => valorItemVenda; set => valorItemVenda = value; }
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public double DescontoVenda { get => descontoVenda; set => descontoVenda = value; }
    }
}
