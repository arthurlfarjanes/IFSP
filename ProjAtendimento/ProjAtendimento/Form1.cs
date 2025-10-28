namespace ProjAtendimento
{
    public partial class FormPrincipal : Form
    {
        private Senhas minhasSenhas;
        private Guiches meusGuiches;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load_1(object sender, EventArgs e)
        {
            minhasSenhas = new Senhas();
            meusGuiches = new Guiches();

            lblNumGuiches.Text = meusGuiches.ListaGuiches.Count.ToString();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            minhasSenhas.gerar();
            btnListarSenhas_Click(sender, e);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int novoId = meusGuiches.ListaGuiches.Count + 1;

            Guiche novoGuiche = new Guiche(novoId);
            meusGuiches.adicionar(novoGuiche);

            lblNumGuiches.Text = meusGuiches.ListaGuiches.Count.ToString();
        }

        private void btnChamar_Click(object sender, EventArgs e)
        {
            int idGuiche;

            if (!int.TryParse(txtGuicheId.Text, out idGuiche))
            {
                MessageBox.Show("Por favor, digite um ID de guichê válido (número).");
                return;
            }

            Guiche guicheChamando = meusGuiches.ListaGuiches.Find(g => g.Id == idGuiche);

            if (guicheChamando == null)
            {
                MessageBox.Show("Guichê não encontrado. Adicione guichês primeiro.");
                return;
            }

            bool sucesso = guicheChamando.chamar(minhasSenhas.FilaSenhas);

            if (!sucesso)
            {
                MessageBox.Show("Fila de senhas está vazia!");
            }
            else
            {
                btnListarSenhas_Click(sender, e);
                btnListarAtendimentos_Click(sender, e);
            }
        }

        private void btnListarSenhas_Click(object sender, EventArgs e)
        {
            lbSenhasGeradas.Items.Clear();

            foreach (Senha s in minhasSenhas.FilaSenhas)
            {
                lbSenhasGeradas.Items.Add(s.dadosParciais());
            }
        }

        private void btnListarAtendimentos_Click(object sender, EventArgs e)
        {
            int idGuiche;
            if (!int.TryParse(txtGuicheId.Text, out idGuiche))
            {
                MessageBox.Show("Por favor, digite um ID de guichê válido (número) para listar os atendimentos.");
                return;
            }

            Guiche guicheParaListar = meusGuiches.ListaGuiches.Find(g => g.Id == idGuiche);

            if (guicheParaListar == null)
            {
                MessageBox.Show("Guichê não encontrado.");
                return;
            }

            lbAtendimentos.Items.Clear();

            foreach (Senha s in guicheParaListar.Atendimentos)
            {
                lbAtendimentos.Items.Add(s.dadosCompletos());
            }
        }

        
    }
}
