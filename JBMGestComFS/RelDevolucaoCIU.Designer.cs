
namespace JBMGestComFS
{
    partial class RelDevolucaoCIU
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer5 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer5
            // 
            this.reportViewer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer5.Location = new System.Drawing.Point(0, 0);
            this.reportViewer5.Name = "reportViewer5";
            this.reportViewer5.ServerReport.BearerToken = null;
            this.reportViewer5.Size = new System.Drawing.Size(943, 547);
            this.reportViewer5.TabIndex = 0;
            // 
            // RelDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 547);
            this.Controls.Add(this.reportViewer5);
            this.Name = "RelDevolucao";
            this.Text = "RelDevolucao";
            this.Load += new System.EventHandler(this.RelDevolucao_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer5;
    }
}