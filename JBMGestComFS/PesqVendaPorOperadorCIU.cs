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
    public partial class PesqVendaPorOperadorCIU : Form
    {
        Conexao con = new Conexao(DadosConexao.stringConexao);
        ReportDataSource rs;
        RTVendaOperador cat = new RTVendaOperador();
        RTVendaOperador r;
        List<CDVendaOperador> lcd;
        List<RTVendaOperador> l = new List<RTVendaOperador>() ;
        List<CDVendaOperador> lc = new List<CDVendaOperador>();
        Double valorFatTotal = 0.0;
        //string a;
        ItemVendaCLN item,item2;
        public PesqVendaPorOperadorCIU()
        {
            InitializeComponent();
        }

        private void PesquisaVendaPorOperadorCIU_Load(object sender, EventArgs e)
        {
            cbCompletoResumo.SelectedIndex = 0;
            cbTotalDetalhe.SelectedIndex = 0;
            preencherUtilizador();
            item  = new ItemVendaCLN(con);
            //item2 = new ItemVendaCLN(con);
            // SqlNullValueException
            //RTVendaOperador r =  item.GetRTVendaOperadorCLN(1,"09-04-2022", "09-04-2022");
            List<CDVendaOperador> d = item.GetCDVendaOperadorCLN(2, "09-04-2022", "09-04-2022");
            MessageBox.Show("Test"+d.Count()+""+d.ElementAt(1).NomeProduto);

        }
        public void preencherUtilizador()
        {
            UtilizadorCLN catcln = new UtilizadorCLN(con);
            cbDeNomeOperador.DataSource = catcln.ListarComb();
            cbAteNomeOperador.DataSource = catcln.ListarComb();
            cbDeNomeOperador.SelectedIndex =cbAteNomeOperador.SelectedIndex = 0;
        }
        //-------------OBTÊM OS NOMES DOS OPERADOR DE ACORDO UM INTERVALO SELECIONADO PELO USUARIO---------------
        public List<String> GetItemTextUtil()
        {
            List<String> l = new List<String>();
            Int64 init = cbDeNomeOperador.FindString(cbDeNomeOperador.Text);
            Int64 fim = cbAteNomeOperador.FindString(cbAteNomeOperador.Text);
            try
            {
                if (init <= fim)
                {
                    for (Int64 i = init; i <= fim; i++)
                    {
                        l.Add(cbDeNomeOperador.Items[(int)i].ToString());
                    }
                }
                else {
                    MessageBox.Show("Intervalo Inválido");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Intervalo Inválido"+e.Message);
            }
            return l;
        }
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            UtilizadorCLN operador = new UtilizadorCLN(con);
            l.Clear();
            valorFatTotal = 0.0;

            
            for (int i = 0; i < GetItemTextUtil().Count(); i++)
            {
                UtilizadorModelo oper = operador.GetUtilizadorCLN(GetItemTextUtil().ElementAt(i));
                r = item.GetRTVendaOperadorCLN(oper.Id, dtDeVenda.Text, dtAteVenda.Text);

                lcd = item.GetCDVendaOperadorCLN(oper.Id, dtDeVenda.Text, dtAteVenda.Text);


                if (!(r.NDocOperador == 0 && r.TotaVendaOperador == 0))
                {
                    valorFatTotal += r.TotaVendaOperador; 
                    l.Add(r);
        
                }
                
                //MessageBox.Show("Tamanho: " + GetItemTextUtil().Count() + " " + cbDeNomeOperador.SelectedIndex + " " + r.NomeOperador + " " + r.NDocOperador + " " + r.TotaVendaOperador);
            }
            for (int j = 0; j < lcd.Count(); j++)
            {
                lc.Add(lcd.ElementAt(j));
            }
            try
            {
                if (cbCompletoResumo.Text.Equals("R") && cbTotalDetalhe.Text.Equals("T"))
                {
                    this.reportViewer4.LocalReport.DataSources.Clear();
                    this.reportViewer4.LocalReport.ReportPath = "RTVendaOperadorRel.rdlc";
                    rs = new ReportDataSource("RTVendaOperadorRelDataSet", GetRTVendaPorOperador());
                }
                else if (cbCompletoResumo.Text.Equals("C") && cbTotalDetalhe.Text.Equals("D"))
                {
                    this.reportViewer4.LocalReport.DataSources.Clear();
                    this.reportViewer4.LocalReport.ReportPath = "CDVendaOperador.rdlc";
                    rs = new ReportDataSource("CDVendaOperadorDataSet", GetCDVendaPorOperador()); 
                }
                else { 
                
                }
                this.reportViewer4.LocalReport.DataSources.Add(rs);
                this.reportViewer4.LocalReport.SetParameters(new ReportParameter("dataDe", dtDeVenda.Text));
                this.reportViewer4.LocalReport.SetParameters(new ReportParameter("dataAte",dtAteVenda.Text));
                this.reportViewer4.LocalReport.SetParameters(new ReportParameter("valorGeral", valorFatTotal.ToString("N2")));
                this.reportViewer4.SetDisplayMode(DisplayMode.PrintLayout);
                //this.reportViewer4.ZoomMode = ZoomMode.Percent;
                this.reportViewer4.RefreshReport();
            }
            catch (Exception)
            {

                MessageBox.Show("Modo de Visualização Incorreta\nOpções Disponíveis:\n1- R (Resumo) e T (Totais)\n 2- C (Completa) e D (Detalhados)");

            }

        }
        private List<RTVendaOperador> GetRTVendaPorOperador()
        {
            List<RTVendaOperador> aux = l;
            for (int i = 0; i < aux.Count; i++)
            {
                new List<RTVendaOperador>() {
                new RTVendaOperador{
                    NomeOperador =aux.ElementAt(i).NomeOperador,
                    NDocOperador=aux.ElementAt(i).NDocOperador,
                    TotaVendaOperador = aux.ElementAt(i).TotaVendaOperador
                }
            };
            }
            return aux;
        }
        private List<CDVendaOperador> GetCDVendaPorOperador()
        {
            List<CDVendaOperador> aux = lc;
            for (int i = 0; i < aux.Count; i++)
            {
                new List<CDVendaOperador>() {
                new CDVendaOperador{
                    NDoc = aux.ElementAt(i).NDoc,
                    NomeCompleto = aux.ElementAt(i).NomeCompleto,
                    NomeUtilizador = aux.ElementAt(i).NomeUtilizador,
                    NomeProduto = aux.ElementAt(i).NomeProduto,
                    CodiBarra = aux.ElementAt(i).CodiBarra,
                    QtdItemVenda = aux.ElementAt(i).QtdItemVenda,
                    ValorItemVenda = aux.ElementAt(i).ValorItemVenda,
                    NomeCliente = aux.ElementAt(i).NomeCliente,
                    DescontoVenda = aux.ElementAt(i).DescontoVenda
                }
            };
            }
            return aux;
        }
    }
}
