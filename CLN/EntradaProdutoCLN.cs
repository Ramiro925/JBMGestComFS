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
    public class EntradaProdutoCLN
    {
        private Conexao conexao;
        private EntradaProdutoCAL cate;
        public EntradaProdutoCLN(Conexao con)
        {
            this.conexao = con;
        }
        public bool add(EntradaProdutoModelo cat)
        {

            if (cat.QtdEntrada <= 0 || cat.DataEntrada == "")
            {
                throw new Exception("Campo vazio");
            }
            else
            {
                cate = new EntradaProdutoCAL(this.conexao);
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
        public Int64 getNumDocs() {
            cate = new EntradaProdutoCAL(this.conexao);
            return cate.getNumeroDocs();
        }
    }
}
