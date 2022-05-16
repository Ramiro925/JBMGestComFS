using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class DevolucaoModelo
    {
        private Int64 qtdDevolucao;
        private string dataDevolucao;
        private Double valorUnitario;
        private Int64 idProd;
        private Int64 idUtiliz;
        private Int64 nDoc;
        private Int64 devfatnDoc; // Armazena o número do Doc. faturação Devolvido pelo Cliente
        private Int64 idItemVenda;



        public Int64 QtdDevolucao { get => qtdDevolucao; set => qtdDevolucao = value; }
        public string DataDevolucao { get => dataDevolucao; set => dataDevolucao = value; }
        public double ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
        public Int64 IdProd { get => idProd; set => idProd = value; }
        public Int64 IdUtiliz { get => idUtiliz; set => idUtiliz = value; }
        public Int64 NDoc { get => nDoc; set => nDoc = value; }
        public Int64 DevfatnDoc { get => devfatnDoc; set => devfatnDoc = value; }
        public Int64 IdItemVenda { get => idItemVenda; set => idItemVenda = value; }
    }
}
