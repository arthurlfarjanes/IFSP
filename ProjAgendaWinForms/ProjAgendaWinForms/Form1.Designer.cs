namespace ProjAgendaWinForms
{
    partial class Form1
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
            lblNome = new Label();
            lblEmail = new Label();
            lblNascimento = new Label();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtNascimento = new TextBox();
            btnAdicionar = new Button();
            btnAlterar = new Button();
            btnRemover = new Button();
            btnLimpar = new Button();
            dgvContatos = new DataGridView();
            txtTelefone = new TextBox();
            lblTelefone = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvContatos).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(27, 19);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(26, 68);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 15);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "E-mail:";
            // 
            // lblNascimento
            // 
            lblNascimento.AutoSize = true;
            lblNascimento.Location = new Point(27, 166);
            lblNascimento.Name = "lblNascimento";
            lblNascimento.Size = new Size(155, 15);
            lblNascimento.TabIndex = 2;
            lblNascimento.Text = "Nascimento (dd/mm/aaaa):";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(27, 37);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(250, 23);
            txtNome.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(27, 86);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 23);
            txtEmail.TabIndex = 4;
            // 
            // txtNascimento
            // 
            txtNascimento.Location = new Point(26, 184);
            txtNascimento.Name = "txtNascimento";
            txtNascimento.Size = new Size(251, 23);
            txtNascimento.TabIndex = 5;
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.LightSeaGreen;
            btnAdicionar.FlatStyle = FlatStyle.Flat;
            btnAdicionar.ForeColor = SystemColors.ButtonFace;
            btnAdicionar.Location = new Point(361, 39);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(134, 24);
            btnAdicionar.TabIndex = 6;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.BackColor = Color.LightSeaGreen;
            btnAlterar.FlatStyle = FlatStyle.Flat;
            btnAlterar.ForeColor = SystemColors.ButtonFace;
            btnAlterar.Location = new Point(361, 86);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(134, 24);
            btnAlterar.TabIndex = 7;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = false;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnRemover
            // 
            btnRemover.BackColor = Color.LightSeaGreen;
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.ForeColor = SystemColors.ButtonFace;
            btnRemover.Location = new Point(361, 137);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(134, 24);
            btnRemover.TabIndex = 8;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.LightSeaGreen;
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.ForeColor = SystemColors.ButtonFace;
            btnLimpar.Location = new Point(361, 186);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(134, 24);
            btnLimpar.TabIndex = 9;
            btnLimpar.Text = "Limpar Campos";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // dgvContatos
            // 
            dgvContatos.BackgroundColor = SystemColors.Menu;
            dgvContatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContatos.GridColor = SystemColors.Info;
            dgvContatos.Location = new Point(19, 237);
            dgvContatos.Name = "dgvContatos";
            dgvContatos.Size = new Size(476, 272);
            dgvContatos.TabIndex = 10;
            dgvContatos.CellClick += dgvContatos_CellClick;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(27, 135);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(249, 23);
            txtTelefone.TabIndex = 12;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(27, 117);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(55, 15);
            lblTelefone.TabIndex = 11;
            lblTelefone.Text = "Telefone:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 533);
            Controls.Add(txtTelefone);
            Controls.Add(lblTelefone);
            Controls.Add(dgvContatos);
            Controls.Add(btnLimpar);
            Controls.Add(btnRemover);
            Controls.Add(btnAlterar);
            Controls.Add(btnAdicionar);
            Controls.Add(txtNascimento);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(lblNascimento);
            Controls.Add(lblEmail);
            Controls.Add(lblNome);
            Name = "Form1";
            Text = "Agenda de Contatos";
            ((System.ComponentModel.ISupportInitialize)dgvContatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblEmail;
        private Label lblNascimento;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtNascimento;
        private Button btnAdicionar;
        private Button btnAlterar;
        private Button btnRemover;
        private Button btnLimpar;
        private DataGridView dgvContatos;
        private TextBox txtTelefone;
        private Label lblTelefone;
    }
}
