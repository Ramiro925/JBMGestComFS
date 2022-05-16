using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODELO;
using CLN;
using CAL;

namespace JBMGestComFS
{
    public partial class FuncionarioCIU : Form
    {
        UtilizadorModelo cat = new UtilizadorModelo();
        Conexao con = new Conexao(DadosConexao.stringConexao);
        UtilizadorCLN catcln;
        private int codigo;
        public FuncionarioCIU()
        {
            InitializeComponent();
            preencherDataGriedView();
            configDataGriedView();
        }
        public void desloqueTabView(int index) 
        {
            tabControlUtilizador.SelectedIndex = index;
        }
        private void configDataGriedView()
        {
            dgvVisualizarUtiliz.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvVisualizarUtiliz.RowHeadersWidth = 100;
            dgvVisualizarUtiliz.Columns["id"].HeaderText = "N/O";
            dgvVisualizarUtiliz.Columns["id"].Visible = true;
            dgvVisualizarUtiliz.Columns["nomeCompleto"].HeaderText = "Nome Completo";
            dgvVisualizarUtiliz.Columns["nomeCompleto"].Visible = true;
            dgvVisualizarUtiliz.Columns["nomeUtilizador"].HeaderText = "Utilizador";
            dgvVisualizarUtiliz.Columns["nomeUtilizador"].Visible = true;
            dgvVisualizarUtiliz.Columns["senhaUtilizador"].HeaderText = "Senha";
            dgvVisualizarUtiliz.Columns["senhaUtilizador"].Visible = false;
            dgvVisualizarUtiliz.Columns["cargo"].HeaderText = "Cargo";
            dgvVisualizarUtiliz.Columns["cargo"].Visible = true;
            dgvVisualizarUtiliz.Columns["telefone"].HeaderText = "Telefone";
            dgvVisualizarUtiliz.Columns["telefone"].Visible = true;
            dgvVisualizarUtiliz.Columns["dataAdmitido"].HeaderText = "Admitido";
            dgvVisualizarUtiliz.Columns["dataAdmitido"].Visible = true;
            dgvVisualizarUtiliz.Columns["numBi"].HeaderText = "BI";
            dgvVisualizarUtiliz.Columns["numBi"].Visible = true;
        }
        public void preencherDataGriedView()
        {
            try
            {
                catcln = new UtilizadorCLN(con);
                dgvVisualizarUtiliz.DataSource = catcln.Listar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        public void limpar()
        {
            txtUtilizador.Text = "";
            txtSenha.Text = "";
            txtConfirSenha.Text = "";
            txtNomeCompleto.Text = "";
            txtNumBI.Text = "";
            txtTelefone1.Text = "";
        }

        private void Funcionario_Load(object sender, EventArgs e)
        {
            cbCargo.SelectedIndex = 0;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.codigo <= 0)
            {
                MessageBox.Show("Selecione para poder editar", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    catcln = new UtilizadorCLN(con);
                    cat.NomeCompleto = txtNomeCompleto.Text;
                    cat.NomeUtilizador = txtUtilizador.Text;
                    cat.SenhaUtilizador = txtSenha.Text;
                    cat.Cargo = cbCargo.Text;
                    cat.DataAdmitido = dtUtilizador.Text;
                    cat.Telefone = txtTelefone1.Text;
                    cat.NumBI = txtNumBI.Text;
                    cat.Id = this.codigo;
                    bool res = catcln.Atualizar(cat);
                    if (res == false)
                    {
                        MessageBox.Show("Erro na atualização de dado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                    }
                    desloqueTabView(1);
                    preencherDataGriedView();
                    limpar();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }
        private void dgvVisualizarUtiliz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //--------------EVENTO DE SELEÇÃO INTELIGENTE NO DATA GRIED VIEW--------------
            int numLinha = e.RowIndex;
            if (numLinha >= 0)
            {
                this.codigo = Convert.ToInt32(dgvVisualizarUtiliz.Rows[numLinha].Cells[0].Value);
                txtNomeCompleto.Text = (dgvVisualizarUtiliz.Rows[numLinha].Cells[1].Value).ToString();
                dtUtilizador.Text = (dgvVisualizarUtiliz.Rows[numLinha].Cells[2].Value).ToString();
                txtTelefone1.Text = (dgvVisualizarUtiliz.Rows[numLinha].Cells[3].Value).ToString();
                txtSenha.Text = (dgvVisualizarUtiliz.Rows[numLinha].Cells[3].Value).ToString();
                txtConfirSenha.Text = (dgvVisualizarUtiliz.Rows[numLinha].Cells[3].Value).ToString();
                txtNumBI.Text = (dgvVisualizarUtiliz.Rows[numLinha].Cells[4].Value).ToString();
                txtUtilizador.Text = (dgvVisualizarUtiliz.Rows[numLinha].Cells[5].Value).ToString();
                
                string a = (dgvVisualizarUtiliz.Rows[numLinha].Cells[7].Value).ToString(); 
                cbCargo.SelectedIndex = (a.Equals("GERENTE COMERCIAL")) ? 1 : 0;      
            }
            desloqueTabView(0);
        }

        private void btnGuardarProdut_Click(object sender, EventArgs e)
        {
            bool res = false;
            try
            {
                catcln = new UtilizadorCLN(con);
                cat.NomeCompleto = txtNomeCompleto.Text;
                cat.NomeUtilizador = txtUtilizador.Text.ToUpper();
                cat.SenhaUtilizador = txtSenha.Text;
                cat.SenhaUtilizador = txtConfirSenha.Text;
                cat.Cargo = cbCargo.Text;
                cat.DataAdmitido = dtUtilizador.Text;
                cat.Telefone = txtTelefone1.Text;
                cat.NumBI = txtNumBI.Text;
                
                if (txtSenha.Text.Equals(txtConfirSenha.Text))
                {
                    res = catcln.Add(cat);
                    desloqueTabView(1);
                    limpar();
                    preencherDataGriedView();
                    configDataGriedView();
                    MessageBox.Show("Utilizador criado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                if (res == false)
                {
                    MessageBox.Show("Erro na inserção de dado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.codigo <= 0)
            {
                MessageBox.Show("Selecione para poder ExcluirVenda", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    catcln = new UtilizadorCLN(con);
                    //cat.DesigCategoria = txtDescCateg.Text;
                    var confirm = MessageBox.Show("Deseja ExcluirVenda ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (confirm == DialogResult.Yes)
                    {
                        catcln.Excluir(this.codigo);
                    }
                    desloqueTabView(1);
                    preencherDataGriedView();
                    limpar();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao ExcluirVenda dado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
