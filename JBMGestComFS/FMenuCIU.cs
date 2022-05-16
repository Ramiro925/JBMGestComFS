using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using MODELO;

namespace JBMGestComFS
{
    public partial class FMenuCIU : Form
    {
        //VARIAVEL GLOBAL PARA RECEBER DADOS VINDA DO FORMULARIO LOGIN
        public UtilizadorModelo util;
        public FMenuCIU()
        {
            InitializeComponent();
            EsconderSubMenu();
        }
        //CONSTRUTOR RESPONSAVEL NA TRANSFERENCIA DE DADOS ENTRE O FORMULÁRIO LOGIN E O MENU PRINCIPAL
        public FMenuCIU(UtilizadorModelo uP)
        {
            InitializeComponent();
            util = uP; 
        }
        //Método de invocar controle de usuario Cadastrar produto.
        private void empregarFuncionárioToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FuncionarioCIU fun = new FuncionarioCIU();
            fun.ShowDialog();
        }
        private void btnVendaPost_Click(object sender, EventArgs e)
        {
            //Slider
            pnSlide.Location = new Point(13, btnVendaPost.Location.Y);
            //Invocar formuláro de facturação
            VendaCIU ft = new VendaCIU(util);
            ft.Show();
        }
        private void btnStock_Click_1(object sender, EventArgs e)
        {
            //Slider
            pnSlide.Location = new Point(13, btnStock.Location.Y);
            //Invocar controle de usuario Cadastrar produto
            ProdutoCIU pdciu = new ProdutoCIU();
            pdciu.ShowDialog();
        }
        private void btnEstatistica_Click(object sender, EventArgs e)
        {
            //Slider
            pnSlide.Location = new Point(13, btnEstatistica.Location.Y);
        }
        private void btnBackUp_Click(object sender, EventArgs e)
        {
            //Slider
            pnSlide.Location = new Point(13, btnBackUp.Location.Y);
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            //Slider
            pnSlide.Location = new Point(13, btnSair.Location.Y);
        }
        private void FMenuCIU_Load(object sender, EventArgs e)
        {
            //RESULTADO OBTIDO.
            //MessageBox.Show(util.Cargo);
        }
        private void entradaEmArmazémToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntradaProdutoCIU et = new EntradaProdutoCIU(util);
            et.ShowDialog();
        }
        private void saídaEmArmazémToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaidaProdutoCIU sd = new SaidaProdutoCIU(util);
            sd.ShowDialog();
        }
        private void cadastrarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaCIU cat = new CategoriaCIU();
            cat.ShowDialog();
        }

        private void devoluçãoDeProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevolucaoCIU dv = new DevolucaoCIU(util);
            dv.ShowDialog();
        }

        private void tsmiVendaPorOperador_Click(object sender, EventArgs e)
        {
            PesqVendaPorOperadorCIU pvp = new PesqVendaPorOperadorCIU();
            pvp.ShowDialog();
        }
        //================================================================//
        public void EsconderSubMenu()
        {
            foreach (var pnl in pnlMenu.Controls.OfType<Panel>())
                pnl.Height = 20;
        }
        public void MostrarSubMenu(Panel pnl)
        {
            pnl.Height = pnl.Controls.OfType<Button>().Count() * 30 + 15;
        }

        private void btnEstat_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
        }

        private void btnGS_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnlGS);
            EsconderSubMenu();
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnlGC);
            
        }
    }
}
