using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MODELO;
using CLN;
using CAL;

namespace JBMGestComFS
{
    public partial class DevolucaoCIU : Form
    {
        private DataTable table = new DataTable("table");
        private Int64 numDoc;
        private List<DevolucaoDS> l;
        private DevolucaoModelo dmod;
        private List<DevolucaoModelo> ldmod = new List<DevolucaoModelo>();
        private DataGridViewRow row;
        Conexao con = new Conexao(DadosConexao.stringConexao);
        private DevolucaoCLN ent;
        private Int64 index;
        //VARIAVEL GLOBAL PARA RECEBER DADOS VINDA DO FORMULARIO LOGIN
        public UtilizadorModelo util;
        public DevolucaoCIU()
        {
            InitializeComponent();
           
        }
        public DevolucaoCIU(UtilizadorModelo uP)
        {
            InitializeComponent();
            util = uP;
            lbNomedoOperadorDC.Text = "Utilizador: " + util.NomeUtilizador + "  Cargo: " + util.Cargo;
        }
        public void AlinhaConteudoCabecalho()
        {
            //padding(int left, int top, int right, int bottom)
            //dadosFC.Columns[2].HeaderCell.Style.Padding = new Padding(-1,0,0,0);
            dadosDC.Columns[0].Width = 150;
            dadosDC.Columns[1].Width = 300;
            dadosDC.Columns[2].Width = 80;
            dadosDC.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosDC.Columns[3].Width = 105;
            dadosDC.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosDC.Columns[4].Width = 60;
            dadosDC.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosDC.Columns[5].Width = 60;
            dadosDC.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosDC.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void DevolucaoCIU_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Codigo de Barra", Type.GetType("System.String"));
            table.Columns.Add("Descrição Produto/Serviço", Type.GetType("System.String"));
            table.Columns.Add("Quantidade", Type.GetType("System.Int64"));
            table.Columns.Add("Preço Unitário", Type.GetType("System.Double"));
            table.Columns.Add("%Desc.", Type.GetType("System.Double"));
            table.Columns.Add("%Imp.", Type.GetType("System.Double"));
            table.Columns.Add("Valor", Type.GetType("System.Double"));

            dadosDC.DataSource = table;
            AlinhaConteudoCabecalho();
            //--------------CONTADOR DE REGISTROS------------------------
            ent = new DevolucaoCLN(con);
            txtDocumentoDC.Text = ent.getNumDocs().ToString().Trim();
            //--------------DADOS DO UTILIZADOR--------------------------
            lbNomedoOperadorDC.Text = "Utilizador: " + util.NomeUtilizador + "  Cargo: " + util.Cargo;
        }

