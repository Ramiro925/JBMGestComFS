using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MODELO;

namespace CAL
{
    public class VendaCAL
    {
        private Conexao conexao;
        public Int64 id;
        VendaModelo mod = new VendaModelo();
        public VendaCAL(Conexao con)
        {
            this.conexao = con;
        }
        public Int64 GetNumeroDocs()
        {

            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "select max(nDoc) as ultimo from venda";
                this.conexao.conectar();

                object o = cmd.ExecuteScalar();

                if (o.Equals(DBNull.Value))
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt64(o) + 1;
                }
            }
            finally
            {
                this.conexao.desconectar();
            }

        }// Fim  getNDocs
        public Int64 Add(VendaModelo cat)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText =
                    "INSERT INTO venda (dataVenda,valorTotalVenda,descontoVenda,nomeCliente,Utilizador_id,nDoc)" +
                    " VALUES (@dataVenda,@valorTotalVenda,@descontoVenda,@nomeCliente,@idUtiliz,@nDoc)";
                cmd.Parameters.AddWithValue("@dataVenda", cat.DataVenda);
                cmd.Parameters.AddWithValue("@valorTotalVenda", cat.ValorPrecoVendido);
                cmd.Parameters.AddWithValue("@descontoVenda", cat.DescontoVenda);
                cmd.Parameters.AddWithValue("@nomeCliente", cat.NomeCliente);
                cmd.Parameters.AddWithValue("@idUtiliz", cat.IdUtiliz);
                cmd.Parameters.AddWithValue("@nDoc", cat.NDocs);
                cmd.Parameters.AddWithValue("@nifCliente", cat.NifCliente);
                if (this.conexao.objCon.State != ConnectionState.Open)
                {
                    this.conexao.conectar();
                }
                int res = cmd.ExecuteNonQuery();
                //---- RECUPERA O ULTIMO ID INSERIDO NA TABELA VENDA----- 
                cmd.CommandText = "SELECT LAST_INSERT_ID()";
                IDataReader reader = cmd.ExecuteReader();
                if (reader != null && reader.Read())
                {
                    id = reader.GetInt64(0);
                }
                return id;
            }
            finally
            {
                this.conexao.desconectar();
            }
        }
        public List<VendaModelo> GetItemVenda()
        {
            List<VendaModelo> lst = new List<VendaModelo>();
            
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            cmd.CommandText = "select * from venda where id>0";
            this.conexao.conectar();
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
               
                mod.IdVenda = red.GetInt64("id");
                mod.DataVenda = red.GetString("dataVenda");
                mod.ValorPrecoVendido = red.GetDouble("valorTotalVenda");
                mod.DescontoVenda = red.GetDouble("descontoVenda");
                mod.NomeCliente = red.GetString("nomeCliente");
                mod.IdUtiliz = red.GetInt64("Utilizador_id");
                mod.NDocs = red.GetInt64("nDoc");
                lst.Add(mod);
            }
            this.conexao.desconectar();
            return lst;
        }// Fim  GetItemVenda
        
    }
}
