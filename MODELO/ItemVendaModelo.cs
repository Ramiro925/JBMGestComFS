using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ItemVendaModelo
    {
        private Int64 idItem;
        private Int64 qtdItemVenda;
        private Double valorItemVenda;
        private Int64 idProd;
        private Int64 idVenda;

        public Int64 IdItem { get => idItem; set => idItem = value; }
        public Int64 QtdItemVenda { get => qtdItemVenda; set => qtdItemVenda = value; }
        public double ValorItemVenda { get => valorItemVenda; set => valorItemVenda = value; }
        public Int64 IdProd { get => idProd; set => idProd = value; }
        public Int64 IdVenda { get => idVenda; set => idVenda = value; }
    }
}
