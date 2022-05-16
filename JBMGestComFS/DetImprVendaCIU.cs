using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using MODELO;
using System.Drawing.Imaging;

namespace JBMGestComFS
{
    public partial class DetImprVendaCIU : Form
    {
        private Int64 nDoc;
        private string valorGeral;
        private List<VendaDS> lst;
        PrintDocument pd = new PrintDocument();
        private VendaDS vDados;
        public DetImprVendaCIU()
        {
            InitializeComponent();
        }
        // List<VendaDS> lst É PREENCHIDO APARTIR DO FORMULÁRIO VENDACIU
        public DetImprVendaCIU(string valorGeral,List<VendaDS> lst)
        {
            InitializeComponent();
            this.nDoc = lst.ElementAt(0).NumDocs;
            this.valorGeral = valorGeral;
            this.lst = lst;
        }
        private void DetImprVendaCIU_Load(object sender, EventArgs e)
        {
            txtNDocs.Text = (nDoc).ToString();
            txtTotal.Text = valorGeral;
            rbImprimirDirecto.Checked = true;
            cbTipoPapel.SelectedIndex = 0;
            CarregarImpressora();
        }
        public void CarregarImpressora()
        {
            cbSelecImpressora.Items.Clear();
            //foreach (var impressora in PrinterSettings.InstalledPrinters)
            //{
            //    cbSelecImpressora.Items.Add(impressora);
            //}
            //cbSelecImpressora.Dock = DockStyle.Top;
            //Controls.Add(cbSelecImpressora);
            // Adiciona Acha a Lista das Impressoras Instaladas para a  cbSelecImpressora
            // A pkInstalledPrinters string usará o provide o display string

            string pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cbSelecImpressora.Items.Add(pkInstalledPrinters);
                if (pd.PrinterSettings.IsDefaultPrinter)
                {
                    cbSelecImpressora.Text = pd.PrinterSettings.PrinterName;
                }
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (txtEntrega.Text.Equals("0,00"))
            {
                txtEntrega.Text = txtTotal.Text;
            }
            if (rbEcraImpressao.Checked == true)
            {
                cbSelecImpressora.Enabled = false;
                if (cbTipoPapel.Text.Equals("A4"))
                {
                    this.Close();
                    RelVendaA4CIU rel = new RelVendaA4CIU(lst,txtTroco.Text,txtEntrega.Text,"A4"); 
                    rel.ShowDialog();
                }
                else
                {
                    this.Close();
                    RelVendaA4CIU rel = new RelVendaA4CIU(lst, txtTroco.Text, txtEntrega.Text, "TK");
                    rel.ShowDialog();
                    // Previsualizar TK
                }

            }else
            if(rbImprimirDirecto.Checked==true)
            {
                if (cbTipoPapel.Text.Equals("A4"))
                {
                    this.Close();
                    //IMPRESSÃO DIRECTA A4
                    using (var relatorio = new LocalReport())
                    {
                        relatorio.ReportPath = "VendaA4Rel.rdlc";
                        relatorio.DataSources.Add(new ReportDataSource("VendaA4DataSet", lst));
                        relatorio.SetParameters(new ReportParameter("troco", txtTroco.Text));
                        relatorio.SetParameters(new ReportParameter("entregue",txtEntrega.Text));
                        Exportar(relatorio);
                        Imprimir(relatorio);
                    }
                }
                else
                {
                    // IMPRESSÃO DIRECTA TK
                }
            }

        }
        private void Imprimir(LocalReport rel) {
            //using (var pd = new PrintDocument())
            //{
                //cbSelecImpressora.Dock = DockStyle.Top;
                //Controls.Add(cbSelecImpressora);
                //// Adiciona Acha a Lista das Impressoras Instaladas para a  cbSelecImpressora
                //// A pkInstalledPrinters string usará o provide o display string
            
                //string pkInstalledPrinters;
                //for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                //{
                //    pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                //    cbSelecImpressora.Items.Add(pkInstalledPrinters);
                //    if (pd.PrinterSettings.IsDefaultPrinter)
                //    {
                //        cbSelecImpressora.Text = pd.PrinterSettings.PrinterName;
                //    }
                //}
                //pd.PrinterSettings.PrinterName = cbSelecImpressora.SelectedItem.ToString();
                var pageSettings = new PageSettings();
                var pageSettingsRel = rel.GetDefaultPageSettings();
                pageSettings.PaperSize = pageSettingsRel.PaperSize;
                pageSettings.Margins = pageSettingsRel.Margins;
                pd.PrintPage += Pd_PrintPage;
                _streamAtual = 0;
                if (pd.PrinterSettings.MaximumCopies >= (short) nUpDown.Value)
                {
                  pd.PrinterSettings.Copies = (short) nUpDown.Value;
                  pd.Print();
                }
                else
                {
                   MessageBox.Show("A Impressora Não Suporta Cópias Maior que "+ pd.PrinterSettings.MaximumCopies);
                }
               
            //}
        }
        public void Exportar(LocalReport rel) 
        {
            Warning[] warnings;
            LimparStreams();
            rel.Render("Image", CriarDeviceInfo(rel), CreateStreamCallback,out warnings);
        }
        private List<Stream> _streams = new List<Stream>();
        public Stream CreateStreamCallback(string n, string e, Encoding en, string mimT, bool willseak)
        {
            var stream = new MemoryStream();
            _streams.Add(stream);
            return stream;
        }
        private string CriarDeviceInfo(LocalReport rel) 
        {
            var pageSettings = rel.GetDefaultPageSettings();
            return string.Format(
               CultureInfo.InvariantCulture,
               @"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                    <PageWidth>21cm</PageWidth>
                    <PageHeight>29.7cm</PageHeight>
                    <MarginTop>2cm</MarginTop>
                    <MarginLeft>2cm</MarginLeft>
                    <MarginRight>2cm</MarginRight>
                    <MarginBottom>2cm</MarginBottom>
                 </DeviceInfo>
                "
             , pageSettings.PaperSize.Width/100m, pageSettings.PaperSize.Height/100m, pageSettings.Margins.Left/ 100m, pageSettings.Margins.Right /100m
             , pageSettings.Margins.Top /100m, pageSettings.Margins.Bottom /100m
            );
        }
        private void LimparStreams() {
            foreach (var stream in _streams)
            {
                stream.Dispose();
            }
            _streams.Clear();
        }
        private int _streamAtual;
        private void Pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var stream = _streams[_streamAtual];
            stream.Seek(0,SeekOrigin.Begin);
            using (var metadata = new Metafile(stream))
            {
                e.Graphics.DrawImage(metadata,e.PageBounds);
            }
          
            _streamAtual++;
            e.HasMorePages = _streamAtual < _streams.Count;
        }

        private void txtEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                vDados = new VendaDS();
                vDados.ValorEntregue = Convert.ToDouble(txtEntrega.Text);
                if (vDados.ValorEntregue > 0 && vDados.ValorEntregue >= Convert.ToDouble(txtTotal.Text))
                {
                    txtTroco.Text = (vDados.ValorEntregue - Convert.ToDouble(txtTotal.Text)).ToString("N2");
                    vDados.ValorTroco = Convert.ToDouble(txtTroco.Text);
                }
                else {
                    MessageBox.Show("O Valor Entregue Inferior");
                }
                
               
            }
        }

        private void rbEcraImpressao_MouseClick(object sender, MouseEventArgs e)
        {
            cbSelecImpressora.Enabled = false;
        }

        private void rbImprimirDirecto_MouseClick(object sender, MouseEventArgs e)
        {
            cbSelecImpressora.Enabled = true;
        }
    }
}
