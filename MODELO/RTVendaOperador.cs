using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class RTVendaOperador
    {
        private String nomeOperador;
        private Int64 nDocOperador;
        private Double totaVendaOperador;

        public string NomeOperador { get => nomeOperador; set => nomeOperador = value; }
        public Int64 NDocOperador { get => nDocOperador; set => nDocOperador = value; }
        public double TotaVendaOperador { get => totaVendaOperador; set => totaVendaOperador = value; }
    }
}
