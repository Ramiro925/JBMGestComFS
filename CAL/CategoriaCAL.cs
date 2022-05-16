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
    public class CategoriaCAL
    {
        private Conexao conexao;
        public CategoriaCAL(Conexao con)
        {
            this.conexao = con;
        }

        public bool add(CategoriaModelo cat)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "INSERT INTO categoria (desigCategoria) VALUES(@desigCategoria)";
                cmd.Parameters.AddWithValue("@desigCategoria", cat.DesigCategoria);
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
        public bool atualizar(CategoriaModelo cat)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "UPDATE categoria SET desigCategoria = @desigCategoria WHERE id = @id";
                cmd.Parameters.AddWithValue("@desigCategoria", cat.DesigCategoria);
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
                cmd.CommandText = "DELETE FROM categoria WHERE id = @id";
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
        public DataTable listarCategoria()
        {
            DataTable dados = new DataTable();
            string sql = "SELECT * FROM categoria";
            MySqlDataAdapter rd = new MySqlDataAdapter(sql, this.conexao.stringConexao);
            rd.Fill(dados);
            return dados;
        }
        public List<string> listarCategoriaCombo()
        {//Seleção rápida na combobox
            List<string> dados = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            cmd.CommandText = "SELECT * FROM categoria";
            this.conexao.conectar();
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                dados.Add(red.GetString("desigCategoria"));
            }
            this.conexao.desconectar();
            return dados;
        }
        public Int64 getCatbyName(string busca)
        {
           CategoriaModelo mod = new CategoriaModelo();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            cmd.CommandText = "select * from categoria where desigCategoria = @nome";
            cmd.Parameters.AddWithValue("@nome", busca);
            this.conexao.conectar();
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                mod.Id = red.GetInt32("id");
                mod.DesigCategoria = red.GetString("desigCategoria");
            }
            this.conexao.desconectar();
            return mod.Id;
        }
    }
}
