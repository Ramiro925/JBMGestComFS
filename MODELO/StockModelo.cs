using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class StockModelo
    {
        private Int64 idStock;
        private Int64 qtdStock;
        private double valorUnitario;
        private Int64 idProd;

        public Int64 IdStock { get => idStock; set => idStock = value; }
        public Int64 QtdStock { get => qtdStock; set => qtdStock = value; }
        public double ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
        public Int64 IdProd { get => idProd; set => idProd = value; }
    }
}
