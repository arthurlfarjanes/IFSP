namespace ProjetoBilheteriaWinForms
{
    public partial class Form1 : Form
    {
        // 'false' = Vaga, 'true' = Ocupada.
        // 15 fileiras, 40 poltronas por fileira.
        private bool[,] poltronas;

        private const int NUMERO_FILEIRAS = 15;
        private const int POLTRONAS_POR_FILEIRA = 40;

        // Label para exibir o resultado do faturamento
        private Label lblResultadoFaturamento;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Define um título para a janela
            this.Text = "Sistema de Bilheteria";

            // Inicializa a matriz de poltronas
            poltronas = new bool[NUMERO_FILEIRAS, POLTRONAS_POR_FILEIRA];

            // Chama o método para criar a interface
            CriarInterfaceDoTeatro();
        }

        private void CriarInterfaceDoTeatro()
        {
            // Define o tamanho e a posição para o primeiro botão
            int larguraPoltrona = 30;
            int alturaPoltrona = 30;
            int espacamento = 5;
            int xInicial = 10;
            int yInicial = 10;
            int x = xInicial;
            int y = yInicial;

            // Loop percorre as FILEIRAS (de 0 a 14)
            for (int i = 0; i < NUMERO_FILEIRAS; i++)
            {
                // Loop percorre as POLTRONAS em cada fileira (de 0 a 39)
                for (int j = 0; j < POLTRONAS_POR_FILEIRA; j++)
                {
                    // Cria uma nova instância de Botão
                    Button poltrona = new Button();

                    // Define as propriedades do botão
                    poltrona.Width = larguraPoltrona;
                    poltrona.Height = alturaPoltrona;
                    poltrona.Left = x;
                    poltrona.Top = y;
                    poltrona.Text = (j + 1).ToString(); // Mostra o número da poltrona
                    poltrona.BackColor = Color.Green; // Verde para poltrona vaga

                    // Armazena a posição (fileira, poltrona) no próprio botão
                    // A propriedade 'Tag' serve para guardar qualquer tipo de objeto.
                    poltrona.Tag = new Point(i, j);

                    // Associa um evento de clique ao botão
                    poltrona.Click += new EventHandler(Poltrona_Click);

                    // Adiciona o botão ao formulário
                    this.Controls.Add(poltrona);

                    // Atualiza a posição X para a próxima poltrona
                    x += larguraPoltrona + espacamento;
                }

                // Reseta a posição X e atualiza a posição Y para a próxima fileira
                x = xInicial;
                y += alturaPoltrona + espacamento;
            }

            // Obtem a posição Y do último elemento para posicionar um botão abaixo
            int yPosControles = y;

            CriarControlesFaturamento(yPosControles);
        }

        private void Poltrona_Click(object sender, EventArgs e)
        {
            // Identifica qual botão foi clicado
            Button poltronaClicada = (Button)sender;

            // Recupera as coordenadas da poltrona que guardamos na 'Tag'
            Point coordenadas = (Point)poltronaClicada.Tag;
            int fileira = coordenadas.X;
            int poltrona = coordenadas.Y;

            // Verifica o estado da poltrona na nossa matriz de controle
            if (poltronas[fileira, poltrona] == false)
            {
                // Marca como ocupada na matriz
                poltronas[fileira, poltrona] = true;

                // Atualiza a aparência do botão
                poltronaClicada.BackColor = Color.Red;
                poltronaClicada.Enabled = false; // Desabilita para não poder clicar de novo

                MessageBox.Show($"Poltrona {poltrona + 1} da fileira {fileira + 1} reservada com sucesso!");
            }
            else
            {
                MessageBox.Show("Este lugar já está ocupado!");
            }
        }

        private void CriarControlesFaturamento(int yPosicao)
        {
            // Cria o botão de Faturamento
            Button btnFaturamento = new Button();
            btnFaturamento.Text = "Faturamento";
            btnFaturamento.Width = 100;
            btnFaturamento.Height = 40;
            btnFaturamento.Left = 10;
            btnFaturamento.Top = yPosicao + 10; // Um pouco abaixo da última fileira
            btnFaturamento.Click += new EventHandler(BtnFaturamento_Click);
            this.Controls.Add(btnFaturamento);

            // Cria o Label para o resultado
            lblResultadoFaturamento = new Label();
            lblResultadoFaturamento.Text = "Clique em Faturamento para ver o resultado.";
            lblResultadoFaturamento.Font = new Font("Arial", 10, FontStyle.Bold);
            lblResultadoFaturamento.AutoSize = true; // Ajusta o tamanho do label ao texto
            lblResultadoFaturamento.Left = btnFaturamento.Right + 10; // À direita do botão
            lblResultadoFaturamento.Top = yPosicao + 20;
            this.Controls.Add(lblResultadoFaturamento);

            // Ajusta o tamanho do formulário para caber tudo
            this.ClientSize = new Size(1370, yPosicao + 60);
        }

        private void BtnFaturamento_Click(object sender, EventArgs e)
        {
            int lugaresOcupados = 0;
            decimal valorBilheteria = 0;

            // Percorre toda a matriz de poltronas
            for (int i = 0; i < NUMERO_FILEIRAS; i++)
            {
                for (int j = 0; j < POLTRONAS_POR_FILEIRA; j++)
                {
                    // Se a poltrona [i, j] estiver ocupada
                    if (poltronas[i, j] == true)
                    {
                        lugaresOcupados++;

                        // Calcula o preço baseado na fileira (índice i)
                        int numeroFileira = i + 1;

                        if (numeroFileira >= 1 && numeroFileira <= 5)
                        {
                            valorBilheteria += 50.00m;
                        }
                        else if (numeroFileira >= 6 && numeroFileira <= 10)
                        {
                            valorBilheteria += 30.00m;
                        }
                        else // Fileiras 11 a 15
                        {
                            valorBilheteria += 15.00m;
                        }
                    }
                }
            }

            lblResultadoFaturamento.Text = $"Lugares Ocupados: {lugaresOcupados}\n" +
                                           $"Valor da Bilheteria: {valorBilheteria:C}"; // O especificador "C" formata o valor como moeda local (R$)
        }
    }
}
