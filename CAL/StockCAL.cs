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
    public class StockCAL
    {
        private Conexao conexao;
        public StockCAL(Conexao con)
        {
            this.conexao = con;
        }
      
        public DataTable listarStock()
        {
            DataTable dados = new DataTable();
            string sql = "select * from stock ";
            MySqlDataAdapter rd = new MySqlDataAdapter(sql, this.conexao.stringConexao);
            rd.Fill(dados);
            return dados;
        }
        public StockModelo getQtdAtual(Int64 idProd)
        {
            StockModelo mod = new StockModelo();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            //idProduto, nomeProduto, codiBarra, precoVenda, , idCat
            cmd.CommandText = "select * from stock where Produto_id = @nome";
            cmd.Parameters.AddWithValue("@nome", idProd);
            this.conexao.conectar();
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                mod.IdStock = red.GetInt32("id");
                mod.IdProd = red.GetInt32("Produto_id");
                mod.QtdStock = red.GetInt32("qtdStock");
                mod.ValorUnitario = red.GetDouble("valorUnitario");
            }
            this.conexao.desconectar();
            return mod;
        }// Fim  getProduto
    }
}
