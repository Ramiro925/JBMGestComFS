using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class SaidaProdutoModelo
    {
        private Int64 idSaida;
        private string dataSaida;
        private Int64 qtdSaida;
        private double valorUnitario;
        private Int64 idProd;
        private Int64 idUtiliz;
        private Int64 nDocs;

        public Int64 IdSaida { get => idSaida; set => idSaida = value; }
        public string DataSaida { get => dataSaida; set => dataSaida = value; }
        public Int64 QtdSaida { get => qtdSaida; set => qtdSaida = value; }
        public double ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
        public Int64 IdProd { get => idProd; set => idProd = value; }
        public Int64 IdUtiliz { get => idUtiliz; set => idUtiliz = value; }
        public Int64 NDocs { get => nDocs; set => nDocs = value; }
    }
}
