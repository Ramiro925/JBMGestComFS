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

namespace JBMGestComFS
{
    public partial class RelVendaA4CIU : Form
    {
        private List<VendaDS> l;
        private string troco,valorEntregue;
        private string tipoFormato;
        public RelVendaA4CIU(List<VendaDS> ls,string troco,string entregue,string tipoFormato)
        {
            InitializeComponent();
            this.l = ls;
            this.troco = troco;
            this.valorEntregue = entregue;
            this.tipoFormato = tipoFormato;
        }

        private void RelVendaA4CIU_Load(object sender, EventArgs e)
        {
            ReportDataSource rs;
            if (tipoFormato.Equals("A4"))
            {
                this.reportViewer3.LocalReport.DataSources.Clear();
                this.reportViewer3.LocalReport.ReportPath = "VendaA4Rel.rdlc";
                rs = new ReportDataSource("VendaA4DataSet", GetVenda());
            }
            else
            {
                this.reportViewer3.LocalReport.DataSources.Clear();
                this.reportViewer3.LocalReport.ReportPath = "VendaTKRel.rdlc";
                rs = new ReportDataSource("VendaTKDataSet", GetVenda());
            }
            this.reportViewer3.LocalReport.DataSources.Add(rs);
            this.reportViewer3.LocalReport.SetParameters(new ReportParameter("troco",troco));
            this.reportViewer3.LocalReport.SetParameters(new ReportParameter("entregue", valorEntregue));
            this.reportViewer3.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer3.ZoomMode = ZoomMode.Percent;
            this.reportViewer3.RefreshReport();
        }
        private List<VendaDS> GetVenda()
        {
            List<VendaDS> aux = l;
            for (int i = 0; i < l.Count; i++)
            {
                new List<VendaDS>() {
                new VendaDS{CodiBarra =l.ElementAt(i).CodiBarra,
                    NomeProduto=l.ElementAt(i).NomeProduto,
                    QtdVenda=l.ElementAt(i).QtdVenda,
                    ValorUnitario=l.ElementAt(i).ValorUnitario,
                    PDesconto=l.ElementAt(i).PDesconto,
                    PImposto = l.ElementAt(i).PImposto,
                    ValorTotal=l.ElementAt(i).ValorTotal,
                    ValorGeral=l.ElementAt(0).ValorGeral,
                    NumDocs = l.ElementAt(0).NumDocs
                }
            };
            }
            return aux;
        }
    }
}
