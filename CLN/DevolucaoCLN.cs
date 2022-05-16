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

    public class DevolucaoCLN
    {
        private Conexao conexao;
        private DevolucaoCAL cate;
        public DevolucaoCLN(Conexao con)
        {
            this.conexao = con;
        }
        public bool Add(DevolucaoModelo cat)
        {

            if (cat.QtdDevolucao <= 0 || cat.DataDevolucao == "")
            {
                throw new Exception("Campo vazio");
            }
            else
            {
                cate = new DevolucaoCAL(this.conexao);
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
        public Int64 getNumDocs()
        {
            cate = new DevolucaoCAL(this.conexao);
            return cate.GetNumeroDocs();
        }
        public List<DevolucaoDS> GetDevolucaoCliente(Int64 numDocFat)
        {
            cate = new DevolucaoCAL(this.conexao);
            return cate.GetDevolucaoCliente(numDocFat);
        }
        public void ExcluirVendaCLN(Int64 id, Int64 numDocFat)
        {
            new DevolucaoCAL(this.conexao).ExcluirVenda(id,numDocFat);
        }
        public void ExcluirItemCLN(Int64 id)
        {
            new DevolucaoCAL(this.conexao).ExcluirItem(id);
        }
    }
}
