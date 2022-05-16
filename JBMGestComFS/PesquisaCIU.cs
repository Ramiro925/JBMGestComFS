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
    public partial class PesquisaCIU : Form
    {
        ProdutoModelo cat = new ProdutoModelo();
        Conexao con = new Conexao(DadosConexao.stringConexao);
        ProdutoCLN catcln;
        private int codigo;
        private DataView dv;
        private CurrencyManager cm;
        EntradaProdutoCIU fInfor;//= new EntradaProdutoCIU();
        //fsInfor = new SaidaProdutoCIU();
        //fvInfor = new VendaCIU();
        SaidaProdutoCIU fsInfor; //= new SaidaProdutoCIU();
        VendaCIU fvInfor;//= new VendaCIU();
        //fInfor = new EntradaProdutoCIU();
        //VendaProdutoCIU fvInfor;

        public PesquisaCIU(EntradaProdutoCIU fInfor, SaidaProdutoCIU fsInfor, VendaCIU fvInfor)
        {
            this.fInfor = fInfor;
            this.fsInfor = fsInfor;
            this.fvInfor = fvInfor;
            InitializeComponent();
            
        }
        //public PesquisaCIU(EntradaProdutoCIU inf)
        //{
         
        //    InitializeComponent();
        //    this.fInfor = inf;
  
        //}
        //public PesquisaCIU(SaidaProdutoCIU inf)
        //{
        //    InitializeComponent();
        //    this.fsInfor = inf;
        //}
        private void configDataGriedView()
         {
               dtgvPesquisarCIU.DefaultCellStyle.Font = new Font("Segoe UI", 8);
               dtgvPesquisarCIU.RowHeadersWidth = 80;
               dtgvPesquisarCIU.Columns["id"].HeaderText = "ID";
               dtgvPesquisarCIU.Columns["id"].Visible = false;
               dtgvPesquisarCIU.Columns["codiBarra"].HeaderText = "Codigo do Produto";
               dtgvPesquisarCIU.Columns["codiBarra"].Visible = true;
               dtgvPesquisarCIU.Columns["nomeProduto"].HeaderText = "Descrição Produto/Serviço";
               dtgvPesquisarCIU.Columns["nomeProduto"].Visible = true;
               dtgvPesquisarCIU.Columns["precoVenda"].HeaderText = "Preço Unitário";
               dtgvPesquisarCIU.Columns["precoVenda"].Visible = true;
               dtgvPesquisarCIU.Columns["dataValid"].HeaderText = "Data de Validade";
               dtgvPesquisarCIU.Columns["dataValid"].Visible = false;
               dtgvPesquisarCIU.Columns["Categoria_id"].HeaderText = "idCat";
               dtgvPesquisarCIU.Columns["Categoria_id"].Visible = false;
               dtgvPesquisarCIU.Columns["id1"].HeaderText = "idCat";
               dtgvPesquisarCIU.Columns["id1"].Visible = false;
               dtgvPesquisarCIU.Columns["stockMin"].HeaderText = "Estoque Mínimo";
               dtgvPesquisarCIU.Columns["stockMin"].Visible = false;
               dtgvPesquisarCIU.Columns["stockMax"].HeaderText = "Estoque Máximo";
               dtgvPesquisarCIU.Columns["stockMax"].Visible = false;
               dtgvPesquisarCIU.Columns["desigCategoria"].HeaderText = "Categoria";
               dtgvPesquisarCIU.Columns["desigCategoria"].Visible = true;
           
               dtgvPesquisarCIU.AutoSize = true;
               dtgvPesquisarCIU.ReadOnly = true;
               dtgvPesquisarCIU.AllowUserToResizeRows = false;
               dtgvPesquisarCIU.AllowUserToDeleteRows = false;
               dtgvPesquisarCIU.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         }
        private void PesquisaCIU_Load(object sender, EventArgs e)
        {
            preencherDataGriedView();
            configDataGriedView();
        }
        private DataView GetDataView() 
        {
            catcln = new ProdutoCLN(con);
            // Prienche a DataTable com 
            DataTable dt = new DataTable();
            dt = catcln.listar();
            // Criar o data view e define a coluna de ordenada
            DataView dv = new DataView(dt);
            dv.Sort = dt.Columns[0].ColumnName;
            return dv;
        }
        public void preencherDataGriedView()
        {
            try
            {
                dv = GetDataView();
                dtgvPesquisarCIU.DataSource = dv;
                cm = (CurrencyManager)dtgvPesquisarCIU.BindingContext[dv];
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void dtgvPesquisarCIU_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //--------------EVENTO DE SELEÇÃO INTELIGENTE NO DATA GRIED VIEW--------------
            int numLinha = e.RowIndex;

            if (numLinha >= 0)
            {
                this.codigo = Convert.ToInt32(dtgvPesquisarCIU.Rows[numLinha].Cells[0].Value);
                // captura o valor da segunda coluna da datagridview do formulário pesquisa e envia para Textbox Código do formulário EntradaProdutoCIU
                string valorPesquisa = (dtgvPesquisarCIU.Rows[numLinha].Cells[2].Value).ToString();
                // Respectivamente os TextBoxs recebem o meu valor da variável "valorPesquisa"
                //----ESSA CODIFICAÇÃO É UTIL PARA EVITAR NULLREFERENCEEXCEPTION
                
                //fInfor.txtCodigoProdutoET.Text = valorPesquisa;
               
                //fsInfor.txtCodigoProdutoSD.Text = valorPesquisa;
               
                //fvInfor.txtCodigoProdutoFC.Text = valorPesquisa;
                //if (fInfor == null)
                //{
                //    fInfor = new EntradaProdutoCIU();
                //    //fsInfor = new SaidaProdutoCIU();
                //    //fvInfor = new VendaCIU();
                fInfor.txtCodigoProdutoET.Text = fsInfor.txtCodigoProdutoSD.Text = fvInfor.txtCodigoProdutoFC.Text = valorPesquisa;
                //    fInfor.txtCodigoProdutoET.Text = valorPesquisa;
                //}
                //else
                //if (fsInfor == null)
                //{
                //    fsInfor = new SaidaProdutoCIU();
                //    //fInfor = new EntradaProdutoCIU();
                //    //fvInfor = new VendaCIU();
                //    //fInfor.txtCodigoProdutoET.Text = fsInfor.txtCodigoProdutoSD.Text = fvInfor.txtCodigoProdutoFC.Text = valorPesquisa;
                //    fsInfor.txtCodigoProdutoSD.Text = valorPesquisa;
                //}
                //if (fvInfor == null)
                //{
                //    //fsInfor = new SaidaProdutoCIU();
                //    //fInfor = new EntradaProdutoCIU();
                //    fvInfor = new VendaCIU();
                //    fInfor.txtCodigoProdutoET.Text = fvInfor.txtCodigoProdutoFC.Text = fsInfor.txtCodigoProdutoSD.Text = valorPesquisa;
                //    //fvInfor.txtCodigoProdutoFC.Text = valorPesquisa;
                //}
                this.Dispose();
            }
        }
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtPesquisarCIU.Text != "")
            {
                bool parseStatus = false;
                switch (dtgvPesquisarCIU.SortedColumn.Index)
                {
                    case 0:
                    // se a ordenação estiver na primeira coluna
                    // é necessário garantir que o valor da busca seja 
                    // um valor inteiro (caso esta coluna seja um inteiro)
                    //int j;
                    //parseStatus = int.TryParse(txtCriterio.Text, out j);
                    //break;
                    case 1:
                    case 2:
                        // A segunda e terceira coluna são strings
                        // assim o valor da busca não precisa ser validado
                        parseStatus = true;
                        break;
                }
                if (parseStatus)
                {
                    // Encontra o produto
                    try
                    {
                        int i = dv.Find(txtPesquisarCIU.Text);
                        if (i < 0)
                            // Não Foi encontrado
                            MessageBox.Show("Nenhum registro foi encontrado.", "Procurar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        else
                            // Reposiciona o registro do grid usando o CurrencyManager.
                            cm.Position = i;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Formato de Dado Incorreto.", "Procurar",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                    }
                    
                }
                else
                {
                    MessageBox.Show("O tipos de dados do valor da busca " +
                        "deve ser do tipo da coluna ordenada.",
                        "Procurar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPesquisarCIU.Focus();
                }
            }
            else
            {
                MessageBox.Show("Informe o critério de busca.", "Procurar",
                    MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtPesquisarCIU.Focus();
            }
        }
    }
  
}
