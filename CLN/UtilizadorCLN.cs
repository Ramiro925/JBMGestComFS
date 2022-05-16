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
    public class UtilizadorCLN
    {
        private Conexao conexao;
        private UtilizadorCAL cate;
        public UtilizadorCLN(Conexao con)
        {
            this.conexao = con;
        }
        public bool Add(UtilizadorModelo cat)
        {
            if (cat.NomeCompleto == "" || cat.NomeUtilizador == "" || cat.SenhaUtilizador == "" || cat.Telefone == "" ||cat.NumBI == "")
            {
                throw new Exception("AVISO: Preencha todos os campos");
            }
            else
            {
                cate = new UtilizadorCAL(this.conexao);
                bool res = cate.Add(cat);
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

        public bool Atualizar(UtilizadorModelo cat)
        {
            if (cat.NomeCompleto == "" || cat.NomeUtilizador == "" || cat.SenhaUtilizador == "" || cat.Telefone == "" || cat.NumBI == "")
            {
                throw new Exception("AVISO: Todos os campos devem estar preenchido");
            }
            else
            {
                cate = new UtilizadorCAL(this.conexao);
                bool res = cate.Atualizar(cat);
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
        public void Excluir(Int64 codigo)
        {
            cate = new UtilizadorCAL(this.conexao);
            cate.Excluir(codigo);
        }//fim ExcluirVenda
        public DataTable Listar()
        {
            cate = new UtilizadorCAL(this.conexao);
            return cate.ListarUtilizador();
        }
        public UtilizadorModelo GetUtilizadorCLN(string pivo)
        {
            cate = new UtilizadorCAL(this.conexao);
            return cate.GetUtilizador(pivo);
        }
        public List<string> ListarComb()
        {
            cate = new UtilizadorCAL(this.conexao);
            return cate.ListarUtilizadorCombo();
        }
    }
}
