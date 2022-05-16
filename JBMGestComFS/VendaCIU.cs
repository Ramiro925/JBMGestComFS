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
    public partial class VendaCIU : Form
    {
        //----DE DECLARAÇÃO DE VARIAVEIS PARA MANIPULAÇÃO DO DATAGRIDVIEW
        private DataTable table = new DataTable("table");
        private DataGridViewRow row;
        private int index;
        //----DECLARAÇÃO DE VARIAVEIS PARA MANIPULAÇÃO DAS LISTAS
        private List<Int64> itemQtd = new List<Int64>();
        private List<VendaModelo> itemEnt = new List<VendaModelo>();
        private List<ProdutoModelo> itemProd = new List<ProdutoModelo>();
        public List<ProdutoModelo> lp = new List<ProdutoModelo>();
        private List<ItemVendaModelo> itemVenda = new List<ItemVendaModelo>();
        //----DECLARAÇÃO DE VARIAVEIS DE MANIPULAÇÃO DO BANCO DE DADOS
        private VendaCLN ent;
        //private VendaCAL entCal;
        private ItemVendaCLN itemCLN;
        private VendaModelo entMod;
        private ItemVendaModelo itemMod;
        private ProdutoModelo cat, prod = new ProdutoModelo();
        private Conexao con = new Conexao(DadosConexao.stringConexao);
        private ProdutoCLN catcln;
        //----DECLARAÇÃO DE VARIAVEIS DE MANIPULAÇÃO DIVERSAS;
        private bool resItemVend;
        private Int64 idVenda;
        private Double subtotalValor;
        //VARIAVEL GLOBAL PARA RECEBER DADOS VINDA DO FORMULARIO LOGIN
        public UtilizadorModelo util;

        //----DEFINIÇÃO DOS CONSTRUTORES DE CLASSES--------------------------------------------

        public VendaCIU()
        {
            InitializeComponent();

        }
        public VendaCIU(UtilizadorModelo uP)
        {
            InitializeComponent();
            util = uP;
            
            lbNomedoOperadorFC.Text = "Utilizador: " + util.NomeUtilizador + "  Cargo: " + util.Cargo;
        }
        //----DEFINIÇÃO DOS MÉTODOS AUXILIARES------------------------------------------
        private List<Int64> ListaQtd()
        {
            foreach (DataGridViewRow dataGridViewRow in dadosFC.Rows)
            {
                itemQtd.Add(Convert.ToInt64(dataGridViewRow.Cells["Quantidade"].Value));
            }
            return itemQtd;
        }
        private List<ItemVendaModelo> ListaItemVenda()
        {
            for (int i = 0; i < dadosFC.RowCount; i++)
            {
                DataGridViewRow row = dadosFC.Rows[i];
                itemMod = new ItemVendaModelo();
                itemMod.IdProd = itemProd.ElementAt(i).Id;
                itemMod.QtdItemVenda = Convert.ToInt64(row.Cells["Quantidade"].Value);
                itemMod.ValorItemVenda = Convert.ToDouble(row.Cells["Preço Unitário"].Value);
                itemVenda.Add(itemMod);
            }
            return itemVenda;
        } 
        private List<VendaModelo> ListaEnt()
        {
            for (int i = 0; i < dadosFC.RowCount; i++)
            {
                DataGridViewRow row = dadosFC.Rows[i];
                entMod = new VendaModelo();
                entMod.IdUtiliz = util.Id;
                entMod.NomeCliente = txtDescricFC.Text.ToUpper();
                entMod.ValorPrecoVendido = Convert.ToDouble(row.Cells["Preço Unitário"].Value);
                entMod.DataVenda = dtEntradaFC.Text;
                entMod.NDocs = Convert.ToInt64(txtDocumentoFC.Text);
                itemEnt.Add(entMod);
            }
            return itemEnt;
        }
        public void Limpar()
        {
            txtCodigoProdutoFC.Text = "";
            txtDescricaoProdFC.Text = "";
            txtQuantidadeFC.Text = "";
            txtPrecoFC.Text = "";
            txtCodClienteFC.Text = "";
            txtEstoqueMinFC.Text = "";
            txtExistenciaFC.Text = "";
            txtTotalFC.Text = "";
            table.Clear();
            lp.Clear();
            itemEnt.Clear();
            itemQtd.Clear();
            itemProd.Clear();
            txtCodigoProdutoFC.Focus();
        }
        public bool AgregarProd(ProdutoModelo mod)
        {
            bool flat = false;
            try
            {
                if (string.IsNullOrEmpty(mod.CodiBarra)/*== null*/)
                {
                    //MessageBox.Show("Produto inexistente1");
                }
                else
                {
                    bool exist = lp.Any(x => x.CodiBarra.Equals(mod.CodiBarra));
                    if (!exist)
                    {
                        lp.Add(mod);
                        dadosFC.DataSource = null;
                        dadosFC.DataSource = table;
                        flat = true;
                    }
                }
            }
            catch (NullReferenceException  a)
            {
                 MessageBox.Show("Produto inexistente"+a.Message);
            }
            return flat;
        }
        //----TOTAL GERAL FAZ O SOMÁTORIO DA COLUNA "Valor" 
        public void TotalGeral()
        {
            txtTotalFC.Text = dadosFC.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Valor"].Value)).ToString("N2");
        }
        public string ValorGeral()
        {
            return dadosFC.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Valor"].Value)).ToString("N2");
        }

     
        private void BtnSalvarFC_Click(object sender, EventArgs e)
        {
            List<Int64> l = ListaQtd();
            try
            {
                ent = new VendaCLN(con);
                itemCLN = new ItemVendaCLN(con);
                List<VendaModelo> et = ListaEnt();
                List<ItemVendaModelo> item = ListaItemVenda();
                for (int i = 0; i < l.Count(); i++)
                {
                    //-----Inserir Dados da Venda na BD e retorna em cada linha o Id da Venda
                    idVenda = ent.Add(et.ElementAt(i));
                    //-----Inserir Dados do ItemVenda na BD e retorna um Bool...
                    resItemVend = itemCLN.Add(item.ElementAt(i), idVenda);
                }
                if (resItemVend == false)
                {
                    MessageBox.Show("Erro na inserção de dado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //========DADOS NECESSÁRIOS PARA PREENCHER O RELATÓRIO=========
                    string vgeral = ValorGeral();
                    List<VendaDS> lst = new List<VendaDS>();
                    lst.Clear();
                    for (int i = 0; i < dadosFC.Rows.Count; i++)
                    {
                        VendaDS en = new VendaDS()
                        {
                            CodiBarra = dadosFC.Rows[i].Cells[0].Value.ToString(),
                            NomeProduto = dadosFC.Rows[i].Cells[1].Value.ToString(),
                            QtdVenda = Convert.ToInt32(dadosFC.Rows[i].Cells[2].Value.ToString()),
                            ValorUnitario = Convert.ToDouble(dadosFC.Rows[i].Cells[3].Value.ToString()),
                            PDesconto = Convert.ToDouble(dadosFC.Rows[i].Cells[4].Value.ToString()),
                            PImposto = Convert.ToDouble(dadosFC.Rows[i].Cells[5].Value.ToString()),
                            ValorTotal = Convert.ToDouble(dadosFC.Rows[i].Cells[6].Value.ToString()),
                            ValorGeral = vgeral,
                            NomeCliente = txtDescricFC.Text,
                            NomeUtilizador = util.NomeUtilizador,
                            NumDocs = Convert.ToInt64(txtDocumentoFC.Text),
                            NifCliente = txtNifClienteFC.Text
                        };
                        lst.Add(en);
                    }
                    /*DetImprVendaCIU f =*/ new DetImprVendaCIU(vgeral, lst).ShowDialog();
                    //f.ShowDialog();
                }
                //======== FIM DADOS NECESSÁRIOS PARA PREENCHER O RELATÓRIO=========
                txtDocumentoFC.Text = ent.getNumDocs().ToString();
                Limpar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        //------Restorna um Resulta da caixa de dialogo ou de confirmação--------------------------
        public DialogResult SmgDres(string msg, string caption, MessageBoxButtons btn, MessageBoxIcon icon) {
     
            return MessageBox.Show(msg, caption, btn, icon);
        }
        private Int64 GetQtdAtualProd(Int64 idProd)
        {
            StockCLN s = new StockCLN(con);
            StockModelo smod = s.getQtdCLN(idProd);
            return smod.QtdStock;
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
        }
        public void AlinhaConteudoCabecalho() {
            //padding(int left, int top, int right, int bottom)
            //dadosFC.Columns[2].HeaderCell.Style.Padding = new Padding(-1,0,0,0);
            dadosFC.Columns[0].Width = 150;
            dadosFC.Columns[1].Width = 300;
            dadosFC.Columns[2].Width = 80;
            dadosFC.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosFC.Columns[3].Width = 105;
            dadosFC.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosFC.Columns[4].Width = 60;
            dadosFC.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosFC.Columns[5].Width = 60;
            dadosFC.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosFC.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        public void AlinhaConteudoColuna()
        {
            dadosFC.Columns[0].Width = 150;
            dadosFC.Columns[1].Width = 300;
            dadosFC.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosFC.Columns[2].Width = 80;
            dadosFC.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosFC.Columns[3].Width = 105;
            dadosFC.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosFC.Columns[4].Width = 60;
            dadosFC.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dadosFC.Columns[5].Width = 60;
            dadosFC.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void DadosFC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            /*DataGridViewRow*/
            row = dadosFC.Rows[index];
            txtCodigoProdutoFC.Text = row.Cells[0].Value.ToString();
            txtDescricaoProdFC.Text = row.Cells[1].Value.ToString();
            txtQuantidadeFC.Text = row.Cells[2].Value.ToString();
            txtPrecoFC.Text = row.Cells[3].Value.ToString();
            txtDescontoFC.Text= row.Cells[4].Value.ToString();
            txtImpostoFC.Text = row.Cells[5].Value.ToString();
            //txtCodClienteFC.Text = row.Cells[6].Value.ToString();
            ReadOnlyCell();
            //------------------Propriedade da Caixa de Dialogo-------------------------------------------------------------
            //string msg = "Tem Certeza que Pretendes Substituir ou Actualizar o\n" + txtDescricaoProdFC.Text + " Na Linha " + (index + 1) + " ?";
            //string caption = "Aviso";
            //MessageBoxButtons btn = MessageBoxButtons.YesNo;
            //MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult rs;

            rs = SmgDres("Tem Certeza que Pretendes Substituir ou Actualizar o\n" + txtDescricaoProdFC.Text + " Na Linha " + (index + 1) + " ?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                dadosFC.Rows.RemoveAt(index);
                itemProd.RemoveAt(index);
                lp.RemoveAt(index);
            }
            TotalGeral();
            txtCodigoProdutoFC.Focus();
        }

        private void BtnExcluirLinhaFC_Click(object sender, EventArgs e)
        {
            if (dadosFC.CurrentRow == null)
            {
                MessageBox.Show("Erro ao eliminar produto, tabela vazia!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoProdutoFC.Focus();
            }
            else
            {
                index = dadosFC.CurrentCell.RowIndex;
                dadosFC.Rows.RemoveAt(index);
                itemProd.RemoveAt(index);
                lp.RemoveAt(index);
                TotalGeral();
                txtCodigoProdutoFC.Focus();
            }
        }

        private void TxtCodigoProdutoFC_KeyDown(object sender, KeyEventArgs e)
        {
            catcln = new ProdutoCLN(con);
            cat = catcln.getProdutoCLN(txtCodigoProdutoFC.Text);


            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))//if (e.KeyChar == 13)
            {
                txtCodigoProdutoFC.Text = cat.CodiBarra;
                txtDescricaoProdFC.Text = cat.NomeProduto;
                txtPrecoFC.Text = Convert.ToString(cat.PrecoVenda);
                txtExistenciaFC.Text = Convert.ToString(GetQtdAtualProd(cat.Id));
                txtEstoqueMinFC.Text = cat.StockMin.ToString().Trim();
                SendKeys.Send("{TAB}");
                if (cat.ToString().Contains(txtCodigoProdutoFC.Text))
                {
                    MessageBox.Show("Produto Inexistente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnPesquisaFC_Click(object sender, EventArgs e)
        {
            PesquisaCIU p = new PesquisaCIU(new EntradaProdutoCIU(),new SaidaProdutoCIU(),this);
            p.ShowDialog();
        }

        private void TxtQuantidadeFC_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                prod = new ProdutoModelo()
                {
                    Id = cat.Id,
                    CodiBarra = cat.CodiBarra,
                    NomeProduto = cat.NomeProduto,
                    PrecoVenda = cat.PrecoVenda,
                    DataValid = cat.DataValid,
                    IdCat = cat.IdCat
                };
                try
                {
                    if (Int64.Parse(txtQuantidadeFC.Text) <= 0 || string.IsNullOrEmpty(txtQuantidadeFC.Text))
                    {
                        MessageBox.Show("Quantidade Zero ou Inferior do que Zero", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQuantidadeFC.Clear();
                    }
                    else
                    {
                        if (!AgregarProd(prod))
                        {
                            MessageBox.Show("O Produto " + cat.NomeProduto + " já foi adicionada na tabela", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCodigoProdutoFC.Focus();
                        }
                        else
                        {
                            itemProd.Add(prod);
                            txtDescontoFC.Text = "0,00";
                            txtImpostoFC.Text = "0,00";
                            Int64 qtd = Int64.Parse(txtQuantidadeFC.Text);
                            Int64 qtdMin = Int64.Parse(txtEstoqueMinFC.Text);

                            //txtCodClienteFC.Text = subtotalValor.ToString("N2");
                            if (qtd<=GetQtdAtualProd(prod.Id)/* &&qtd < qtdMin*/)
                            {
                                subtotalValor = qtd * prod.PrecoVenda;
                                table.Rows.Add
                                (
                                prod.CodiBarra, prod.NomeProduto, 
                                Int64.Parse(txtQuantidadeFC.Text),
                                prod.PrecoVenda.ToString("N2"), 
                                Double.Parse(txtDescontoFC.Text).ToString("N2"), 
                                Double.Parse(txtImpostoFC.Text).ToString("N2"), 
                                subtotalValor.ToString("N2")
                                );
                            }
                            else
                            {
                                MessageBox.Show("Quantidade Superior do Que Limite Estoque" + "\n","ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            
                            AlinhaConteudoCabecalho();
                            AlinhaConteudoColuna();
                            txtQuantidadeFC.Text = "";
                            txtCodigoProdutoFC.Focus();
                        }
  
                    }
                }
                catch (FormatException a)
                {
                    MessageBox.Show("Quantidade do Produto Inválido" + "\n" + a.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantidadeFC.Clear();
                    txtQuantidadeFC.Focus();

                }
                TotalGeral();
            }
        }

        private void FacturacaoCIU_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Codigo de Barra", Type.GetType("System.String"));
            table.Columns.Add("Descrição Produto/Serviço", Type.GetType("System.String"));
            table.Columns.Add("Quantidade", Type.GetType("System.Int64"));
            table.Columns.Add("Preço Unitário", Type.GetType("System.Decimal"));
            table.Columns.Add("%Desc.", Type.GetType("System.Decimal"));
            table.Columns.Add("%Imp.", Type.GetType("System.Decimal"));
            table.Columns.Add("Valor", Type.GetType("System.Decimal"));
            
            dadosFC.DataSource = table;
            AlinhaConteudoCabecalho();
            //--------------CONTADOR DE REGISTROS------------------------
            ent = new VendaCLN(con);
            txtDocumentoFC.Text = ent.getNumDocs().ToString().Trim();
            //--------------DADOS DO UTILIZADOR--------------------------
            //lbNomedoOperadorFC.Text = "Utilizador: " + util.NomeUtilizador + "  Cargo: " + util.Cargo;
        }
    }
}
