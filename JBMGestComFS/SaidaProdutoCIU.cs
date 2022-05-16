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

    public partial class SaidaProdutoCIU : Form
    {
        //----DE DECLARAÇÃO DE VARIAVEIS PARA MANIPULAÇÃO DO DATAGRIDVIEW
        private DataTable table = new DataTable("table");
        private DataGridViewRow row;
        private int index;
        //----DECLARAÇÃO DE VARIAVEIS PARA MANIPULAÇÃO DAS LISTAS
        private List<Int64> itemQtd = new List<Int64>();
        private List<SaidaProdutoModelo> itemEnt = new List<SaidaProdutoModelo>();
        private List<ProdutoModelo> itemProd = new List<ProdutoModelo>();
        public List<ProdutoModelo> lp = new List<ProdutoModelo>();
        //----DECLARAÇÃO DE VARIAVEIS DE MANIPULAÇÃO DO BANCO DE DADOS
        private SaidaProdutoCLN ent;
        private SaidaProdutoModelo entMod;
        private ProdutoModelo cat, prod = new ProdutoModelo();
        private Conexao con = new Conexao(DadosConexao.stringConexao);
        private ProdutoCLN catcln;
        //----DECLARAÇÃO DE VARIAVEIS DE MANIPULAÇÃO DIVERSAS;
        private bool res;
        private Double subtotalValor;
        //VARIAVEL GLOBAL PARA RECEBER DADOS VINDA DO FORMULARIO LOGIN
        public UtilizadorModelo util;
        //----DEFINIÇÃO DOS CONSTRUTORES DE CLASSES--------------------------------------------
       
        public SaidaProdutoCIU(string codigoBarra)
        {
            InitializeComponent();
            txtCodigoProdutoSD.Text = codigoBarra;
        }
        public SaidaProdutoCIU()
        {
            InitializeComponent();
        }
        public SaidaProdutoCIU(UtilizadorModelo uP)
        {
            InitializeComponent();
            util = uP;
        }
        //----DEFINIÇÃO DOS MÉTODOS AUXILIARES------------------------------------------
        private List<Int64> ListaQtd()
        {
            foreach (DataGridViewRow dataGridViewRow in dadosSaida.Rows)
            {
                itemQtd.Add(Convert.ToInt64(dataGridViewRow.Cells["Quantidade"].Value));
            }
            return itemQtd;
        }
        private List<SaidaProdutoModelo> ListaEnt()
        {
            for (int i = 0; i < dadosSaida.RowCount; i++)
            {
                DataGridViewRow row = dadosSaida.Rows[i];
                entMod = new SaidaProdutoModelo();
                entMod.IdProd = itemProd.ElementAt(i).Id;
                entMod.IdUtiliz = 2;//util.Id;
                entMod.QtdSaida = Convert.ToInt64(row.Cells["Quantidade"].Value);
                entMod.ValorUnitario = Convert.ToDouble(row.Cells["Preço Unitário"].Value);
                entMod.DataSaida = dtEntradaSD.Text;
                entMod.NDocs = Convert.ToInt64(txtDocumentoSD.Text);
                itemEnt.Add(entMod);
            }
            return itemEnt;
        }
        public void Limpar()
        {
            txtCodigoProdutoSD.Text = "";
            txtDescricaoProdSD.Text = "";
            txtQuantidadeSD.Text = "";
            txtPrecoSD.Text = "";
            txtValoresSD.Text = "";
            txtEstoqueMinSD.Text = "";
            txtExistenciaSD.Text = "";
            txtTotalSD.Text = "";
            table.Clear();
            lp.Clear();
            itemEnt.Clear();
            itemQtd.Clear();
            itemProd.Clear();
            txtCodigoProdutoSD.Focus();
        }
        private void btnSalvarSD_Click(object sender, EventArgs e)
        {
            List<Int64> l = ListaQtd();
            try
            {
                ent = new SaidaProdutoCLN(con);
                List<SaidaProdutoModelo> et = ListaEnt();
                for (int i = 0; i < l.Count(); i++)
                {
                    res = ent.Add(et.ElementAt(i));
                }
                if (res == false)
                {
                    MessageBox.Show("Erro na inserção de dado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //========DADOS NECESSÁRIOS PARA PREENCHER O RELATÓRIO=========
                    string vgeral = ValorGeral();
                    List<SaidaDS> lst = new List<SaidaDS>();
                    lst.Clear();
                    for (int i = 0; i < dadosSaida.Rows.Count; i++)
                    {
                        SaidaDS en = new SaidaDS()
                        {
                            CodiBarra = dadosSaida.Rows[i].Cells[0].Value.ToString(),
                            NomeProduto = dadosSaida.Rows[i].Cells[1].Value.ToString(),
                            QtdSaida = Convert.ToInt32(dadosSaida.Rows[i].Cells[2].Value.ToString()),
                            ValorUnitario = Convert.ToDouble(dadosSaida.Rows[i].Cells[3].Value.ToString()),
                            ValorTotal = Convert.ToDouble(dadosSaida.Rows[i].Cells[4].Value.ToString()),
                            ValorGeral = vgeral,
                            NumDocs = Convert.ToInt64(txtDocumentoSD.Text)
                        };
                        lst.Add(en);
                    }
                    RelSaidaCIU rel = new RelSaidaCIU(lst);
                    rel.ShowDialog();
                }
                //======== FIM DADOS NECESSÁRIOS PARA PREENCHER O RELATÓRIO=========
                txtDocumentoSD.Text = ent.getNumDocs().ToString();
                Limpar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        //---------------------------------------------------------------------------------------------
        private void SaidaProdutoCIU_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Codigo de Barra", Type.GetType("System.String"));
            table.Columns.Add("Descrição Produto/Serviço", Type.GetType("System.String"));
            table.Columns.Add("Quantidade", Type.GetType("System.Int64"));
            table.Columns.Add("Preço Unitário", Type.GetType("System.Double"));
            table.Columns.Add("Valor", Type.GetType("System.Decimal"));
            dadosSaida.DataSource = table;
            //--------------CONTADOR DE REGISTROS------------------------
            ent = new SaidaProdutoCLN(con);
            txtDocumentoSD.Text = ent.getNumDocs().ToString().Trim();
            lbNomedoOperadorSD.Text = "Utilizador: " + util.NomeUtilizador + "  Cargo: " + util.Cargo;
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
                        dadosSaida.DataSource = null;
                        dadosSaida.DataSource = table;
                        flat = true;
                    }
                }
            }
            catch (NullReferenceException a)
            {
                 MessageBox.Show("Produto inexistente"+a.Message);
            }
            return flat;
        }
        //----TOTAL GERAL FAZ O SOMÁTORIO DA COLUNA "Valor" 
        public void TotalGeral()
        {
            txtTotalSD.Text = dadosSaida.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Valor"].Value)).ToString("N2");
        }
        public string ValorGeral()
        {
            return dadosSaida.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Valor"].Value)).ToString("N2");
        }

        private void dadosSaida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            /*DataGridViewRow*/
            row = dadosSaida.Rows[index];
            txtCodigoProdutoSD.Text = row.Cells[0].Value.ToString();
            txtDescricaoProdSD.Text = row.Cells[1].Value.ToString();
            txtQuantidadeSD.Text = row.Cells[2].Value.ToString();
            txtPrecoSD.Text = row.Cells[3].Value.ToString();
            txtValoresSD.Text = row.Cells[4].Value.ToString();
            ReadOnlyCell();
            //------------------Propriedade da Caixa de Dialogo-------------------------------------------------------------
            string msg = "Tem Certeza que Pretendes Substituir ou Actualizar o\n" + txtDescricaoProdSD.Text + " Na Linha " + (index + 1) + " ?";
            string caption = "Aviso";
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult rs;

            rs = MessageBox.Show(msg, caption, btn, icon);
            if (rs == DialogResult.Yes)
            {
                dadosSaida.Rows.RemoveAt(index);
                itemProd.RemoveAt(index);
                lp.RemoveAt(index);
            }
            TotalGeral();
            txtCodigoProdutoSD.Focus();
        }

        private void btnExcluirLinhaSD_Click(object sender, EventArgs e)
        {
            if (dadosSaida.CurrentRow == null)
            {
                MessageBox.Show("Erro ao eliminar produto, tabela vazia!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoProdutoSD.Focus();
            }
            else
            {
                index = dadosSaida.CurrentCell.RowIndex;
                dadosSaida.Rows.RemoveAt(index);
                itemProd.RemoveAt(index);
                lp.RemoveAt(index);
                TotalGeral();
                txtCodigoProdutoSD.Focus();
            }
        }
        private void txtCodigoProdutoSD_KeyDown(object sender, KeyEventArgs e)
        {
            catcln = new ProdutoCLN(con);
            cat = catcln.getProdutoCLN(txtCodigoProdutoSD.Text);


            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))//if (e.KeyChar == 13)
            {
                txtCodigoProdutoSD.Text = cat.CodiBarra;
                txtDescricaoProdSD.Text = cat.NomeProduto;
                txtPrecoSD.Text = Convert.ToString(cat.PrecoVenda);
                txtExistenciaSD.Text = Convert.ToString(getQtdAtualProd(cat.Id));
                txtEstoqueMinSD.Text = cat.StockMin.ToString().Trim();
                SendKeys.Send("{TAB}");
                if (cat.ToString().Contains(txtCodigoProdutoSD.Text))
                {
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

        private void btnPesquisaSD_Click(object sender, EventArgs e)
        {
            PesquisaCIU p = new PesquisaCIU(new EntradaProdutoCIU(),this,new VendaCIU());
            p.ShowDialog();
        }

        private void txtQuantidadeSD_KeyDown(object sender, KeyEventArgs e)
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
                    if (Int64.Parse(txtQuantidadeSD.Text) <= 0 || string.IsNullOrEmpty(txtQuantidadeSD.Text))
                    {
                        MessageBox.Show("Quantidade Zero ou Inferior do que Zero", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQuantidadeSD.Clear();
                    }
                    else
                    {
                        if (!AgregarProd(prod))
                        {
                            MessageBox.Show("O Produto " + cat.NomeProduto + " já foi adicionada na tabela", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCodigoProdutoSD.Focus();
                        }
                        else
                        {
                            itemProd.Add(prod);
                            subtotalValor = Int64.Parse(txtQuantidadeSD.Text) * prod.PrecoVenda;
                            txtValoresSD.Text = subtotalValor.ToString();
                            table.Rows.Add(prod.CodiBarra, prod.NomeProduto, Int64.Parse(txtQuantidadeSD.Text), prod.PrecoVenda, txtValoresSD.Text);
                            txtQuantidadeSD.Text = "";
                            txtCodigoProdutoSD.Focus();
                        }
                        //limpar();
                    }
                }
                catch (FormatException a)
                {
                    MessageBox.Show("Quantidade do Produto Inválido" + "\n" + a.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantidadeSD.Clear();
                    txtQuantidadeSD.Focus();

                }
                TotalGeral();
            }
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

    }
}
