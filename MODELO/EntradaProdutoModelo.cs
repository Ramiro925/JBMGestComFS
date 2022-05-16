using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class EntradaProdutoModelo
    {
        private Int64 idEntrada;
        private Int64 qtdEntrada;
        private string dataEntrada;
        private double valorUnitario;
        private Int64 idProd;
        private Int64 idUtiliz;
        private Int64 nDocs;

        public Int64 IdEntrada { get => idEntrada; set => idEntrada = value; }
        public Int64 QtdEntrada { get => qtdEntrada; set => qtdEntrada = value; }
        public string DataEntrada { get => dataEntrada; set => dataEntrada = value; }
        public double ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
        public Int64 IdProd { get => idProd; set => idProd = value; }
        public Int64 IdUtiliz { get => idUtiliz; set => idUtiliz = value; }
        public Int64 NDocs { get => nDocs; set => nDocs = value; }
    }
}
