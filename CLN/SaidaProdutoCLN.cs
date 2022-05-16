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
    public class SaidaProdutoCLN
    {
            private Conexao conexao;
            private SaidaProdutoCAL cate;

            public  SaidaProdutoCLN(Conexao con)
            {
                this.conexao = con;
            }
            public bool Add(SaidaProdutoModelo cat)
            {

                if (cat.QtdSaida <= 0 || cat.DataSaida == "")
                {
                    throw new Exception("Campo vazio");
                }
                else
                {
                    cate = new SaidaProdutoCAL(this.conexao);
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
            public Int64 getNumDocs()
            {
                cate = new SaidaProdutoCAL(this.conexao);
                return cate.getNumeroDocs();
            }
    }
}
