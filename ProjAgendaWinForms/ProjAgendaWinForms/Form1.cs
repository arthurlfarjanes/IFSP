using ProjListaAgenda;
using System;
using System.Windows.Forms;

namespace ProjAgendaWinForms
{
    public partial class Form1 : Form
    {
        private Contatos agenda;
        private BindingSource bs;

        public Form1()
        {
            InitializeComponent();
            agenda = new Contatos();
            bs = new BindingSource();
            bs.DataSource = agenda.Agenda;
            dgvContatos.DataSource = bs;
        }

        private void AtualizarGrid()
        {
            bs.ResetBindings(false);
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtNascimento.Clear();
            txtTelefone.Clear(); 
            txtNome.Focus(); 
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string email = txtEmail.Text;
                string telefone = txtTelefone.Text; 
                string[] dataNascStr = txtNascimento.Text.Split('/');

                Data dtNasc = new Data(int.Parse(dataNascStr[0]), int.Parse(dataNascStr[1]), int.Parse(dataNascStr[2]));

                Contato novoContato = new Contato(email, nome, telefone, dtNasc);

                if (agenda.adicionar(novoContato))
                {
                    MessageBox.Show("Contato adicionado com sucesso!");
                    AtualizarGrid();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro: Já existe um contato com este email.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar contato. Verifique os dados inseridos.\nDetalhes: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvContatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bs.Position >= 0)
            {
                Contato contatoSelecionado = (Contato)bs.Current;

                txtNome.Text = contatoSelecionado.Nome;
                txtEmail.Text = contatoSelecionado.Email;
                txtNascimento.Text = contatoSelecionado.DtNasc.ToString();
                txtTelefone.Text = contatoSelecionado.Telefone; 
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (bs.Position >= 0)
            {
                Contato contatoParaAlterar = (Contato)bs.Current;

                string novoEmail = txtEmail.Text;

                if (contatoParaAlterar.Email != novoEmail)
                {
                    Contato contatoBusca = new Contato(novoEmail);

                    if (agenda.pesquisar(contatoBusca) != null)
                    {
                        MessageBox.Show("Erro: Já existe um contato cadastrado com este novo email.", "Falha na Alteração", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }
                }

                contatoParaAlterar.Email = novoEmail; 
                contatoParaAlterar.Nome = txtNome.Text;
                contatoParaAlterar.Telefone = txtTelefone.Text;

                string[] dataNascStr = txtNascimento.Text.Split('/');
                contatoParaAlterar.DtNasc.setData(int.Parse(dataNascStr[0]), int.Parse(dataNascStr[1]), int.Parse(dataNascStr[2]));

                AtualizarGrid();
                MessageBox.Show("Contato alterado com sucesso!");
            }
            else
            {
                MessageBox.Show("Nenhum contato selecionado para alterar.");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (bs.Position >= 0)
            {
                Contato contatoParaRemover = (Contato)bs.Current;

                DialogResult resultado = MessageBox.Show(
                    "Tem certeza que deseja remover o contato: " + contatoParaRemover.Nome + "?",
                    "Confirmação de Remoção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    if (agenda.remover(contatoParaRemover))
                    {
                        AtualizarGrid();
                        LimparCampos();
                        MessageBox.Show("Contato removido com sucesso!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhum contato selecionado para remover.");
            }
        }
    }
}