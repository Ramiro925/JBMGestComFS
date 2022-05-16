
namespace JBMGestComFS
{
    partial class PesquisaCIU
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPesquisarCIU = new System.Windows.Forms.TextBox();
            this.dtgvPesquisarCIU = new System.Windows.Forms.DataGridView();
            this.lbPesquisar = new System.Windows.Forms.Label();
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPesquisarCIU)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPesquisarCIU
            // 
            this.txtPesquisarCIU.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPesquisarCIU.Location = new System.Drawing.Point(9, 39);
            this.txtPesquisarCIU.Margin = new System.Windows.Forms.Padding(4);
            this.txtPesquisarCIU.Multiline = true;
            this.txtPesquisarCIU.Name = "txtPesquisarCIU";
            this.txtPesquisarCIU.Size = new System.Drawing.Size(321, 29);
            this.txtPesquisarCIU.TabIndex = 0;
            // 
            // dtgvPesquisarCIU
            // 
            this.dtgvPesquisarCIU.AllowUserToAddRows = false;
            this.dtgvPesquisarCIU.AllowUserToDeleteRows = false;
            this.dtgvPesquisarCIU.AllowUserToOrderColumns = true;
            this.dtgvPesquisarCIU.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvPesquisarCIU.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvPesquisarCIU.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvPesquisarCIU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvPesquisarCIU.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgvPesquisarCIU.Location = new System.Drawing.Point(4, 17);
            this.dtgvPesquisarCIU.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvPesquisarCIU.Name = "dtgvPesquisarCIU";
            this.dtgvPesquisarCIU.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.35F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvPesquisarCIU.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgvPesquisarCIU.RowHeadersVisible = false;
            this.dtgvPesquisarCIU.RowHeadersWidth = 51;
            this.dtgvPesquisarCIU.Size = new System.Drawing.Size(756, 402);
            this.dtgvPesquisarCIU.TabIndex = 1;
            this.dtgvPesquisarCIU.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPesquisarCIU_CellClick);
            // 
            // lbPesquisar
            // 
            this.lbPesquisar.AutoSize = true;
            this.lbPesquisar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPesquisar.Location = new System.Drawing.Point(5, 11);
            this.lbPesquisar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPesquisar.Name = "lbPesquisar";
            this.lbPesquisar.Size = new System.Drawing.Size(81, 23);
            this.lbPesquisar.TabIndex = 2;
            this.lbPesquisar.Text = "Pesquisar";
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.Location = new System.Drawing.Point(337, 39);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(100, 29);
            this.BtnPesquisar.TabIndex = 3;
            this.BtnPesquisar.Text = "Pesquisar";
            this.BtnPesquisar.UseVisualStyleBackColor = true;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvPesquisarCIU);
            this.panel1.Location = new System.Drawing.Point(9, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 423);
            this.panel1.TabIndex = 4;
            // 
            // PesquisaCIU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 510);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnPesquisar);
            this.Controls.Add(this.lbPesquisar);
            this.Controls.Add(this.txtPesquisarCIU);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PesquisaCIU";
            this.Text = "JBMGestComFS Pesquisar Artigos";
            this.Load += new System.EventHandler(this.PesquisaCIU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPesquisarCIU)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgvPesquisarCIU;
        private System.Windows.Forms.Label lbPesquisar;
        public System.Windows.Forms.TextBox txtPesquisarCIU;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.Panel panel1;
    }
}