using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MODELO;
using CAL;
using System.Data;


namespace CLN
{
    public class CategoriaCLN
    {
        private Conexao conexao;
        private CategoriaCAL cate;
        public CategoriaCLN(Conexao con)
        {
            this.conexao = con;
        }
        public bool add(CategoriaModelo cat)
        {
            
            if(cat.DesigCategoria == "")
            {
                throw new Exception("Campo vazio");
            }
            else
            {
                cate = new CategoriaCAL(this.conexao);
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

        public bool atualizar(CategoriaModelo cat)
        {
            if (cat.DesigCategoria == "")
            {
                throw new Exception("Campo vazio");
            }
            else
            {
                cate = new CategoriaCAL(this.conexao);
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
            cate = new CategoriaCAL(this.conexao);
            cate.excluir(codigo);
        }//fim ExcluirVenda
        public DataTable listar()
        {
            cate = new CategoriaCAL(this.conexao);
            return cate.listarCategoria();
        }
        public List<string> listarComb()
        {
            cate = new CategoriaCAL(this.conexao);
            return cate.listarCategoriaCombo();
        }
        public Int64 getCatbyNameCLN(string pivoCodigoBarra)
        {
            cate = new CategoriaCAL(this.conexao);
            return cate.getCatbyName(pivoCodigoBarra);
        }
    }
}
