using ProjAcessoDB;
using System;
using System.Linq;

namespace ProjAcessoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Cadastro.Download();

            Console.WriteLine("Bem-vindo ao Sistema de Controle de Acesso!");
            bool executando = true;

            while (executando)
            {
                MostrarMenu();
                int opcao = LerInteiro("Escolha uma opção: ");

                switch (opcao)
                {
                    case 0:
                        executando = false;
                        Cadastro.Upload();
                        Console.WriteLine("Saindo...");
                        break;
                    case 1:
                        CadastrarAmbiente();
                        break;
                    case 2:
                        ConsultarAmbiente();
                        break;
                    case 3:
                        ExcluirAmbiente();
                        break;
                    case 4:
                        CadastrarUsuario();
                        break;
                    case 5:
                        ConsultarUsuario();
                        break;
                    case 6:
                        ExcluirUsuario();
                        break;
                    case 7:
                        ConcederPermissao();
                        break;
                    case 8:
                        RevogarPermissao();
                        break;
                    case 9:
                        RegistrarAcesso();
                        break;
                    case 10:
                        ConsultarLogs();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Console.ResetColor();
                        break;
                }

                if (executando)
                {
                    Console.WriteLine("\nPressione Enter para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("--- MENU PRINCIPAL ---");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Cadastrar ambiente");
            Console.WriteLine("2. Consultar ambiente");
            Console.WriteLine("3. Excluir ambiente");
            Console.WriteLine("4. Cadastrar usuário");
            Console.WriteLine("5. Consultar usuário");
            Console.WriteLine("6. Excluir usuário");
            Console.WriteLine("7. Conceder permissão");
            Console.WriteLine("8. Revogar permissão");
            Console.WriteLine("9. Registrar acesso");
            Console.WriteLine("10. Consultar logs de acesso");
            Console.WriteLine("----------------------");
        }

        private static void CadastrarAmbiente()
        {
            Console.WriteLine("--- Cadastrar Ambiente ---");
            int id = LerInteiro("Digite o ID do ambiente: ");
            if (Cadastro.PesquisarAmbiente(id) != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Já existe um ambiente com este ID.");
                Console.ResetColor();
                return;
            }

            Console.Write("Digite o Nome do ambiente: ");
            string nome = Console.ReadLine();

            Ambiente novoAmbiente = new Ambiente(id, nome);
            Cadastro.AdicionarAmbiente(novoAmbiente);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ambiente cadastrado com sucesso!");
            Console.ResetColor();
        }

        private static void ConsultarAmbiente()
        {
            Console.WriteLine("--- Consultar Ambiente ---");
            int id = LerInteiro("Digite o ID do ambiente: ");
            Ambiente amb = Cadastro.PesquisarAmbiente(id);

            if (amb != null)
            {
                Console.WriteLine($"ID: {amb.Id}");
                Console.WriteLine($"Nome: {amb.Nome}");
                Console.WriteLine($"Nº de Logs Registrados (em memória): {amb.Logs.Count}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ambiente não encontrado.");
                Console.ResetColor();
            }
        }

        private static void ExcluirAmbiente()
        {
            Console.WriteLine("--- Excluir Ambiente ---");
            int id = LerInteiro("Digite o ID do ambiente: ");
            Ambiente amb = Cadastro.PesquisarAmbiente(id);

            if (amb != null)
            {
                if (Cadastro.RemoverAmbiente(amb))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ambiente removido com sucesso (e permissões associadas revogadas).");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro ao remover o ambiente.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ambiente não encontrado.");
                Console.ResetColor();
            }
        }

        private static void CadastrarUsuario()
        {
            Console.WriteLine("--- Cadastrar Usuário ---");
            int id = LerInteiro("Digite o ID do usuário: ");
            if (Cadastro.PesquisarUsuario(id) != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Já existe um usuário com este ID.");
                Console.ResetColor();
                return;
            }

            Console.Write("Digite o Nome do usuário: ");
            string nome = Console.ReadLine();

            Usuario novoUsuario = new Usuario(id, nome);
            Cadastro.AdicionarUsuario(novoUsuario);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuário cadastrado com sucesso!");
            Console.ResetColor();
        }

        private static void ConsultarUsuario()
        {
            Console.WriteLine("--- Consultar Usuário ---");
            int id = LerInteiro("Digite o ID do usuário: ");
            Usuario user = Cadastro.PesquisarUsuario(id);

            if (user != null)
            {
                Console.WriteLine($"ID: {user.Id}");
                Console.WriteLine($"Nome: {user.Nome}");
                Console.WriteLine("Permissões:");
                if (user.Ambientes.Count > 0)
                {
                    foreach (var amb in user.Ambientes)
                    {
                        Console.WriteLine($"  - {amb.Nome} (ID: {amb.Id})");
                    }
                }
                else
                {
                    Console.WriteLine("  (Nenhuma permissão concedida)");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Usuário não encontrado.");
                Console.ResetColor();
            }
        }

        private static void ExcluirUsuario()
        {
            Console.WriteLine("--- Excluir Usuário ---");
            int id = LerInteiro("Digite o ID do usuário: ");
            Usuario user = Cadastro.PesquisarUsuario(id);

            if (user != null)
            {
                if (Cadastro.RemoverUsuario(user))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Usuário removido com sucesso!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Usuário não pode ser removido pois possui permissões ativas.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Usuário não encontrado.");
                Console.ResetColor();
            }
        }

        private static void ConcederPermissao()
        {
            Console.WriteLine("--- Conceder Permissão ---");
            int idUsuario = LerInteiro("Digite o ID do Usuário: ");
            Usuario user = Cadastro.PesquisarUsuario(idUsuario);

            int idAmbiente = LerInteiro("Digite o ID do Ambiente: ");
            Ambiente amb = Cadastro.PesquisarAmbiente(idAmbiente);

            if (user == null || amb == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Usuário ou Ambiente não encontrado.");
                Console.ResetColor();
                return;
            }

            if (user.ConcederPermissao(amb))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Permissão concedida: Usuário '{user.Nome}' agora pode acessar '{amb.Nome}'.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Usuário já possuía essa permissão.");
                Console.ResetColor();
            }
        }

        private static void RevogarPermissao()
        {
            Console.WriteLine("--- Revogar Permissão ---");
            int idUsuario = LerInteiro("Digite o ID do Usuário: ");
            Usuario user = Cadastro.PesquisarUsuario(idUsuario);

            int idAmbiente = LerInteiro("Digite o ID do Ambiente: ");
            Ambiente amb = Cadastro.PesquisarAmbiente(idAmbiente);

            if (user == null || amb == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Usuário ou Ambiente não encontrado.");
                Console.ResetColor();
                return;
            }

            if (user.RevogarPermissao(amb))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Permissão revogada: Usuário '{user.Nome}' não pode mais acessar '{amb.Nome}'.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Usuário não possuía essa permissão.");
                Console.ResetColor();
            }
        }

        private static void RegistrarAcesso()
        {
            Console.WriteLine("--- Registrar Tentativa de Acesso ---");
            int idUsuario = LerInteiro("Digite o ID do Usuário: ");
            Usuario user = Cadastro.PesquisarUsuario(idUsuario);

            int idAmbiente = LerInteiro("Digite o ID do Ambiente: ");
            Ambiente amb = Cadastro.PesquisarAmbiente(idAmbiente);

            if (user == null || amb == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Usuário ou Ambiente não encontrado.");
                Console.ResetColor();
                return;
            }

            bool autorizado = user.Ambientes.Contains(amb);

            Log novoLog = new Log(user, autorizado);

            amb.RegistrarLog(novoLog);

            if (autorizado)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Acesso AUTORIZADO. Log registrado.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Acesso NEGADO. Log registrado.");
                Console.ResetColor();
            }
        }

        private static void ConsultarLogs()
        {
            Console.WriteLine("--- Consultar Logs de Acesso ---");
            int idAmbiente = LerInteiro("Digite o ID do Ambiente: ");
            Ambiente amb = Cadastro.PesquisarAmbiente(idAmbiente);

            if (amb == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ambiente não encontrado.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\nFiltrar por:");
            Console.WriteLine("1. Todos os logs");
            Console.WriteLine("2. Apenas Autorizados");
            Console.WriteLine("3. Apenas Negados");
            int filtro = LerInteiro("Escolha o filtro: ");

            var logsNaOrdem = amb.Logs.Reverse();
            int logsExibidos = 0;

            Console.WriteLine($"\n--- Exibindo Logs para: {amb.Nome} ---");

            foreach (var log in logsNaOrdem)
            {
                bool exibir = false;
                switch (filtro)
                {
                    case 1:
                        exibir = true;
                        break;
                    case 2:
                        if (log.TipoAcesso) exibir = true;
                        break;
                    case 3:
                        if (!log.TipoAcesso) exibir = true;
                        break;
                    default:
                        exibir = true;
                        break;
                }

                if (exibir)
                {
                    Console.WriteLine(log.ToString());
                    logsExibidos++;
                }
            }

            if (logsExibidos == 0)
            {
                Console.WriteLine("(Nenhum log encontrado para este filtro)");
            }
            Console.WriteLine("-----------------------------------");
        }

        private static int LerInteiro(string mensagem)
        {
            int resultado;
            while (true)
            {
                Console.Write(mensagem);
                string input = Console.ReadLine();
                if (int.TryParse(input, out resultado))
                {
                    return resultado;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                Console.ResetColor();
            }
        }
    }
}