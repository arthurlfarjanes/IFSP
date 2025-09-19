using ProjListaAgenda;
using System;

class Program
{
    static Contatos agenda = new Contatos();

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.Clear(); 
            Console.WriteLine("================================");
            Console.WriteLine("|        AGENDA DE CONTATOS    |");
            Console.WriteLine("================================");
            Console.WriteLine("| 0. Sair                      |");
            Console.WriteLine("| 1. Adicionar contato         |");
            Console.WriteLine("| 2. Pesquisar contato         |");
            Console.WriteLine("| 3. Alterar contato           |");
            Console.WriteLine("| 4. Remover contato           |");
            Console.WriteLine("| 5. Listar contatos           |");
            Console.WriteLine("================================");
            Console.Write("Escolha uma opção: ");

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("\nSaindo da aplicação...");
                    break;
                case 1:
                    adicionarContato();
                    break;
                case 2:
                    pesquisarContato();
                    break;
                case 3:
                    alterarContato();
                    break;
                case 4:
                    removerContato();
                    break;
                case 5:
                    listarContatos();
                    break;
                default:
                    Console.WriteLine("\nOpção inválida! Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;
            }

        } while (opcao != 0); 
    }

    static void adicionarContato()
    {
        Console.Clear();
        Console.WriteLine("--- ADICIONAR NOVO CONTATO ---\n");

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Data de Nascimento (dd/mm/aaaa): ");
        string[] dataNascStr = Console.ReadLine().Split('/');
        Data dtNasc = new Data(int.Parse(dataNascStr[0]), int.Parse(dataNascStr[1]), int.Parse(dataNascStr[2]));

        Contato novoContato = new Contato(email, nome, dtNasc);

        char adicionarOutroTel;
        do
        {
            Console.Write("Tipo do Telefone (Celular, Casa, etc.): ");
            string tipo = Console.ReadLine();
            Console.Write("Número do Telefone: ");
            string numero = Console.ReadLine();
            Console.Write("Este é o telefone principal? (s/n): ");
            bool principal = Console.ReadLine().ToLower() == "s";

            novoContato.adicionarTelefone(new Telefone(tipo, numero, principal));

            Console.Write("\nDeseja adicionar outro telefone? (s/n): ");
            adicionarOutroTel = Console.ReadKey().KeyChar;
            Console.WriteLine();

        } while (adicionarOutroTel == 's');

        if (agenda.adicionar(novoContato))
        {
            Console.WriteLine("\nContato adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nErro: Já existe um contato com este email.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    static void pesquisarContato()
    {
        Console.Clear();
        Console.WriteLine("--- PESQUISAR CONTATO ---\n");
        Console.Write("Digite o email do contato a ser pesquisado: ");
        string email = Console.ReadLine();

        Contato contatoPesquisa = new Contato(email);
        Contato contatoEncontrado = agenda.pesquisar(contatoPesquisa);

        if (contatoEncontrado != null)
        {
            Console.WriteLine("\n--- Contato Encontrado ---");
            Console.WriteLine(contatoEncontrado.ToString());
            Console.WriteLine("--------------------------");
        }
        else
        {
            Console.WriteLine("\nContato não encontrado.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    static void alterarContato()
    {
        Console.Clear();
        Console.WriteLine("--- ALTERAR CONTATO ---\n");
        Console.Write("Digite o email do contato que deseja alterar: ");
        string email = Console.ReadLine();

        Contato contatoParaAlterar = agenda.pesquisar(new Contato(email));

        if (contatoParaAlterar != null)
        {
            Console.WriteLine($"\nAlterando dados de: {contatoParaAlterar.Nome}");

            Console.Write("Novo Nome (deixe em branco para não alterar): ");
            string novoNome = Console.ReadLine();
            if (!string.IsNullOrEmpty(novoNome))
            {
                contatoParaAlterar.Nome = novoNome;
            }

            Console.Write("Nova Data de Nascimento (dd/mm/aaaa) (deixe em branco para não alterar): ");
            string novaDataStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(novaDataStr))
            {
                string[] dataPartes = novaDataStr.Split('/');
                contatoParaAlterar.DtNasc.setData(int.Parse(dataPartes[0]), int.Parse(dataPartes[1]), int.Parse(dataPartes[2]));
            }

            Console.WriteLine("\nContato alterado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nContato não encontrado.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    static void removerContato()
    {
        Console.Clear();
        Console.WriteLine("--- REMOVER CONTATO ---\n");
        Console.Write("Digite o email do contato a ser removido: ");
        string email = Console.ReadLine();

        Contato contatoParaRemover = new Contato(email);

        if (agenda.remover(contatoParaRemover))
        {
            Console.WriteLine("\nContato removido com sucesso!");
        }
        else
        {
            Console.WriteLine("\nContato não encontrado.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    static void listarContatos()
    {
        Console.Clear();
        Console.WriteLine("--- LISTA DE CONTATOS ---\n");

        if (agenda.Agenda.Count > 0)
        {
            foreach (var contato in agenda.Agenda)
            {
                Console.WriteLine(contato.ToString());
                Console.WriteLine("---------------------------");
            }
        }
        else
        {
            Console.WriteLine("Nenhum contato cadastrado.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}