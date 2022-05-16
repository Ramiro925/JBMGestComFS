using CAL;
using CLN;
using MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace JBMGestComFS
{
    public partial class EntradaProdutoCIU : Form
    {
        //----DE DECLARAÇÃO DE VARIAVEIS PARA MANIPULAÇÃO DO DATAGRIDVIEW
        private DataTable table = new DataTable("table");
        private DataGridViewRow row;
        private int index;
        //----DECLARAÇÃO DE VARIAVEIS PARA MANIPULAÇÃO DAS LISTAS
        private List<Int64> itemQtd = new List<Int64>();
        private List<EntradaProdutoModelo> itemEnt = new List<EntradaProdutoModelo>();
        private List<ProdutoModelo> itemProd = new List<ProdutoModelo>();
        public List<ProdutoModelo> lp = new List<ProdutoModelo>();
        //----DECLARAÇÃO DE VARIAVEIS DE MANIPULAÇÃO DO BANCO DE DADOS
        private EntradaProdutoCLN ent;
        private EntradaProdutoModelo entMod;
        private ProdutoModelo cat, prod=new ProdutoModelo();
        private Conexao con = new Conexao(DadosConexao.stringConexao);
        private ProdutoCLN catcln;
        //----DECLARAÇÃO DE VARIAVEIS DE MANIPULAÇÃO DIVERSAS;
        private bool res;
        private Double subtotalValor;
        //----DECLARAÇÃO DE VARIAVEIS PARTILHADAS PARA RECEBER DADOS VINDA DO FORMULARIO LOGIN.
        public UtilizadorModelo util;
        //----DEFINIÇÃO DOS CONSTRUTORES DE CLASSES--------------------------------------------
        public EntradaProdutoCIU()
        {
            InitializeComponent();
        }
        public EntradaProdutoCIU(UtilizadorModelo uP)
        {
            InitializeComponent();
            util = uP;
        }
        public EntradaProdutoCIU(string codigoBarra)
        {
            InitializeComponent();
            txtCodigoProdutoET.Text = codigoBarra;
        }
        //----DEFINIÇÃO DOS MÉTODOS AUXILIARES------------------------------------------
        private List<Int64> ListaQtd()
        {
            foreach (DataGridViewRow dataGridViewRow in dadosVendaET.Rows)
            {
                itemQtd.Add(Convert.ToInt64(dataGridViewRow.Cells["Quantidade"].Value));
            }
            return itemQtd;
        }
        private List<EntradaProdutoModelo> ListaEnt()
        {
            for (int i = 0; i < dadosVendaET.RowCount; i++)
            {
                DataGridViewRow row = dadosVendaET.Rows[i];
                entMod = new EntradaProdutoModelo();
                entMod.IdProd = itemProd.ElementAt(i).Id;
                entMod.IdUtiliz = 2;//util.Id;
                entMod.QtdEntrada = Convert.ToInt64(row.Cells["Quantidade"].Value);
                entMod.ValorUnitario = Convert.ToDouble(row.Cells["Preço Unitário"].Value);
                entMod.DataEntrada = dtEntradaET.Text;
                entMod.NDocs = Convert.ToInt64(txtDocumentoET.Text);
                itemEnt.Add(entMod);
            }
            return itemEnt;
        }
        private void btnSalvarET_Click(object sender, EventArgs e)
        {
            List<Int64> l = ListaQtd();
            try
            {
                ent = new EntradaProdutoCLN(con);
                List<EntradaProdutoModelo> et = ListaEnt();
                for (int i = 0; i < l.Count(); i++)
                {
                    res = ent.add(et.ElementAt(i));
                }
                if (res == false)
                {
                    MessageBox.Show("Erro na inserção de dado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoProdutoET.Focus();
                }
                else
                {
                    //========DADOS NECESSÁRIOS PARA PREENCHER O RELATÓRIO=========
                    string vgeral = ValorGeral();
                    List<EntradaDS> lst = new List<EntradaDS>();
                    lst.Clear();
                    for (int i = 0; i < dadosVendaET.Rows.Count; i++)
                    {
                        EntradaDS en = new EntradaDS()
                        {
                            CodiBarra = dadosVendaET.Rows[i].Cells[0].Value.ToString(),
                            NomeProduto = dadosVendaET.Rows[i].Cells[1].Value.ToString(),
                            QtdEntrada = Convert.ToInt32(dadosVendaET.Rows[i].Cells[2].Value.ToString()),
                            ValorUnitario = Convert.ToDouble(dadosVendaET.Rows[i].Cells[3].Value.ToString()),
                            ValorTotal = Convert.ToDouble(dadosVendaET.Rows[i].Cells[4].Value.ToString()),
                            ValorGeral = vgeral,
                            NumDocs = Convert.ToInt64(txtDocumentoET.Text)
                        };
                        lst.Add(en);
                    }
                    RelEntradaCIU rel = new RelEntradaCIU(lst);
                    rel.ShowDialog();
                }
                //======== FIM DADOS NECESSÁRIOS PARA PREENCHER O RELATÓRIO=========
                txtDocumentoET.Text = ent.getNumDocs().ToString();
                Limpar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        public void Limpar()
        {
            txtCodigoProdutoET.Text = "";
            txtDescricaoProdET.Text = "";
            txtQuantidadeET.Text = "";
            txtPrecoET.Text = "";
            txtValoresET.Text = "";
            txtEstoqueMinET.Text = "";
            txtExistenciaET.Text = "";
            txtTotalET.Text = "";
            table.Clear();
            lp.Clear();
            itemEnt.Clear();
            itemQtd.Clear();
            itemProd.Clear();
            txtCodigoProdutoET.Focus();
        }
        private void EntradaProdutoCIU_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Codigo de Barra", Type.GetType("System.String"));
            table.Columns.Add("Descrição Produto/Serviço", Type.GetType("System.String"));
            table.Columns.Add("Quantidade", Type.GetType("System.Int64"));
            table.Columns.Add("Preço Unitário", Type.GetType("System.Double"));
            table.Columns.Add("Valor", Type.GetType("System.Decimal"));
            dadosVendaET.DataSource = table;
            //--------------CONTADOR DE REGISTROS------------------------
            ent = new EntradaProdutoCLN(con);
            txtDocumentoET.Text = ent.getNumDocs().ToString().Trim();
            lbNomedoOperadorET.Text = "Utilizador: " + util.NomeUtilizador + "  Cargo: " + util.Cargo;
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
                        dadosVendaET.DataSource = null;
                        dadosVendaET.DataSource = table;
                        flat = true;
                    }
            }
            }
            catch (NullReferenceException a) {
                MessageBox.Show("Produto inexistente"+a.Message);
            }
            return flat;
        }
        //----TOTAL GERAL FAZ O SOMÁTORIO DA COLUNA "Valor" 
        public void TotalGeral()
        {
            txtTotalET.Text = dadosVendaET.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Valor"].Value)).ToString("N2");
        }
        public string ValorGeral()
        {
            return dadosVendaET.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Valor"].Value)).ToString("N2");
        }
        public void ReadOnlyCell() 
        {
            //-------Mantém as células da dategridview nestas posições somente de leituras--
            row.Cells[0].ReadOnly = true;
            row.Cells[1].ReadOnly = true;
            row.Cells[2].ReadOnly = true;
            row.Cells[3].ReadOnly = true;
            row.Cells[4].ReadOnly = true;
        }
        private void dadosVendaET_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            /*DataGridViewRow*/ row = dadosVendaET.Rows[index];
            txtCodigoProdutoET.Text = row.Cells[0].Value.ToString();
            txtDescricaoProdET.Text = row.Cells[1].Value.ToString();
            txtQuantidadeET.Text = row.Cells[2].Value.ToString();
            txtPrecoET.Text = row.Cells[3].Value.ToString();
            txtValoresET.Text = row.Cells[4].Value.ToString();
            ReadOnlyCell();
            //------------------Propriedade da Caixa de Dialogo-------------------------------------------------------------
            string msg = "Tem Certeza que Pretendes Substituir ou Actualizar o\n" + txtDescricaoProdET.Text + " Na Linha " + (index + 1) + " ?";
            string caption = "Aviso";
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult rs;
            
            rs = MessageBox.Show(msg,caption,btn,icon);
            if (rs==DialogResult.Yes) {
                dadosVendaET.Rows.RemoveAt(index);
                itemProd.RemoveAt(index);
                lp.RemoveAt(index);
            }
            TotalGeral();
            txtCodigoProdutoET.Focus();
        }

        private void btnExcluirLinhaET_Click(object sender, EventArgs e)
        {
            if (dadosVendaET.CurrentRow == null)
            {
                MessageBox.Show("Erro ao eliminar produto, tabela vazia!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoProdutoET.Focus();
            }
            else
            {
                index = dadosVendaET.CurrentCell.RowIndex;
                dadosVendaET.Rows.RemoveAt(index);
                itemProd.RemoveAt(index);
                lp.RemoveAt(index);
                TotalGeral();
                txtCodigoProdutoET.Focus();
            }
        }
        private void txtCodigoProdutoET_KeyPress(object sender, KeyEventArgs e /*KeyPressEventArgs e*/)
        {
            catcln = new ProdutoCLN(con);
            cat = catcln.getProdutoCLN(txtCodigoProdutoET.Text);

           
            if((e.KeyCode==Keys.Enter)|| (e.KeyCode == Keys.Return))//if (e.KeyChar == 13)
            {
                txtCodigoProdutoET.Text = cat.CodiBarra;
                txtDescricaoProdET.Text = cat.NomeProduto;
                txtPrecoET.Text = Convert.ToString(cat.PrecoVenda);
                txtExistenciaET.Text = Convert.ToString(getQtdAtualProd(cat.Id));
                txtEstoqueMinET.Text = cat.StockMin.ToString().Trim();
                SendKeys.Send("{TAB}");
                if (cat.ToString().Contains(txtCodigoProdutoET.Text)) {
                    MessageBox.Show("Produto Inexistente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private Int64 getQtdAtualProd(Int64 idProd)
        {
            StockCLN s = new StockCLN(con);
            StockModelo smod = s.getQtdCLN(idProd);
            return smod.QtdStock;
        }
        private void btnPesquisaProd_Click(object sender, EventArgs e)
        {
            PesquisaCIU pq = new PesquisaCIU(this,new SaidaProdutoCIU(),new VendaCIU());
            pq.ShowDialog();
        }
        private void txtQuantidadeET_KeyPress(object sender, KeyEventArgs e)
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
                    if (Int64.Parse(txtQuantidadeET.Text) <= 0|| string.IsNullOrEmpty(txtQuantidadeET.Text))
                    {
                        MessageBox.Show("Quantidade Zero ou Inferior do que Zero", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQuantidadeET.Clear();
                    }
                    else
                    {
                        if (!AgregarProd(prod))
                        {  
                            MessageBox.Show("O Produto " + cat.NomeProduto + " já foi adicionada na tabela","ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCodigoProdutoET.Focus();
                        }
                        else
                        {
                            itemProd.Add(prod);
                            subtotalValor = Int64.Parse(txtQuantidadeET.Text) * prod.PrecoVenda;
                            txtValoresET.Text = subtotalValor.ToString();
                            table.Rows.Add(prod.CodiBarra, prod.NomeProduto, Int64.Parse(txtQuantidadeET.Text), prod.PrecoVenda, txtValoresET.Text);
                            txtQuantidadeET.Text = "";
                            txtCodigoProdutoET.Focus();
                        }
                                    //limpar();
                    }
                    }
                        catch (FormatException a)
                {
                    MessageBox.Show("Quantidade do Produto Inválido"+"\n"+a.Message, "ERRO", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtQuantidadeET.Clear();
                    txtQuantidadeET.Focus();
                }
                TotalGeral();
            }
        }
    }
}
    

