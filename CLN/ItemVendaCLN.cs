using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;
using CAL;
using System.Data;

namespace CLN
{
    public class ItemVendaCLN
    {
        private Conexao conexao;
        private ItemVendaCAL cate;

        public ItemVendaCLN(Conexao con)
        {
            this.conexao = con;
        }
        public bool Add(ItemVendaModelo cat, Int64 IdVenda)
        {

            if (cat.QtdItemVenda <= 0)
            {
                throw new Exception("Campo vazio");
            }
            else
            {
                cate = new ItemVendaCAL(this.conexao);
                bool res = cate.Add(cat,IdVenda);
                if (res == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }//fim adicionar
        public RTVendaOperador GetRTVendaOperadorCLN(Int64 idUtilizador, string dataInit, string dataFim)
        {
            cate = new ItemVendaCAL(this.conexao);
            return cate.GetRTVendaPorOperador(idUtilizador, dataInit, dataFim);
        }// Fim Resumo Totais Venda Por Operadores
        public List<CDVendaOperador> GetCDVendaOperadorCLN(Int64 idUtilizador, string dataInit, string dataFim)
        {
            cate = new ItemVendaCAL(this.conexao);
            return cate.GetCDVendaOperador(idUtilizador, dataInit, dataFim);
        }// Fim Completo, Detalhes Venda Por Operadores
    }
}
