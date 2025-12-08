namespace ProjetoTransporte
{
    class Program
    {
        static List<Veiculo> frota = new List<Veiculo>();
        static List<Garagem> garagens = new List<Garagem>();
        static List<Viagem> historicoViagens = new List<Viagem>();

        static bool jornadaIniciada = false;

        static void Main(string[] args)
        {
            InicializarDados();

            int opcao = -1;
            while (opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("=== PROJETO TRANSPORTE - PILHA ===");
                Console.WriteLine($"Status da Jornada: {(jornadaIniciada ? "INICIADA" : "ENCERRADA")}");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("0. Finalizar");
                Console.WriteLine("1. Cadastrar veículo");
                Console.WriteLine("2. Cadastrar garagem");
                Console.WriteLine("3. Iniciar jornada");
                Console.WriteLine("4. Encerrar jornada");
                Console.WriteLine("5. Liberar viagem");
                Console.WriteLine("6. Listar veículos em garagem");
                Console.WriteLine("7. Qtd viagens (Origem -> Destino)");
                Console.WriteLine("8. Listar viagens (Origem -> Destino)");
                Console.WriteLine("9. Qtd passageiros (Origem -> Destino)");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    try
                    {
                        ProcessarOpcao(opcao);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                    Console.ReadKey();
                }
            }
        }

        static void InicializarDados()
        {
            for (int i = 1; i <= 8; i++) frota.Add(new Veiculo(i));

            garagens.Add(new Garagem(1, "Congonhas"));
            garagens.Add(new Garagem(2, "Guarulhos"));
        }

        static void ProcessarOpcao(int opcao)
        {
            Console.WriteLine();
            switch (opcao)
            {
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                case 1:
                    CadastrarVeiculo();
                    break;
                case 2:
                    CadastrarGaragem();
                    break;
                case 3:
                    IniciarJornada();
                    break;
                case 4:
                    EncerrarJornada();
                    break;
                case 5:
                    LiberarViagem();
                    break;
                case 6:
                    ListarVeiculosGaragem();
                    break;
                case 7:
                    InformarQtdViagens();
                    break;
                case 8:
                    ListarViagensEfetuadas();
                    break;
                case 9:
                    InformarQtdPassageiros();
                    break;
                default:
                    Console.WriteLine("Opção desconhecida.");
                    break;
            }
            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
            }
        }

        static void CadastrarVeiculo()
        {
            if (jornadaIniciada) throw new Exception("Não é possível cadastrar com jornada iniciada.");

            int novoId = frota.Count + 1;
            frota.Add(new Veiculo(novoId));
            Console.WriteLine($"Veículo {novoId} cadastrado com sucesso!");
        }

        static void CadastrarGaragem()
        {
            if (jornadaIniciada) throw new Exception("Não é possível cadastrar com jornada iniciada.");

            Console.Write("Nome da nova garagem: ");
            string nome = Console.ReadLine();
            int novoId = garagens.Count + 1;
            garagens.Add(new Garagem(novoId, nome));
            Console.WriteLine($"Garagem {nome} cadastrada com ID {novoId}.");
        }

        static void IniciarJornada()
        {
            if (jornadaIniciada) throw new Exception("A jornada já está iniciada.");
            if (garagens.Count == 0) throw new Exception("Não há garagens cadastradas.");

            foreach (var g in garagens) g.VeiculosEstacionados.Clear();

            int indexGaragem = 0;
            foreach (var veiculo in frota)
            {
                garagens[indexGaragem].VeiculosEstacionados.Push(veiculo);
                indexGaragem = (indexGaragem + 1) % garagens.Count;
            }

            jornadaIniciada = true;
            Console.WriteLine("Jornada iniciada! Veículos distribuídos nas garagens.");
        }

        static void EncerrarJornada()
        {
            if (!jornadaIniciada) throw new Exception("A jornada não foi iniciada.");

            Console.WriteLine("=== RELATÓRIO DE ENCERRAMENTO ===");
            foreach (var v in frota)
            {
                Console.WriteLine($"Veículo {v.Id}: Transportou {v.TotalPassageirosTransportados} passageiros.");
                v.TotalPassageirosTransportados = 0;
            }

            historicoViagens.Clear();
            foreach (var g in garagens) g.VeiculosEstacionados.Clear();

            jornadaIniciada = false;
            Console.WriteLine("\nJornada encerrada e dados resetados.");
        }

        static void LiberarViagem()
        {
            if (!jornadaIniciada) throw new Exception("Inicie a jornada primeiro.");

            ListarGaragensParaSelecao();
            Console.Write("ID da Garagem de Origem: ");
            int idOrigem = int.Parse(Console.ReadLine());
            Console.Write("ID da Garagem de Destino: ");
            int idDestino = int.Parse(Console.ReadLine());

            var origem = garagens.FirstOrDefault(g => g.Id == idOrigem);
            var destino = garagens.FirstOrDefault(g => g.Id == idDestino);

            if (origem == null || destino == null) throw new Exception("Garagem inválida.");
            if (origem == destino) throw new Exception("Origem e destino não podem ser iguais.");
            if (origem.VeiculosEstacionados.Count == 0) throw new Exception("Garagem de origem vazia! Aguarde um veículo chegar.");

            Veiculo veiculoDaVez = origem.VeiculosEstacionados.Pop();

            veiculoDaVez.TotalPassageirosTransportados += veiculoDaVez.Capacidade;

            Viagem novaViagem = new Viagem
            {
                Origem = origem,
                Destino = destino,
                Veiculo = veiculoDaVez,
                Passageiros = veiculoDaVez.Capacidade
            };
            historicoViagens.Add(novaViagem);

            destino.VeiculosEstacionados.Push(veiculoDaVez);

            Console.WriteLine($"Viagem realizada! Veículo {veiculoDaVez.Id} foi de {origem.Nome} para {destino.Nome}.");
        }

        static void ListarVeiculosGaragem()
        {
            ListarGaragensParaSelecao();
            Console.Write("Digite o ID da garagem: ");
            int id = int.Parse(Console.ReadLine());
            var garagem = garagens.FirstOrDefault(g => g.Id == id);

            if (garagem == null) throw new Exception("Garagem não encontrada.");

            Console.WriteLine($"\n--- Veículos em {garagem.Nome} ---");
            if (garagem.VeiculosEstacionados.Count == 0)
            {
                Console.WriteLine("Nenhum veículo estacionado.");
            }
            else
            {
                foreach (var v in garagem.VeiculosEstacionados)
                {
                    Console.WriteLine($"Veículo ID: {v.Id} (Capacidade: {v.Capacidade})");
                }
                Console.WriteLine($"Total Veículos: {garagem.QuantidadeVeiculos()}");
                Console.WriteLine($"Potencial de Transporte: {garagem.PotencialTransporte()}");
            }
        }

        static void InformarQtdViagens()
        {
            var (origem, destino) = SelecionarOrigemDestino();
            int qtd = historicoViagens.Count(v => v.Origem == origem && v.Destino == destino);
            Console.WriteLine($"Total de viagens de {origem.Nome} para {destino.Nome}: {qtd}");
        }

        static void ListarViagensEfetuadas()
        {
            var (origem, destino) = SelecionarOrigemDestino();
            var viagensFiltradas = historicoViagens.Where(v => v.Origem == origem && v.Destino == destino).ToList();

            Console.WriteLine($"\n--- Viagens de {origem.Nome} para {destino.Nome} ---");
            foreach (var v in viagensFiltradas)
            {
                Console.WriteLine($"Veículo {v.Veiculo.Id} transportou {v.Passageiros} passageiros.");
            }
        }

        static void InformarQtdPassageiros()
        {
            var (origem, destino) = SelecionarOrigemDestino();
            int totalPassageiros = historicoViagens
                .Where(v => v.Origem == origem && v.Destino == destino)
                .Sum(v => v.Passageiros);

            Console.WriteLine($"Total de passageiros transportados de {origem.Nome} para {destino.Nome}: {totalPassageiros}");
        }

        static void ListarGaragensParaSelecao()
        {
            Console.WriteLine("Garagens disponíveis:");
            foreach (var g in garagens) Console.WriteLine($"{g.Id}. {g.Nome}");
        }

        static (Garagem, Garagem) SelecionarOrigemDestino()
        {
            ListarGaragensParaSelecao();
            Console.Write("ID Origem: ");
            int idOrig = int.Parse(Console.ReadLine());
            Console.Write("ID Destino: ");
            int idDest = int.Parse(Console.ReadLine());

            var origem = garagens.FirstOrDefault(g => g.Id == idOrig);
            var destino = garagens.FirstOrDefault(g => g.Id == idDest);

            if (origem == null || destino == null) throw new Exception("Garagem inválida.");
            return (origem, destino);
        }
    }
}