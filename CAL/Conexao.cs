using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CAL
{
    public class Conexao
    {
        private String stringCon;
        private MySqlConnection con;

        public Conexao(string dadosConexao)
        {
            this.con = new MySqlConnection();
            this.stringConexao = dadosConexao;
            this.con.ConnectionString = dadosConexao;
        }
        public MySqlConnection objCon
        {
            get { return this.con; }
            set { this.con = value; }
        }
        public String stringConexao
        {
            get { return this.stringCon; }
            set { this.stringCon = value; }
        }

        public void conectar()
        {
            this.con.Open();
        }
        public void desconectar()
        {
            this.con.Close();
        }
     
    }
}