        public void AlinhaConteudoColuna()
        {
            dadosDC.Columns[0].Width = 150;
            dadosDC.Columns[1].Width = 300;
            dadosDC.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosDC.Columns[2].Width = 80;
            dadosDC.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosDC.Columns[3].Width = 105;
            dadosDC.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosDC.Columns[4].Width = 60;
            dadosDC.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosDC.Columns[5].Width = 60;
            dadosDC.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        public void ReadOnlyCell()
        {
            //-------Mantém as células da dategridview nestas posições somente de leituras--
            row.Cells[0].ReadOnly = true;
            row.Cells[1].ReadOnly = true;
            row.Cells[2].ReadOnly = true;
            row.Cells[3].ReadOnly = true;
            row.Cells[4].ReadOnly = true;
            row.Cells[5].ReadOnly = true;
            row.Cells[6].ReadOnly = true;
            row.Cells[7].ReadOnly = true;
            row.Cells[8].ReadOnly = true;
            row.Cells[9].ReadOnly = true;
            row.Cells[10].ReadOnly = true;
            row.Cells[11].ReadOnly = true;
            row.Cells[12].ReadOnly = true;
            row.Cells[13].ReadOnly = true;


        }
        //----TOTAL GERAL FAZ O SOMÁTORIO DA COLUNA "Valor" 

        public void TotalGeral()
        {
            txtTotalDC.Text = dadosDC.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["valorTotal"].Value)).ToString("N2");
        }
        public string ValorGeral()
        {
            return dadosDC.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Valor"].Value)).ToString("N2");
        }
        private void configDataGriedView()
        {
            dadosDC.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dadosDC.RowHeadersWidth = 80;
            dadosDC.Columns["codiBarra"].HeaderText = "Codigo de Barra";
            dadosDC.Columns["codiBarra"].Visible = true;
            dadosDC.Columns["nomeProduto"].HeaderText = "Descrição Produto/Serviço";
            dadosDC.Columns["nomeProduto"].Visible = true;
            dadosDC.Columns["qtdItemVenda"].HeaderText = "Quantidade";
            dadosDC.Columns["qtdItemVenda"].Visible = true;
            dadosDC.Columns["ValorItemVenda"].HeaderText = "Preço Unitário";
            dadosDC.Columns["ValorItemVenda"].Visible = true;
            dadosDC.Columns["descontoVenda"].HeaderText = "%Desc.";
            dadosDC.Columns["descontoVenda"].Visible = true;
            dadosDC.Columns["percTaxaImposto"].HeaderText = "%Imp.";
            dadosDC.Columns["percTaxaImposto"].Visible = true;
            dadosDC.Columns["valorTotal"].HeaderText = "Valor";
            dadosDC.Columns["valorTotal"].Visible = true;
            dadosDC.Columns["nDoc"].HeaderText = "NDOC";
            dadosDC.Columns["nDoc"].Visible = false;
            dadosDC.Columns["nomeCliente"].HeaderText = "Nome Cliente";
            dadosDC.Columns["nomeCliente"].Visible = false;
            dadosDC.Columns["nifCliente"].HeaderText = "NIF Cliente";
            dadosDC.Columns["nifCliente"].Visible = false;
            dadosDC.Columns["devfatnDoc"].HeaderText = "devfatnDoc";
            dadosDC.Columns["devfatnDoc"].Visible = false;
            dadosDC.Columns["formaPag"].HeaderText = "formaPag";
            dadosDC.Columns["formaPag"].Visible = false;
            dadosDC.Columns["dataDevolucao"].HeaderText = "dataDevolucao";
            dadosDC.Columns["dataDevolucao"].Visible = false;
            dadosDC.Columns["idProd"].HeaderText = "id";
            dadosDC.Columns["idProd"].Visible = false;
            dadosDC.Columns["idItemVenda"].HeaderText = "idItemVenda";
            dadosDC.Columns["idItemVenda"].Visible = false;
            AlinhaConteudoCabecalho();
            AlinhaConteudoColuna();
            //ReadOnlyCell();
        }
        private void txtNumFacturaDC_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))//if (e.KeyChar == 13)
            {
                //DevolucaoCLN d = new DevolucaoCLN(con);
                 
                try
                {
                     numDoc = Convert.ToInt64(txtNumFacturaDC.Text);
                    // Rever Depois caso que o número inserido da fatura não existe e se for colocado string
                    if (numDoc > 0)
                    {
                        l = ent.GetDevolucaoCliente(numDoc);
                        for (int i = 0; i < l.Count(); i++)
                        {
                            l.ElementAt(i).ValorTotal = l.ElementAt(i).ValorItemVenda * l.ElementAt(i).QtdItemVenda;
                            dmod = new DevolucaoModelo();
                            dmod.DataDevolucao = dtDevolucaoDC.Text;
                            dmod.IdProd = l.ElementAt(i).IdProd;
                            dmod.IdUtiliz = 2;
                            dmod.QtdDevolucao = l.ElementAt(i).QtdItemVenda;
                            dmod.ValorUnitario = l.ElementAt(i).ValorItemVenda;
                            dmod.NDoc = Convert.ToInt64(txtDocumentoDC.Text); 
                            dmod.DevfatnDoc = numDoc;
                            ldmod.Add(dmod);
                        }
                        dadosDC.DataSource = l;
                        configDataGriedView();
                        txtDescricDC.Text = l.ElementAt(0).NomeCliente;
                        txtNifClienteDC.Text = l.ElementAt(0).NifCliente;
                        TotalGeral();
                        txtNumFacturaDC.Text = "";
                        btnSalvarDC.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Número da Factura Inexistente!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Número Inexistente ou Formato da Fatura Invalida!");
                    txtNumFacturaDC.Text = "";
                    txtNumFacturaDC.Focus();
                }
                
               
            }
        }// FIM MÉTODO
        public void Limpar()
        {
            txtCodigoProdutoDC.Text = "";
            txtDescricaoProdDC.Text = "";
            txtQuantidadeDC.Text = "";
            txtPrecoDC.Text = "";
            txtCodClienteDC.Text = "";
            txtEstoqueMinDC.Text = "";
            txtExistenciaDC.Text = "";
            txtTotalDC.Text = "";
            table.Clear();
            l.Clear();
            ldmod.Clear();
            txtNumFacturaDC.Focus();
        }
        private void dadosDC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                /*DataGridViewRow*/
                row = dadosDC.Rows[(int)index];
            }
            catch (Exception)
            {
                MessageBox.Show("Dados Invalido no clique da Tabela de Lançamento!");
            }
           
        }

        private void btnSalvarDC_Click(object sender, EventArgs e)
        {
            try
            {
                    for (int i = 0; i < l.Count(); i++)
                    {
                        ent.Add(ldmod.ElementAt(i));
                        ent.ExcluirVendaCLN(l.ElementAt(i).IdItemVenda, numDoc);
                        ent.ExcluirItemCLN(l.ElementAt(i).IdItemVenda);
                    }
                    //========DADOS NECESSÁRIOS PARA PREENCHER O RELATÓRIO=========
                    List<DevolucaoDS> lst = new List<DevolucaoDS>();
                    lst.Clear();
                    for (int i = 0; i < dadosDC.Rows.Count; i++)
                    {
                        DevolucaoDS en = new DevolucaoDS()
                        {
                            CodiBarra = dadosDC.Rows[i].Cells[0].Value.ToString(),
                            NomeProduto = dadosDC.Rows[i].Cells[1].Value.ToString(),
                            QtdItemVenda = Convert.ToInt32(dadosDC.Rows[i].Cells[2].Value.ToString()),
                            ValorItemVenda = Convert.ToDouble(dadosDC.Rows[i].Cells[3].Value.ToString()),
                            DescontoVenda = Convert.ToDouble(dadosDC.Rows[i].Cells[4].Value.ToString()),
                            PercTaxaImposto = Convert.ToDouble(dadosDC.Rows[i].Cells[5].Value.ToString()),
                            ValorTotal = Convert.ToDouble(dadosDC.Rows[i].Cells[6].Value.ToString()),
                            NomeCliente = txtDescricDC.Text,
                            //NomeUtilizador = "Teste",//util.NomeUtilizador, //lbNomedoOperadorFC.Text
                            NDoc = Convert.ToInt64(txtDocumentoDC.Text),
                            NifCliente = txtNifClienteDC.Text
                        };
                        lst.Add(en);
                    }
                    new RelDevolucaoCIU(lst,lbNomedoOperadorDC.Text).ShowDialog();     
                    //======== FIM DADOS NECESSÁRIOS PARA PREENCHER O RELATÓRIO=========
                    txtDocumentoDC.Text = ent.getNumDocs().ToString();
                    Limpar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
