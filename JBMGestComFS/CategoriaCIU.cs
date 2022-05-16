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
    public partial class CategoriaCIU : Form
    {
        CategoriaModelo cat = new CategoriaModelo();
        Conexao con = new Conexao(DadosConexao.stringConexao);
        CategoriaCLN catcln;
        private int codigo;
        public CategoriaCIU()
        {
            InitializeComponent();
        }
        private void configDataGriedView()
        {
            dtListarCateg.DefaultCellStyle.Font = new Font("Segoe UI",9);
            dtListarCateg.RowHeadersWidth = 25;
            dtListarCateg.Columns["id"].HeaderText = "NÚMERO DE ORDEM";
            dtListarCateg.Columns["id"].Visible = true;
            dtListarCateg.Columns["desigCategoria"].HeaderText = "DESCRIÇÃO DA CATEGORIA";
            dtListarCateg.Columns["desigCategoria"].Visible = true;
        }
        public void preencherDataGriedView()
        {
            try
            {
                catcln = new CategoriaCLN(con);
                dtListarCateg.DataSource = catcln.listar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        public void limpar()
        {
            txtDescCateg.Text = "";
        }
        private void CategoriaCIU_Load(object sender, EventArgs e)
        {
            preencherDataGriedView();
            configDataGriedView();
        }
        private void btnAddCateg_Click(object sender, EventArgs e)
        {
            try
            {
                catcln = new CategoriaCLN(con);
                cat.DesigCategoria = txtDescCateg.Text;
                bool res = catcln.add(cat);
                if (res == false)
                {
                    MessageBox.Show("Erro na inserção de dado","Informação",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {

                }
                preencherDataGriedView();
                limpar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void dtListarCateg_CellClick(object sender, DataGridViewCellEventArgs e)
        {//--------------EVENTO DE SELEÇÃO INTELIGENTE NO DATA GRIED VIEW--------------
            int numLinha = e.RowIndex;

            if (numLinha >= 0)
            {
                this.codigo = Convert.ToInt32(dtListarCateg.Rows[numLinha].Cells[0].Value);
                txtDescCateg.Text = (dtListarCateg.Rows[numLinha].Cells[1].Value).ToString();
            }
        }

        private void btnEditarCateg_Click(object sender, EventArgs e)
        {
            if (this.codigo <= 0)
            {
             MessageBox.Show("Selecione para poder editar", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    catcln = new CategoriaCLN(con);
                    cat.DesigCategoria = txtDescCateg.Text;
                    cat.Id = this.codigo;
                    bool res = catcln.atualizar(cat);
                    if (res == false)
                    {
                        MessageBox.Show("Erro na atualização de dado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                    }
                   
                    preencherDataGriedView();
                    limpar();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void btnExcluirCateg_Click(object sender, EventArgs e)
        {
            if (this.codigo <= 0)
            {
                MessageBox.Show("Selecione para poder ExcluirVenda", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    catcln = new CategoriaCLN(con);
                    cat.DesigCategoria = txtDescCateg.Text;
                    var confirm = MessageBox.Show("Deseja ExcluirVenda ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (confirm == DialogResult.Yes)
                    {
                        catcln.excluir(this.codigo);
                    }
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
