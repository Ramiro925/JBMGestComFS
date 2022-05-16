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
    public partial class RelSaidaCIU : Form
    {
        List<SaidaDS> lse;
        public RelSaidaCIU()
        {
            InitializeComponent();
        }
        public RelSaidaCIU(List<SaidaDS> ls)
        {
            InitializeComponent();
            this.lse = ls;
        }
        private List<SaidaDS> GetSaida()
        {
            List<SaidaDS> aux = lse;
            for (int i = 0; i < lse.Count; i++)
            {
                new List<SaidaDS>() {
                new SaidaDS{CodiBarra =lse.ElementAt(i).CodiBarra,
                    NomeProduto=lse.ElementAt(i).NomeProduto,
                    QtdSaida=lse.ElementAt(i).QtdSaida,
                    ValorUnitario=lse.ElementAt(i).ValorUnitario,
                    ValorTotal=lse.ElementAt(i).ValorTotal,
                    ValorGeral=lse.ElementAt(0).ValorGeral,
                    NumDocs = lse.ElementAt(0).NumDocs
                }
            };
            }
            return aux;
        }

        private void RelSaidaCIU_Load(object sender, EventArgs e)
        {
            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.ReportPath = "SaidaProdRel.rdlc";
            ReportDataSource rs = new ReportDataSource("SaidaDataSet", GetSaida());
            this.reportViewer2.LocalReport.DataSources.Add(rs);
            this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
        }
    }
}
