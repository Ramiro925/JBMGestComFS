using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class SaidaDS
    {
        public string NomeProduto { get; set; }
        public string CodiBarra { get; set; }
        public Int64 QtdSaida { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        public string ValorGeral { get; set; }
        public Int64 NumDocs { get; set; }
    }
}
