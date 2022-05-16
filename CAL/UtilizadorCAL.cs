using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MODELO;
using System.Data;

namespace CAL
{
    public class UtilizadorCAL
    {
        private Conexao conexao;
        
        public UtilizadorCAL(Conexao con)
        {
            this.conexao = con;
        }
        public bool Add(UtilizadorModelo cat)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "INSERT INTO utilizador (nomeCompleto,nomeUtilizador,senhaUtilizador,cargo,dataAdmitido,telefone,numBi) VALUES(@nomeCompleto,@nomeUtilizador,@senhaUtilizador,@cargo,@dataAdmitido,@telefone1,@numBI)";
                cmd.Parameters.AddWithValue("@nomeCompleto", cat.NomeCompleto);
                cmd.Parameters.AddWithValue("@nomeUtilizador", cat.NomeUtilizador);
                cmd.Parameters.AddWithValue("@senhaUtilizador", cat.SenhaUtilizador);
                cmd.Parameters.AddWithValue("@cargo", cat.Cargo);
                cmd.Parameters.AddWithValue("@dataAdmitido", cat.DataAdmitido);
                cmd.Parameters.AddWithValue("@telefone1", cat.Telefone);
                cmd.Parameters.AddWithValue("@numBI", cat.NumBI);
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
        public bool Atualizar(UtilizadorModelo cat)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "UPDATE utilizador SET  nomeCompleto = @nomeCompleto, nomeUtilizador = @nomeUtilizador,senhaUtilizador = @senhaUtilizador,cargo = @cargo,dataAdmitido = @dataAdmitido,telefone = @telefone1,numBi = @numBI WHERE id = @id";
                cmd.Parameters.AddWithValue("@nomeCompleto", cat.NomeCompleto);
                cmd.Parameters.AddWithValue("@nomeUtilizador", cat.NomeUtilizador);
                cmd.Parameters.AddWithValue("@senhaUtilizador", cat.SenhaUtilizador);
                cmd.Parameters.AddWithValue("@cargo", cat.Cargo);
                cmd.Parameters.AddWithValue("@dataAdmitido", cat.DataAdmitido);
                cmd.Parameters.AddWithValue("@telefone1", cat.Telefone);
                cmd.Parameters.AddWithValue("@numBI", cat.NumBI);
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
        public void Excluir(Int64 codigo)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "DELETE FROM utilizador WHERE id = @id";
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
        public DataTable ListarUtilizador()
        {
            DataTable dados = new DataTable();
            string sql = "select* from utilizador order by nomeUtilizador asc";
            //string sql = "select codiBarra, nomeProduto, precoVenda, dataValid from produto order by nomeProduto asc";
            MySqlDataAdapter rd = new MySqlDataAdapter(sql, this.conexao.stringConexao);
            rd.Fill(dados);
            return dados;
        }
        //METODO USADO PARA RETORNAR O UTILIZADOR COM OS SEUS RESPECTIVOS DADOS EM FUNÇÃO DO NOME UTILIZADOR(PIVO) 
        public UtilizadorModelo GetUtilizador(string pivo)
        {
            UtilizadorModelo mod = new UtilizadorModelo();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            cmd.CommandText = "select * from utilizador where nomeUtilizador = @nome";
            cmd.Parameters.AddWithValue("@nome",pivo);
            this.conexao.conectar();
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                mod.Id = red.GetInt32("id");
                mod.NomeCompleto = red.GetString("nomeCompleto");
                mod.NomeUtilizador = red.GetString("nomeUtilizador");
                mod.SenhaUtilizador = red.GetString("senhaUtilizador");
                mod.Cargo = red.GetString("cargo");
                mod.DataAdmitido = red.GetString("dataAdmitido");
                mod.Telefone = red.GetString("telefone");
                mod.NumBI = red.GetString("numBi");
            }
            this.conexao.desconectar();
            return mod;
        }// Fim GetUtilizador
        public List<string> ListarUtilizadorCombo()
        {//Seleção rápida na combobox
            List<string> dados = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = this.conexao.objCon;
            cmd.CommandText = "SELECT * FROM utilizador";
            this.conexao.conectar();
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                dados.Add(red.GetString("nomeUtilizador"));
            }
            this.conexao.desconectar();
            return dados;
        }

    }
}
