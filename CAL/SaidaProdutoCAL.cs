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
    
    public class SaidaProdutoCAL
    {
        private Conexao conexao;
        public SaidaProdutoCAL(Conexao con)
        {
            this.conexao = con;
        }
        public Int64 getNumeroDocs()
        {

            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "select max(nDoc) as ultimo from saidaproduto";
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
        public bool add(SaidaProdutoModelo cat)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = this.conexao.objCon;
                cmd.CommandText = "INSERT INTO saidaproduto (qtdSaida,dataSaida,valorUnitario,Produto_id,Utilizador_id,nDoc) VALUES (@qtdSaida,@dataSaida,@valorUnitario,@idProd,@idUtiliz,@nDoc)";
                cmd.Parameters.AddWithValue("@qtdSaida", cat.QtdSaida);
                cmd.Parameters.AddWithValue("@dataSaida", cat.DataSaida);
                cmd.Parameters.AddWithValue("@valorUnitario", cat.ValorUnitario);
                cmd.Parameters.AddWithValue("@idProd", cat.IdProd);
                cmd.Parameters.AddWithValue("@idUtiliz", cat.IdUtiliz);
                cmd.Parameters.AddWithValue("@nDoc", cat.NDocs);
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
    }
}
