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
    public partial class RelEntradaCIU : Form
    {
        List<EntradaDS> lse;
        public RelEntradaCIU(List<EntradaDS> ls)
        {
            InitializeComponent();
            this.lse = ls;
        }
        public RelEntradaCIU()
        {
            InitializeComponent();
    
        }
        private void RelEntradaCIU_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.ReportPath = "EntradaProdRel.rdlc";
            ReportDataSource rs = new ReportDataSource("EntradaDataSet", GetEntrada());
            this.reportViewer1.LocalReport.DataSources.Add(rs);
            this.reportViewer1.RefreshReport();
        }
        private List<EntradaDS> GetEntrada()
        {
            List<EntradaDS> aux = lse;
            for (int i=0;i<lse.Count;i++) { 
                new List<EntradaDS>() {
                new EntradaDS{CodiBarra =lse.ElementAt(i).CodiBarra,
                    NomeProduto=lse.ElementAt(i).NomeProduto,
                    QtdEntrada=lse.ElementAt(i).QtdEntrada,
                    ValorUnitario=lse.ElementAt(i).ValorUnitario,
                    ValorTotal=lse.ElementAt(i).ValorTotal,
                    ValorGeral=lse.ElementAt(0).ValorGeral,
                    NumDocs = lse.ElementAt(0).NumDocs
                }
            };
            }
            return aux;
        }
    }
}
