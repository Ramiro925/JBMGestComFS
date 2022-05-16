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
    public class StockCLN
    {
        private Conexao conexao;
        private StockCAL cate;
        public StockCLN(Conexao con)
        {
            this.conexao = con;
        }
        public DataTable listar()
        {
            cate = new StockCAL(this.conexao);
            return cate.listarStock();
        }
        public StockModelo getQtdCLN(Int64 idProd)
        {
            cate = new StockCAL(this.conexao);
            return cate.getQtdAtual(idProd);
        }
    }
}
