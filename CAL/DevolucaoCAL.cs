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
    public class DevolucaoCAL
    {
        private Conexao conexao;
        public DevolucaoCAL(Conexao con)
        {
            this.conexao = con;
        }
        public Int64 GetNumeroDocs()
        {

            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "select max(nDoc) as ultimo from devolucaocliente";
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
        public bool Add(DevolucaoModelo cat)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "INSERT INTO devolucaocliente (qtdDevolucao,dataDevolucao,valorUnitario,Produto_id,Utilizador_id,nDoc,devFatnDoc) VALUES (@qtdDevolucao,@dataDevolucao,@valorUnitario,@idProd,@idUtiliz,@nDoc,@devFatnDoc)";
                cmd.Parameters.AddWithValue("@qtdDevolucao", cat.QtdDevolucao);
                cmd.Parameters.AddWithValue("@dataDevolucao", cat.DataDevolucao);
                cmd.Parameters.AddWithValue("@valorUnitario", cat.ValorUnitario);
                cmd.Parameters.AddWithValue("@idProd", cat.IdProd);
                cmd.Parameters.AddWithValue("@idUtiliz", cat.IdUtiliz);
                cmd.Parameters.AddWithValue("@nDoc", cat.NDoc);
                cmd.Parameters.AddWithValue("@devFatnDoc", cat.DevfatnDoc);
                if (this.conexao.objCon.State != ConnectionState.Open)
                {
                    this.conexao.conectar();
                }
                int res = cmd.ExecuteNonQuery();
                if (res <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            finally
            {
                this.conexao.desconectar();
            }
        }
        public List<DevolucaoDS> GetDevolucaoCliente(Int64 numDocFat)
        {
            List<DevolucaoDS> lst = new List<DevolucaoDS>();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            cmd.CommandText = "select  i.id as idItem,p.codiBarra,p.nomeProduto,p.id,i.qtdItemVenda,i.ValorItemVenda,v.descontoVenda,v.percTaxaImposto,v.nDoc,v.nomeCliente,v.nifCliente from venda as v, itemvenda as i, produto as p where v.nDoc = @numDocFat and v.id = i.Venda_id and p.id=i.Produto_id";
            cmd.Parameters.AddWithValue("@numDocFat", numDocFat);
            this.conexao.conectar();
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                lst.Add(new DevolucaoDS
                {
                    CodiBarra = red.GetString("codiBarra"),
                    NomeProduto = red.GetString("nomeProduto"),
                    QtdItemVenda = red.GetInt64("qtdItemVenda"),
                    ValorItemVenda = red.GetDouble("ValorItemVenda"),
                    DescontoVenda = red.GetDouble("descontoVenda"),
                    PercTaxaImposto = red.GetDouble("percTaxaImposto"),
                    NDoc = red.GetInt64("nDoc"),
                    NomeCliente = red.GetString("nomeCliente"),
                    NifCliente = red.GetString("nifCliente"),
                    IdProd = red.GetInt64("id"),
                    IdItemVenda = red.GetInt64("idItem")
                });
            }
            this.conexao.desconectar();
            return lst;
        }// CDVendaOperador
        public void ExcluirVenda(Int64 id, Int64 numDoc)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "DELETE FROM venda WHERE id = @id and nDoc = @numDoc";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@numDoc", numDoc);
                if (this.conexao.objCon.State != ConnectionState.Open)
                {
                    this.conexao.conectar();
                }
                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.conexao.desconectar();
            }

        }// Fim excluir venda
        public void ExcluirItem(Int64 id)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "DELETE FROM itemvenda WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                if (this.conexao.objCon.State != ConnectionState.Open)
                {
                    this.conexao.conectar();
                }
                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.conexao.desconectar();
            }

        }// Fim ExcluirItem
    }
}
