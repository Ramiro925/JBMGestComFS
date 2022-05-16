using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class VendaModelo
    {
        private Int64 idVenda;
        private string dataVenda;
        private Double valorprecoVendido;
        private Double descontoVenda;
        private string nomeCliente;
        private Int64 idUtiliz;
        private Int64 nDocs;
        private Double pImposto;
        private string nifCliente;

        public Int64 IdVenda { get => idVenda; set => idVenda = value; }
        public string DataVenda { get => dataVenda; set => dataVenda = value; }
        public Double ValorPrecoVendido { get => valorprecoVendido; set => valorprecoVendido = value; }
        public Double DescontoVenda { get => descontoVenda; set => descontoVenda = value; }
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public Int64 IdUtiliz { get => idUtiliz; set => idUtiliz = value; }
        public Int64 NDocs { get => nDocs; set => nDocs = value; }
        public Double PImposto{ get => pImposto; set => pImposto = value; }
        public string NifCliente { get => nifCliente; set => nifCliente = value; }
    }
}
