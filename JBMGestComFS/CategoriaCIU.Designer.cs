
namespace JBMGestComFS
{
    partial class CategoriaCIU
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
            this.txtDescCateg = new System.Windows.Forms.TextBox();
            this.dtListarCateg = new System.Windows.Forms.DataGridView();
            this.btnAddCateg = new System.Windows.Forms.Button();
            this.btnEditarCateg = new System.Windows.Forms.Button();
            this.btnExcluirCateg = new System.Windows.Forms.Button();
            this.lbCat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtListarCateg)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescCateg
            // 
            this.txtDescCateg.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtDescCateg.Location = new System.Drawing.Point(14, 44);
            this.txtDescCateg.Multiline = true;
            this.txtDescCateg.Name = "txtDescCateg";
            this.txtDescCateg.Size = new System.Drawing.Size(249, 26);
            this.txtDescCateg.TabIndex = 0;
            // 
            // dtListarCateg
            // 
            this.dtListarCateg.AllowUserToAddRows = false;
            this.dtListarCateg.AllowUserToDeleteRows = false;
            this.dtListarCateg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtListarCateg.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtListarCateg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dtListarCateg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListarCateg.Location = new System.Drawing.Point(14, 78);
            this.dtListarCateg.Name = "dtListarCateg";
            this.dtListarCateg.ReadOnly = true;
            this.dtListarCateg.RowHeadersVisible = false;
            this.dtListarCateg.Size = new System.Drawing.Size(558, 287);
            this.dtListarCateg.TabIndex = 1;
            this.dtListarCateg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtListarCateg_CellClick);
            // 
            // btnAddCateg
            // 
            this.btnAddCateg.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCateg.Image = global::JBMGestComFS.Properties.Resources.Plus_16;
            this.btnAddCateg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCateg.Location = new System.Drawing.Point(14, 377);
            this.btnAddCateg.Name = "btnAddCateg";
            this.btnAddCateg.Size = new System.Drawing.Size(98, 27);
            this.btnAddCateg.TabIndex = 2;
            this.btnAddCateg.Text = "Adicionar";
            this.btnAddCateg.UseVisualStyleBackColor = true;
            this.btnAddCateg.Click += new System.EventHandler(this.btnAddCateg_Click);
            // 
            // btnEditarCateg
            // 
            this.btnEditarCateg.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCateg.Image = global::JBMGestComFS.Properties.Resources.Edit_Property_16;
            this.btnEditarCateg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarCateg.Location = new System.Drawing.Point(112, 377);
            this.btnEditarCateg.Name = "btnEditarCateg";
            this.btnEditarCateg.Size = new System.Drawing.Size(93, 27);
            this.btnEditarCateg.TabIndex = 3;
            this.btnEditarCateg.Text = "Atualizar";
            this.btnEditarCateg.UseVisualStyleBackColor = true;
            this.btnEditarCateg.Click += new System.EventHandler(this.btnEditarCateg_Click);
            // 
            // btnExcluirCateg
            // 
            this.btnExcluirCateg.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirCateg.Image = global::JBMGestComFS.Properties.Resources.Deletec_16;
            this.btnExcluirCateg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirCateg.Location = new System.Drawing.Point(205, 377);
            this.btnExcluirCateg.Name = "btnExcluirCateg";
            this.btnExcluirCateg.Size = new System.Drawing.Size(85, 27);
            this.btnExcluirCateg.TabIndex = 4;
            this.btnExcluirCateg.Text = "ExcluirVenda";
            this.btnExcluirCateg.UseVisualStyleBackColor = true;
            this.btnExcluirCateg.Click += new System.EventHandler(this.btnExcluirCateg_Click);
            // 
            // lbCat
            // 
            this.lbCat.AutoSize = true;
            this.lbCat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbCat.Location = new System.Drawing.Point(14, 18);
            this.lbCat.Name = "lbCat";
            this.lbCat.Size = new System.Drawing.Size(149, 19);
            this.lbCat.TabIndex = 5;
            this.lbCat.Text = "Descrição da categoria:";
            // 
            // CategoriaCIU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 412);
            this.Controls.Add(this.lbCat);
            this.Controls.Add(this.btnExcluirCateg);
            this.Controls.Add(this.btnEditarCateg);
            this.Controls.Add(this.btnAddCateg);
            this.Controls.Add(this.dtListarCateg);
            this.Controls.Add(this.txtDescCateg);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "CategoriaCIU";
            this.Text = "CategoriaCIU";
            this.Load += new System.EventHandler(this.CategoriaCIU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtListarCateg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescCateg;
        private System.Windows.Forms.DataGridView dtListarCateg;
        private System.Windows.Forms.Button btnAddCateg;
        private System.Windows.Forms.Button btnEditarCateg;
        private System.Windows.Forms.Button btnExcluirCateg;
        private System.Windows.Forms.Label lbCat;
    }
}