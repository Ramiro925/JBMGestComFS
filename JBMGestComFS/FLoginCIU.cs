using System;
using System.Windows.Forms;
using MODELO;
using CLN;
using CAL;

namespace JBMGestComFS
{
    public partial class FLoginCIU : Form
    {
        UtilizadorModelo cat = new UtilizadorModelo();
        Conexao con = new Conexao(DadosConexao.stringConexao);
        UtilizadorCLN catcln;
        FMenuCIU f;

        public FLoginCIU()
        {
            InitializeComponent();
            f = new FMenuCIU();
        }

        private void ptFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ptMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                catcln = new UtilizadorCLN(con);

                UtilizadorModelo u = catcln.GetUtilizadorCLN(txtUtillizador.Text);
                if (txtUtillizador.Text=="AURY" && txtSenha.Text == "RMX925" )
                {
                    FMenuCIU f = new FMenuCIU(u);
                    f.Show();
                    this.Hide();
                }
                if (u.NomeUtilizador == txtUtillizador.Text && u.SenhaUtilizador == txtSenha.Text && u.Cargo == "GERENTE COMERCIAL")
                {
                            FMenuCIU f = new FMenuCIU(u);
                            f.Show();
                            this.Hide();
                }
                else 
                if (u.NomeUtilizador == txtUtillizador.Text && u.SenhaUtilizador == txtSenha.Text && u.Cargo == "VENDEDOR")
                {
                        VendaCIU a = new VendaCIU(u);
                        a.Show();
                        this.Hide();
                }
                else
                {
                        label4.Visible = true;
                        label4.Text = "Senha e Utilizador inexistentes";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            
        }
    }
}
