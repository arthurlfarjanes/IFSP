namespace ProjAtendimento
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbSenhasGeradas = new ListBox();
            lbAtendimentos = new ListBox();
            btnGerar = new Button();
            btnListarAtendimentos = new Button();
            label1 = new Label();
            label3 = new Label();
            lblNumGuiches = new Label();
            txtGuicheId = new TextBox();
            btnAdicionar = new Button();
            btnChamar = new Button();
            btnListarSenhas = new Button();
            SuspendLayout();
            // 
            // lbSenhasGeradas
            // 
            lbSenhasGeradas.FormattingEnabled = true;
            lbSenhasGeradas.ItemHeight = 15;
            lbSenhasGeradas.Location = new Point(12, 46);
            lbSenhasGeradas.Name = "lbSenhasGeradas";
            lbSenhasGeradas.Size = new Size(209, 139);
            lbSenhasGeradas.TabIndex = 0;
            // 
            // lbAtendimentos
            // 
            lbAtendimentos.FormattingEnabled = true;
            lbAtendimentos.ItemHeight = 15;
            lbAtendimentos.Location = new Point(398, 46);
            lbAtendimentos.Name = "lbAtendimentos";
            lbAtendimentos.Size = new Size(276, 139);
            lbAtendimentos.TabIndex = 1;
            // 
            // btnGerar
            // 
            btnGerar.BackColor = Color.PaleGreen;
            btnGerar.Location = new Point(72, 17);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(75, 23);
            btnGerar.TabIndex = 2;
            btnGerar.Text = "Gerar";
            btnGerar.UseVisualStyleBackColor = false;
            btnGerar.Click += btnGerar_Click;
            // 
            // btnListarAtendimentos
            // 
            btnListarAtendimentos.BackColor = Color.PaleGreen;
            btnListarAtendimentos.Location = new Point(398, 191);
            btnListarAtendimentos.Name = "btnListarAtendimentos";
            btnListarAtendimentos.Size = new Size(276, 23);
            btnListarAtendimentos.TabIndex = 4;
            btnListarAtendimentos.Text = "Listar Atendimentos";
            btnListarAtendimentos.UseVisualStyleBackColor = false;
            btnListarAtendimentos.Click += btnListarAtendimentos_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(271, 70);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 6;
            label1.Text = "Qtd Guichês";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(398, 20);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 7;
            label3.Text = "Guiche:";
            // 
            // lblNumGuiches
            // 
            lblNumGuiches.AutoSize = true;
            lblNumGuiches.Font = new Font("Segoe UI", 16F);
            lblNumGuiches.Location = new Point(295, 97);
            lblNumGuiches.Name = "lblNumGuiches";
            lblNumGuiches.Size = new Size(25, 30);
            lblNumGuiches.TabIndex = 10;
            lblNumGuiches.Text = "0";
            // 
            // txtGuicheId
            // 
            txtGuicheId.Location = new Point(451, 17);
            txtGuicheId.Name = "txtGuicheId";
            txtGuicheId.Size = new Size(41, 23);
            txtGuicheId.TabIndex = 11;
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.PaleGreen;
            btnAdicionar.Location = new Point(263, 136);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(88, 23);
            btnAdicionar.TabIndex = 12;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnChamar
            // 
            btnChamar.BackColor = Color.PaleGreen;
            btnChamar.Location = new Point(586, 16);
            btnChamar.Name = "btnChamar";
            btnChamar.Size = new Size(88, 23);
            btnChamar.TabIndex = 13;
            btnChamar.Text = "Chamar";
            btnChamar.UseVisualStyleBackColor = false;
            btnChamar.Click += btnChamar_Click;
            // 
            // btnListarSenhas
            // 
            btnListarSenhas.BackColor = Color.PaleGreen;
            btnListarSenhas.Location = new Point(57, 191);
            btnListarSenhas.Name = "btnListarSenhas";
            btnListarSenhas.Size = new Size(107, 23);
            btnListarSenhas.TabIndex = 14;
            btnListarSenhas.Text = "Listar Senhas";
            btnListarSenhas.UseVisualStyleBackColor = false;
            btnListarSenhas.Click += btnListarSenhas_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 230);
            Controls.Add(btnListarSenhas);
            Controls.Add(btnChamar);
            Controls.Add(btnAdicionar);
            Controls.Add(txtGuicheId);
            Controls.Add(lblNumGuiches);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnListarAtendimentos);
            Controls.Add(btnGerar);
            Controls.Add(lbAtendimentos);
            Controls.Add(lbSenhasGeradas);
            Name = "FormPrincipal";
            Text = "Central de Atendimento";
            Load += FormPrincipal_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbSenhasGeradas;
        private ListBox lbAtendimentos;
        private Button btnGerar;
        private Button btnListarAtendimentos;
        private Label label1;
        private Label label3;
        private Label lblNumGuiches;
        private TextBox txtGuicheId;
        private Button btnAdicionar;
        private Button btnChamar;
        private Button btnListarSenhas;
    }
}
