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
    public partial class RelDevolucaoCIU : Form
    {
        private List<DevolucaoDS> lse;
        private string nomeUtilizador;
        public RelDevolucaoCIU(List<DevolucaoDS> ls,string nomeUtil)
        {
            InitializeComponent();
            this.lse = ls;
            nomeUtilizador = nomeUtil;
        }
        public RelDevolucaoCIU()
        {
            InitializeComponent();
        }
        private void RelDevolucao_Load(object sender, EventArgs e)
        {
            this.reportViewer5.LocalReport.DataSources.Clear();
            this.reportViewer5.LocalReport.ReportPath = "DevolucaoClienteRel.rdlc";
            ReportDataSource rs = new ReportDataSource("DevolucaoClienteDataSet", GetDevolucao());
            this.reportViewer5.LocalReport.SetParameters(new ReportParameter("nomeUtilizador", nomeUtilizador));
            this.reportViewer5.LocalReport.DataSources.Add(rs);
            this.reportViewer5.RefreshReport();
        }
        private List<DevolucaoDS> GetDevolucao()
        {
            List<DevolucaoDS> aux = lse;
            for (int i = 0; i < lse.Count; i++)
            {
                new List<DevolucaoDS>() {
                new DevolucaoDS{CodiBarra =lse.ElementAt(i).CodiBarra,
                    NomeProduto=lse.ElementAt(i).NomeProduto,
                    QtdItemVenda = lse.ElementAt(i).QtdItemVenda,
                    ValorItemVenda = lse.ElementAt(i).ValorItemVenda,
                    ValorTotal=lse.ElementAt(i).ValorTotal,
                    DescontoVenda =lse.ElementAt(i).DescontoVenda,
                    PercTaxaImposto = lse.ElementAt(i).PercTaxaImposto,
                    NDoc = lse.ElementAt(i).NDoc,
                    NifCliente = lse.ElementAt(i).NifCliente,
                    NomeCliente = lse.ElementAt(i).NomeCliente
                }
            };
            }
            return aux;
        }
    }
}
