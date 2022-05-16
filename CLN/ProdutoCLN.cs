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
   public class ProdutoCLN
    {
        private Conexao conexao;
        private ProdutoCAL cate;
        public ProdutoCLN(Conexao con)
        {
            this.conexao = con;
        }
        public bool add(ProdutoModelo cat)
        {

            if (cat.NomeProduto == "" || cat.CodiBarra == "" || cat.PrecoVenda <= 0 || cat.DataValid == "")
            {
                throw new Exception("Campo vazio");
            }
            else
            {
                cate = new ProdutoCAL(this.conexao);
                bool res = cate.add(cat);
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

        public bool atualizar(ProdutoModelo cat)
        {
            if (cat.NomeProduto == "" || cat.CodiBarra == "" || cat.PrecoVenda <= 0 || cat.DataValid == "")
            {
                throw new Exception("Campo vazio");
            }
            else
            {
                cate = new ProdutoCAL(this.conexao);
                bool res = cate.atualizar(cat);
                if (res == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }//fim actualizar
        public void excluir(Int64 codigo)
        {
            cate = new ProdutoCAL(this.conexao);
            cate.excluir(codigo);
        }//fim ExcluirVenda
        public DataTable listar()
        {
            cate = new ProdutoCAL(this.conexao);
            return cate.listarProduto();
        }
        public ProdutoModelo getProdutoCLN(string pivoCodigoBarra)
        {
            cate = new ProdutoCAL(this.conexao);
            return cate.getProduto(pivoCodigoBarra);
        }
        public bool getProdutoVerifiqueCLN(string pivoCodigoBarra)
        {
            cate = new ProdutoCAL(this.conexao);
            return cate.getProdutoVerifique(pivoCodigoBarra);
        }
    }
}
