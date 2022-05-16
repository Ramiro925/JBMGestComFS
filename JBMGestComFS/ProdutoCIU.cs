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
    public partial class ProdutoCIU : Form
    {
        ProdutoModelo cat = new ProdutoModelo();
        Conexao con = new Conexao(DadosConexao.stringConexao);
        string a;
        ProdutoCLN catcln;
        private int codigo;
        CategoriaCLN clncat;
        public ProdutoCIU()
        {
            InitializeComponent();
            preencherCat();
            preencherDataGriedView();
            configDataGriedView();
        }
        private Int64 getQtdAtualProd(Int64 idProd)
        {
            StockCLN s = new StockCLN(con);
            StockModelo smod = s.getQtdCLN(idProd);
            return smod.QtdStock;
        }
        public void desloqueTabView(int index)
        {
            tabControlProduto.SelectedIndex = index;
        }
        public void preencherCat()
        {
            CategoriaCLN catcln = new CategoriaCLN(con);
            cbCategoria.DataSource = catcln.listarComb();
            cbCategoria.SelectedIndex = 0;
        }
        private void configDataGriedView()
        {
            dtListaProduto.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dtListaProduto.RowHeadersWidth = 80;
            dtListaProduto.Columns["id"].HeaderText = "N/O";
            dtListaProduto.Columns["id"].Visible = false;
            dtListaProduto.Columns["codiBarra"].HeaderText = "Codigo do Produto";
            dtListaProduto.Columns["codiBarra"].Visible = true;
            dtListaProduto.Columns["nomeProduto"].HeaderText = "Descrição Produto/Serviço";
            dtListaProduto.Columns["nomeProduto"].Visible = true;
            dtListaProduto.Columns["precoVenda"].HeaderText = "Preço Unitário";
            dtListaProduto.Columns["precoVenda"].Visible = true;
            dtListaProduto.Columns["dataValid"].HeaderText = "Data de Validade";
            dtListaProduto.Columns["dataValid"].Visible = true;
            dtListaProduto.Columns["Categoria_id"].HeaderText = "idCat";
            dtListaProduto.Columns["Categoria_id"].Visible = false;
            dtListaProduto.Columns["stockMin"].HeaderText = "Estoque Minimo";
            dtListaProduto.Columns["stockMin"].Visible = true;
            dtListaProduto.Columns["stockMax"].HeaderText = "Estoque Máximo";
            dtListaProduto.Columns["stockMax"].Visible = true;
            dtListaProduto.Columns["id1"].HeaderText = "Categoria";
            dtListaProduto.Columns["id1"].Visible = false;
            dtListaProduto.Columns["desigCategoria"].HeaderText = "Categoria";
            dtListaProduto.Columns["desigCategoria"].Visible = true;
        }
        public void preencherDataGriedView()
        {
            try
            {
                catcln = new ProdutoCLN(con);
                dtListaProduto.DataSource = catcln.listar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        public void limpar()
        {
            txtCodigoESC.Text = "";
            txtDesignacaoESC.Text = "";
            txtEstoqueActualESC.Text = "";
            txtPrecoVendaESC.Text = "";
            txtStockMin.Text = "";
            txtStockMax.Text = "";
        }
        private void ProdutoCIU_Load(object sender, EventArgs e)
        {
           
        }
        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            try
            {
                catcln = new ProdutoCLN(con);
                clncat = new CategoriaCLN(con);
                cat.CodiBarra = txtCodigoESC.Text;
                cat.NomeProduto = txtDesignacaoESC.Text;
                cat.PrecoVenda = Convert.ToDouble(txtPrecoVendaESC.Text);
                cat.DataValid = dtpDataValid.Text;
                cat.StockMin = Convert.ToInt64(txtStockMin.Text);
                cat.StockMax = Convert.ToInt64(txtStockMax.Text);
                //cat.IdCat captura o indice valores do item selecionado cujo a primeira pos da combo eh zero
                //Tomar sempre cuidado quando está se eliminar e Atualizar a tabela Categoria na BD isso porque
                //Desorienta as posições certas na combobox. 
                // cat.IdCat = cbCategoria.SelectedIndex + 1;
                cat.IdCat = clncat.getCatbyNameCLN(cbCategoria.Text);
                
                if (cat.StockMax<= cat.StockMin)
                {
                    MessageBox.Show("Estoque Máximo Inferior ou Igual do que o Estoque Mínimo!");
                }
                else
                {
                    bool res = catcln.add(cat);
                    if (res == false)
                    {
                        MessageBox.Show("Erro na inserção de dado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        limpar();
                    }
                }
                
                preencherDataGriedView();
             
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void dtListaProduto_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //--------------EVENTO DE SELEÇÃO INTELIGENTE NO DATA GRIED VIEW--------------
            int numLinha = e.RowIndex;

            if (numLinha >= 0)
            {
                this.codigo = Convert.ToInt32(dtListaProduto.Rows[numLinha].Cells[0].Value);
                txtDesignacaoESC.Text = (dtListaProduto.Rows[numLinha].Cells[1].Value).ToString().Trim();
                txtCodigoESC.Text = (dtListaProduto.Rows[numLinha].Cells[2].Value).ToString().Trim();
                txtCodigoESC.Enabled = false;
                txtPrecoVendaESC.Text = (dtListaProduto.Rows[numLinha].Cells[3].Value).ToString().Trim();
                dtpDataValid.Text = (dtListaProduto.Rows[numLinha].Cells[4].Value).ToString().Trim();
                txtStockMin.Text = (dtListaProduto.Rows[numLinha].Cells[6].Value).ToString().Trim();
                txtStockMax.Text = (dtListaProduto.Rows[numLinha].Cells[7].Value).ToString().Trim();
                a = Convert.ToString(dtListaProduto.Rows[numLinha].Cells[9].Value);
                int i = cbCategoria.FindString(a);
                cbCategoria.SelectedIndex = i;
                txtEstoqueActualESC.Text = Convert.ToString(getQtdAtualProd(catcln.getProdutoCLN(txtCodigoESC.Text).Id));
            }
            desloqueTabView(0);
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            
            if (this.codigo <= 0)
            {
                MessageBox.Show("Selecione para poder editar", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                catcln = new ProdutoCLN(con);
                cat.NomeProduto = txtDesignacaoESC.Text.Trim();
                cat.CodiBarra = txtCodigoESC.Text.Trim();
                cat.PrecoVenda = Convert.ToDouble(txtPrecoVendaESC.Text.Trim());
                cat.DataValid = dtpDataValid.Text;
                cat.StockMin = Convert.ToInt64(txtStockMin.Text.Trim());
                cat.StockMax = Convert.ToInt64(txtStockMax.Text.Trim());
                clncat = new CategoriaCLN(con);
                cat.IdCat = clncat.getCatbyNameCLN(cbCategoria.Text);
                cat.Id = this.codigo;
                //MessageBox.Show(""+ " "+cat.IdCat);
                if (cat.StockMax <= cat.StockMin)
                {
                    MessageBox.Show("Estoque Máximo Inferior ou Igual do que o Estoque Mínimo!");
                }
                else 
                {
                    try
                    {
                        
                        bool res = catcln.atualizar(cat);
                        txtCodigoESC.Enabled = true;
                        if (res == false)
                        {
                            MessageBox.Show("Erro na atualização de dado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            limpar();
                        }
                        preencherDataGriedView();
                     
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
                
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
                    catcln = new ProdutoCLN(con);
                    //cat.DesigCategoria = txtDescCateg.Text;
                    var confirm = MessageBox.Show("Deseja ExcluirVenda ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (confirm == DialogResult.Yes)
                    {
                        catcln.excluir(this.codigo);
                        txtCodigoESC.Enabled = true;
                    }
                    preencherDataGriedView();
                    limpar();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao ExcluirVenda dado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }// FIM MÉTODO EXCLUIR

        private void ProdutoCIU_Load_1(object sender, EventArgs e)
        {
            //preencherCat();
            //preencherDataGriedView();
            //configDataGriedView();
        }
    }
}