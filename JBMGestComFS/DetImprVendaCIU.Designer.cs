
namespace JBMGestComFS
{
    partial class DetImprVendaCIU
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTipoPapel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNDocs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbSelecImpressora = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbEcraImpressao = new System.Windows.Forms.RadioButton();
            this.rbImprimirDirecto = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTroco = new System.Windows.Forms.TextBox();
            this.txtEntrega = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nUpDown);
            this.panel1.Controls.Add(this.cbTipoPapel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNDocs);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 101);
            this.panel1.TabIndex = 0;
            // 
            // cbTipoPapel
            // 
            this.cbTipoPapel.BackColor = System.Drawing.Color.White;
            this.cbTipoPapel.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoPapel.FormattingEnabled = true;
            this.cbTipoPapel.Items.AddRange(new object[] {
            "TK",
            "A4"});
            this.cbTipoPapel.Location = new System.Drawing.Point(347, 54);
            this.cbTipoPapel.Name = "cbTipoPapel";
            this.cbTipoPapel.Size = new System.Drawing.Size(120, 30);
            this.cbTipoPapel.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(343, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Papel:";
            // 
            // txtNDocs
            // 
            this.txtNDocs.BackColor = System.Drawing.Color.White;
            this.txtNDocs.Enabled = false;
            this.txtNDocs.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNDocs.Location = new System.Drawing.Point(20, 52);
            this.txtNDocs.Name = "txtNDocs";
            this.txtNDocs.Size = new System.Drawing.Size(120, 29);
            this.txtNDocs.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nº Cópias:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº do Doc.:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbSelecImpressora);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(12, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 166);
            this.panel2.TabIndex = 1;
            // 
            // cbSelecImpressora
            // 
            this.cbSelecImpressora.FormattingEnabled = true;
            this.cbSelecImpressora.Location = new System.Drawing.Point(3, 133);
            this.cbSelecImpressora.Name = "cbSelecImpressora";
            this.cbSelecImpressora.Size = new System.Drawing.Size(244, 24);
            this.cbSelecImpressora.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Seleção de Impressora:";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 184);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 70);
            this.panel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbEcraImpressao);
            this.groupBox2.Controls.Add(this.rbImprimirDirecto);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 98);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modo de Impressão";
            // 
            // rbEcraImpressao
            // 
            this.rbEcraImpressao.AutoSize = true;
            this.rbEcraImpressao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEcraImpressao.Location = new System.Drawing.Point(17, 55);
            this.rbEcraImpressao.Name = "rbEcraImpressao";
            this.rbEcraImpressao.Size = new System.Drawing.Size(160, 28);
            this.rbEcraImpressao.TabIndex = 1;
            this.rbEcraImpressao.TabStop = true;
            this.rbEcraImpressao.Text = "Ecrã/Impressão";
            this.rbEcraImpressao.UseVisualStyleBackColor = true;
            this.rbEcraImpressao.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbEcraImpressao_MouseClick);
            // 
            // rbImprimirDirecto
            // 
            this.rbImprimirDirecto.AutoSize = true;
            this.rbImprimirDirecto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbImprimirDirecto.Location = new System.Drawing.Point(17, 27);
            this.rbImprimirDirecto.Name = "rbImprimirDirecto";
            this.rbImprimirDirecto.Size = new System.Drawing.Size(173, 28);
            this.rbImprimirDirecto.TabIndex = 0;
            this.rbImprimirDirecto.TabStop = true;
            this.rbImprimirDirecto.Text = "Imprimir Directo.";
            this.rbImprimirDirecto.UseVisualStyleBackColor = true;
            this.rbImprimirDirecto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbImprimirDirecto_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTroco);
            this.groupBox1.Controls.Add(this.txtEntrega);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(254, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 154);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tickets";
            // 
            // txtTroco
            // 
            this.txtTroco.BackColor = System.Drawing.Color.White;
            this.txtTroco.Enabled = false;
            this.txtTroco.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTroco.ForeColor = System.Drawing.Color.Red;
            this.txtTroco.Location = new System.Drawing.Point(93, 107);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.Size = new System.Drawing.Size(120, 29);
            this.txtTroco.TabIndex = 10;
            this.txtTroco.Text = "0,00";
            this.txtTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEntrega
            // 
            this.txtEntrega.BackColor = System.Drawing.Color.White;
            this.txtEntrega.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntrega.Location = new System.Drawing.Point(93, 69);
            this.txtEntrega.Name = "txtEntrega";
            this.txtEntrega.Size = new System.Drawing.Size(120, 29);
            this.txtEntrega.TabIndex = 9;
            this.txtEntrega.Text = "0,00";
            this.txtEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEntrega.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEntrega_KeyDown);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(93, 28);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(120, 29);
            this.txtTotal.TabIndex = 6;
            this.txtTotal.Text = "0,00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "Troco:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Entrega:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Total:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(366, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(101, 32);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnImprimir);
            this.panel4.Location = new System.Drawing.Point(12, 291);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(491, 38);
            this.panel4.TabIndex = 4;
            // 
            // nUpDown
            // 
            this.nUpDown.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUpDown.Location = new System.Drawing.Point(186, 52);
            this.nUpDown.Name = "nUpDown";
            this.nUpDown.Size = new System.Drawing.Size(86, 29);
            this.nUpDown.TabIndex = 7;
            this.nUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DetImprVendaCIU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 333);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetImprVendaCIU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DetalheImpressaoVenda";
            this.Load += new System.EventHandler(this.DetImprVendaCIU_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbTipoPapel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNDocs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbEcraImpressao;
        private System.Windows.Forms.RadioButton rbImprimirDirecto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTroco;
        private System.Windows.Forms.TextBox txtEntrega;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbSelecImpressora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nUpDown;
    }
}