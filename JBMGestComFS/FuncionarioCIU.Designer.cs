
namespace JBMGestComFS
{
    partial class FuncionarioCIU
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControlUtilizador = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbCargo = new System.Windows.Forms.ComboBox();
            this.dtUtilizador = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumBI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefone1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomeCompleto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvVisualizarUtiliz = new System.Windows.Forms.DataGridView();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAddProduto = new System.Windows.Forms.Button();
            this.txtUtilizador = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtConfirSenha = new System.Windows.Forms.TextBox();
            this.tabControlUtilizador.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisualizarUtiliz)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Utilizador:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 23);
            this.label2.TabIndex = 80;
            this.label2.Text = "Senha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 23);
            this.label3.TabIndex = 82;
            this.label3.Text = "Confirmar Senha:";
            // 
            // tabControlUtilizador
            // 
            this.tabControlUtilizador.Controls.Add(this.tabPage1);
            this.tabControlUtilizador.Controls.Add(this.tabPage3);
            this.tabControlUtilizador.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            this.tabControlUtilizador.Location = new System.Drawing.Point(16, 149);
            this.tabControlUtilizador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControlUtilizador.Name = "tabControlUtilizador";
            this.tabControlUtilizador.SelectedIndex = 0;
            this.tabControlUtilizador.Size = new System.Drawing.Size(1047, 363);
            this.tabControlUtilizador.TabIndex = 84;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbCargo);
            this.tabPage1.Controls.Add(this.dtUtilizador);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtNumBI);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtTelefone1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtNomeCompleto);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1039, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados do Utilizar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbCargo
            // 
            this.cbCargo.FormattingEnabled = true;
            this.cbCargo.Items.AddRange(new object[] {
            "VENDEDOR",
            "GERENTE COMERCIAL"});
            this.cbCargo.Location = new System.Drawing.Point(164, 183);
            this.cbCargo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(344, 28);
            this.cbCargo.TabIndex = 10;
            // 
            // dtUtilizador
            // 
            this.dtUtilizador.CustomFormat = "dd-MM-yyyy";
            this.dtUtilizador.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtUtilizador.Location = new System.Drawing.Point(164, 222);
            this.dtUtilizador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtUtilizador.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dtUtilizador.Name = "dtUtilizador";
            this.dtUtilizador.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtUtilizador.Size = new System.Drawing.Size(140, 28);
            this.dtUtilizador.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 229);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 21);
            this.label8.TabIndex = 8;
            this.label8.Text = "Data Admitido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 183);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "Cargo:";
            // 
            // txtNumBI
            // 
            this.txtNumBI.Location = new System.Drawing.Point(164, 139);
            this.txtNumBI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumBI.Name = "txtNumBI";
            this.txtNumBI.Size = new System.Drawing.Size(344, 28);
            this.txtNumBI.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 143);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "Número B.I:";
            // 
            // txtTelefone1
            // 
            this.txtTelefone1.Location = new System.Drawing.Point(164, 96);
            this.txtTelefone1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelefone1.Name = "txtTelefone1";
            this.txtTelefone1.Size = new System.Drawing.Size(344, 28);
            this.txtTelefone1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "Telefone:";
            // 
            // txtNomeCompleto
            // 
            this.txtNomeCompleto.Location = new System.Drawing.Point(164, 48);
            this.txtNomeCompleto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNomeCompleto.Name = "txtNomeCompleto";
            this.txtNomeCompleto.Size = new System.Drawing.Size(344, 28);
            this.txtNomeCompleto.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nome Completo:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvVisualizarUtiliz);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(1039, 330);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Visualizar Utilizador";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvVisualizarUtiliz
            // 
            this.dgvVisualizarUtiliz.AllowUserToAddRows = false;
            this.dgvVisualizarUtiliz.AllowUserToDeleteRows = false;
            this.dgvVisualizarUtiliz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisualizarUtiliz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisualizarUtiliz.Location = new System.Drawing.Point(4, 4);
            this.dgvVisualizarUtiliz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvVisualizarUtiliz.Name = "dgvVisualizarUtiliz";
            this.dgvVisualizarUtiliz.ReadOnly = true;
            this.dgvVisualizarUtiliz.RowHeadersVisible = false;
            this.dgvVisualizarUtiliz.RowHeadersWidth = 51;
            this.dgvVisualizarUtiliz.Size = new System.Drawing.Size(992, 319);
            this.dgvVisualizarUtiliz.TabIndex = 0;
            this.dgvVisualizarUtiliz.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVisualizarUtiliz_CellClick);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::JBMGestComFS.Properties.Resources.Deletec_16;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(312, 514);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnExcluir.Size = new System.Drawing.Size(127, 37);
            this.btnExcluir.TabIndex = 82;
            this.btnExcluir.Text = "ExcluirVenda";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = global::JBMGestComFS.Properties.Resources.Edit_Property_16;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(177, 514);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnEditar.Size = new System.Drawing.Size(135, 37);
            this.btnEditar.TabIndex = 81;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAddProduto
            // 
            this.btnAddProduto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduto.Image = global::JBMGestComFS.Properties.Resources.Savec_16;
            this.btnAddProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduto.Location = new System.Drawing.Point(21, 514);
            this.btnAddProduto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddProduto.Name = "btnAddProduto";
            this.btnAddProduto.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnAddProduto.Size = new System.Drawing.Size(156, 37);
            this.btnAddProduto.TabIndex = 80;
            this.btnAddProduto.Text = "Guardar";
            this.btnAddProduto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddProduto.UseVisualStyleBackColor = true;
            this.btnAddProduto.Click += new System.EventHandler(this.btnGuardarProdut_Click);
            // 
            // txtUtilizador
            // 
            this.txtUtilizador.Location = new System.Drawing.Point(193, 18);
            this.txtUtilizador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUtilizador.Name = "txtUtilizador";
            this.txtUtilizador.Size = new System.Drawing.Size(313, 22);
            this.txtUtilizador.TabIndex = 28;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(193, 59);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '.';
            this.txtSenha.Size = new System.Drawing.Size(313, 22);
            this.txtSenha.TabIndex = 85;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // txtConfirSenha
            // 
            this.txtConfirSenha.Location = new System.Drawing.Point(193, 92);
            this.txtConfirSenha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConfirSenha.Name = "txtConfirSenha";
            this.txtConfirSenha.PasswordChar = '.';
            this.txtConfirSenha.Size = new System.Drawing.Size(313, 22);
            this.txtConfirSenha.TabIndex = 86;
            this.txtConfirSenha.UseSystemPasswordChar = true;
            // 
            // FuncionarioCIU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1079, 555);
            this.Controls.Add(this.txtConfirSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUtilizador);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.tabControlUtilizador);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAddProduto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FuncionarioCIU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcionario";
            this.Load += new System.EventHandler(this.Funcionario_Load);
            this.tabControlUtilizador.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisualizarUtiliz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControlUtilizador;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumBI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefone1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomeCompleto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtUtilizador;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAddProduto;
        private System.Windows.Forms.DataGridView dgvVisualizarUtiliz;
        private System.Windows.Forms.TextBox txtUtilizador;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtConfirSenha;
        private System.Windows.Forms.ComboBox cbCargo;
    }
}