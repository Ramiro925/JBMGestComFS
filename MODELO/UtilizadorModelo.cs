using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class UtilizadorModelo
    {
        private Int64 id;
        private string nomeCompleto;
        private string nomeUtilizador;
        private string senhaUtilizador;
        private string cargo;
        private string dataAdmitido;
        private string telefone;
        private string numBI;

        public Int64 Id { get => id; set => id = value; }
        public string NomeCompleto { get => nomeCompleto; set => nomeCompleto = value; }
        public string NomeUtilizador { get => nomeUtilizador; set => nomeUtilizador = value; }
        public string SenhaUtilizador { get => senhaUtilizador; set => senhaUtilizador = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string DataAdmitido { get => dataAdmitido; set => dataAdmitido = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string NumBI { get => numBI; set => numBI = value; }
    }
}
