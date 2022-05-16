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
    public class ProdutoCAL
    {
        private Conexao conexao;
        public ProdutoCAL(Conexao con)
        {
            this.conexao = con;
        }
        public bool add(ProdutoModelo cat)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "INSERT INTO produto (nomeProduto,codiBarra,precoVenda,dataValid,Categoria_id,stockMin,stockMax) VALUES(@nomeProduto,@codiBarra,@precoVenda,@dataValid,@idCat,@stockMin,@stockMax)";
                cmd.Parameters.AddWithValue("@nomeProduto", cat.NomeProduto);
                cmd.Parameters.AddWithValue("@codiBarra", cat.CodiBarra);
                cmd.Parameters.AddWithValue("@precoVenda", cat.PrecoVenda);
                cmd.Parameters.AddWithValue("@dataValid", cat.DataValid);
                cmd.Parameters.AddWithValue("@idCat", cat.IdCat);
                cmd.Parameters.AddWithValue("@stockMin", cat.StockMin);
                cmd.Parameters.AddWithValue("@stockMax", cat.StockMax);
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
        public bool atualizar(ProdutoModelo cat)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "UPDATE produto SET nomeProduto = @nomeProduto,codiBarra = @codiBarra,precoVenda = @precoVenda,dataValid = @dataValid,Categoria_id = @idCat,stockMin = @stockMin,stockMax = @stockMax WHERE id = @id";
                cmd.Parameters.AddWithValue("@nomeProduto", cat.NomeProduto);
                cmd.Parameters.AddWithValue("@codiBarra", cat.CodiBarra);
                cmd.Parameters.AddWithValue("@precoVenda", cat.PrecoVenda);
                cmd.Parameters.AddWithValue("@dataValid", cat.DataValid);
                cmd.Parameters.AddWithValue("@idCat", cat.IdCat);
                cmd.Parameters.AddWithValue("@stockMin", cat.StockMin);
                cmd.Parameters.AddWithValue("@stockMax", cat.StockMax);
                cmd.Parameters.AddWithValue("@id", cat.Id);
                
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

        public void excluir(Int64 codigo)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "DELETE FROM produto WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", codigo);
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
            
        }
        public DataTable listarProduto()
        {
            DataTable dados = new DataTable();
            string sql = "select  distinct * from produto as p inner join  categoria as c on  p.Categoria_id = c.id ORDER BY desigCategoria";
            MySqlDataAdapter rd = new MySqlDataAdapter(sql, this.conexao.stringConexao);
            rd.Fill(dados);
            return dados;
        }
        public ProdutoModelo getProduto(string pivoCodigoBarra)
        {
            ProdutoModelo mod = new ProdutoModelo();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            cmd.CommandText = "select * from produto where codiBarra = @nome";
            cmd.Parameters.AddWithValue("@nome", pivoCodigoBarra);
            this.conexao.conectar();
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                mod.Id = red.GetInt32("id");
                mod.NomeProduto = red.GetString("nomeProduto");
                mod.CodiBarra = red.GetString("codiBarra");
                mod.PrecoVenda = red.GetDouble("precoVenda");
                mod.DataValid = red.GetString("dataValid");
                mod.IdCat = red.GetInt32("Categoria_id");
                mod.StockMin = red.GetInt64("stockMin");
                mod.StockMax = red.GetInt64("stockMax");
            }
            this.conexao.desconectar();
            return mod;
        }// Fim  getProduto

        public bool getProdutoVerifique(string pivoCodigoBarra)
        {
            ProdutoModelo mod = new ProdutoModelo();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            cmd.CommandText = "SELECT EXISTS(SELECT* FROM produto WHERE codiBarra = @nome)";
            cmd.Parameters.AddWithValue("@nome", pivoCodigoBarra);
            this.conexao.conectar();
          
            object o = cmd.ExecuteScalar();
            this.conexao.desconectar();
            if (Convert.ToInt32(o) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }// Fim  getProduto

    }
}
