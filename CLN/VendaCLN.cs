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
    public class VendaCLN
    {
        private Conexao conexao;
        private VendaCAL cate;

        public VendaCLN(Conexao con)
        {
            this.conexao = con;
        }
        public Int64 Add(VendaModelo cat)
        {

            if (cat.DataVenda == "")
            {
                throw new Exception("Campo vazio");
            }
            else
            {
                cate = new VendaCAL(this.conexao);
                 return cate.Add(cat);
            }
        }//fim adicionar
        public Int64 getNumDocs()
        {
            cate = new VendaCAL(this.conexao);
            return cate.GetNumeroDocs();
        }
        public List<VendaModelo> GetItemVendaCLN()
        {
            cate = new VendaCAL(this.conexao);
            return cate.GetItemVenda();
        }
    }
}
