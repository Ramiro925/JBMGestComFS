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
    public class PesquisaCLN
    {
        private Conexao conexao;
        private ProdutoCAL cate;
        public PesquisaCLN(Conexao con)
        {
            this.conexao = con;
        }
        public DataTable listar()
        {
            cate = new ProdutoCAL(this.conexao);
            return cate.listarProduto();
        }
    }
}
