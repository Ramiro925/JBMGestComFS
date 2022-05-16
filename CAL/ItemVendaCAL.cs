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
    public class ItemVendaCAL
    {
        private Conexao conexao;
        
        public ItemVendaCAL(Conexao con)
        {
            this.conexao = con;
        }
        
        public bool Add(ItemVendaModelo cat,Int64 IdVenda)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "INSERT INTO itemvenda (qtdItemVenda,ValorItemVenda,Produto_id,Venda_id) VALUES (@a,@b,@c,@d)";
                cmd.Parameters.AddWithValue("@a", cat.QtdItemVenda);
                cmd.Parameters.AddWithValue("@b", cat.ValorItemVenda);
                cmd.Parameters.AddWithValue("@c", cat.IdProd);
                cmd.Parameters.AddWithValue("@d", IdVenda);
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

        }// fim Add
        //--------------RETORNA RESUMO TOTAIS POR OPERADOR------------------------
        public RTVendaOperador GetRTVendaPorOperador(Int64 idUtilizador,string dataInit, string dataFim)
        {
            RTVendaOperador mod = new RTVendaOperador();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            cmd.CommandText = "select  u.nomeCompleto, count(distinct v.nDoc) as nDoc, sum(i.qtdItemVenda*v.valorTotalVenda) as totalVenda from utilizador as u, venda as v, itemvenda as i where u.id = v.Utilizador_id and  v.Utilizador_id = @idUtilizador and i.id=v.id and (v.dataVenda between @dataInit and @dataFim)";
            cmd.Parameters.AddWithValue("@idUtilizador", idUtilizador);
            cmd.Parameters.AddWithValue("@dataInit", dataInit);
            cmd.Parameters.AddWithValue("@dataFim", dataFim);
            this.conexao.conectar();
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                try
                {
                    mod.NomeOperador = red.GetString("nomeCompleto");
                    mod.TotaVendaOperador = red.GetDouble("totalVenda");
                    mod.NDocOperador = red.GetInt64("nDoc");
                }
                catch (Exception)
                {
                    mod.TotaVendaOperador = 0.00;
                   // throw;
                }
                
            }
            this.conexao.desconectar();
            return mod;
        }// Fim  Resumo Totais Venda Por Operadores
         //CDVendaOperador
        //public Int64 GetNumeroDocs()
        //{

        //    MySqlCommand cmd = new MySqlCommand();
        //    try
        //    {
        //        cmd.Connection = this.conexao.objCon;
        //        cmd.CommandText = "select max(nDoc) as ultimo from venda";
        //        this.conexao.conectar();

        //        object o = cmd.ExecuteScalar();

        //        if (o.Equals(DBNull.Value))
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return Convert.ToInt64(o) + 1;
        //        }
        //    }
        //    finally
        //    {
        //        this.conexao.desconectar();
        //    }

        //}// Fim  getNDocs
        public List<CDVendaOperador> GetCDVendaOperador(Int64 idUtilizador, string dataInit, string dataFim)
        {
            List<CDVendaOperador> lst = new List<CDVendaOperador>();
           
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            cmd.CommandText = "select v.nDoc, u.nomeCompleto, u.nomeUtilizador, p.nomeProduto,p.codiBarra,i.qtdItemVenda,i.ValorItemVenda,v.nomeCliente,v.descontoVenda from utilizador as u, venda as v, itemvenda as i, produto as p where p.id = i.Produto_id and (u.id = v.Utilizador_id and  v.Utilizador_id = @idUtilizador and i.id = v.id and (v.dataVenda between @dataInit and @dataFim))";
            cmd.Parameters.AddWithValue("@idUtilizador", idUtilizador);
            cmd.Parameters.AddWithValue("@dataInit", dataInit);
            cmd.Parameters.AddWithValue("@dataFim", dataFim);
            this.conexao.conectar();
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                lst.Add(new CDVendaOperador{
                    NDoc = red.GetInt64("nDoc"),
                    NomeCompleto = red.GetString("nomeCompleto"),
                    NomeUtilizador = red.GetString("nomeUtilizador"),
                    NomeProduto = red.GetString("nomeProduto"),
                    CodiBarra = red.GetString("codiBarra"),
                    QtdItemVenda = red.GetInt64("qtdItemVenda"),
                    ValorItemVenda = red.GetDouble("ValorItemVenda"),
                    NomeCliente = red.GetString("nomeCliente"),
                    DescontoVenda = red.GetDouble("descontoVenda")
                });
            }
            this.conexao.desconectar();
            return lst;
        }// CDVendaOperador
    }
}
