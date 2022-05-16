using System;
using System.Windows.Forms;

namespace JBMGestComFS
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FLoginCIU());
            Application.Run(new FMenuCIU());
            //Application.Run(new VendaCIU());
            //Application.Run(new PesqVendaPorOperadorCIU());
            //Application.Run(new DetImprVendaCIU());
            //Application.Run(new CategoriaCIU());
            //Application.Run(new ProdutoCIU());
            //Application.Run(new PesquisaCIU());
            //Application.Run(new FuncionarioCIU());
            //Application.Run(new EntradaProdutoCIU());
            //Application.Run(new RelEntradaCIU());
            //Application.Run(new SaidaProdutoCIU());
            //Application.Run(new DevolucaoCIU());
        }
    }
}
