using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ProdutoModelo
    {
        private Int64 id;
        private string nomeProduto;
        private string codiBarra;
        private double precoVenda;
        private Int64 stockMin;
        private Int64 stockMax;
        private string dataValid;
        private Int64 idCat;

        public Int64 Id { get => id; set => id = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public string CodiBarra { get => codiBarra; set => codiBarra = value; }
        public double PrecoVenda { get => precoVenda; set => precoVenda = value; }
        public Int64 StockMin { get => stockMin; set => stockMin = value; }
        public Int64 StockMax { get => stockMax; set => stockMax = value; }
        public string DataValid { get => dataValid; set => dataValid = value; }
        public Int64 IdCat { get => idCat; set => idCat = value; }
    }
}
