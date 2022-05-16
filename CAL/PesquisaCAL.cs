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
    public class PesquisaCAL
    {
        private Conexao conexao;
        public PesquisaCAL(Conexao con)
        {
            this.conexao = con;
        }
        public DataTable listarProduto()
        {
            DataTable dados = new DataTable();
            //string sql = "select* from produto order by nomeProduto asc";
            string sql = "select p.idProduto, p.nomeProduto, p.codiBarra, p.precoVenda, p.dataValid,p.idCat, c.desigCategoria from produto p, categoria c WHERE p.idProduto = p.idCat or p.idCat = c.idCategoria";
            //string sql = "select codiBarra, nomeProduto, precoVenda, dataValid from produto order by nomeProduto asc";
            MySqlDataAdapter rd = new MySqlDataAdapter(sql, this.conexao.stringConexao);
            rd.Fill(dados);
            return dados;
        }
    }
}
