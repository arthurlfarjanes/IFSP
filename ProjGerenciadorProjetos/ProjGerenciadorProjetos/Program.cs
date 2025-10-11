using ProjGerenciadorProjetos;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Projetos gerenciadorProjetos = new Projetos();
    static int proximoIdProjeto = 1;
    static int proximoIdTarefa = 1;  

    static void Main(string[] args)
    {
        while (true)
        {
            ExibirMenu();
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int opcao))
            {
                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Obrigado por usar o sistema. Até logo!");
                        return; 
                    case 1: AdicionarProjeto(); break;
                    case 2: PesquisarProjeto(); break;
                    case 3: RemoverProjeto(); break;
                    case 4: AdicionarTarefaEmProjeto(); break;
                    case 5: MudarStatusTarefa("concluir"); break;
                    case 6: MudarStatusTarefa("cancelar"); break;
                    case 7: MudarStatusTarefa("reabrir"); break;
                    case 8: ListarTarefasDeProjeto(); break;
                    case 9: FiltrarTarefasEmProjeto(); break;
                    case 10: FiltrarTarefasEmTodosProjetos(); break;
                    case 11: ResumoGeral(); break;
                    default:
                        Console.WriteLine("Opção inválida! Por favor, escolha um número do menu.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida! Por favor, digite um número.");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine("      Gerenciador de Projetos        ");
        Console.WriteLine("=====================================");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Adicionar projeto");
        Console.WriteLine("2. Pesquisar projeto (mostrar tarefas por status e totais)");
        Console.WriteLine("3. Remover projeto (apenas se sem tarefas)");
        Console.WriteLine("4. Adicionar tarefa em projeto");
        Console.WriteLine("5. Concluir tarefa");
        Console.WriteLine("6. Cancelar tarefa");
        Console.WriteLine("7. Reabrir tarefa");
        Console.WriteLine("8. Listar tarefas de um projeto");
        Console.WriteLine("9. Filtrar tarefas por status ou prioridade em um projeto");
        Console.WriteLine("10. Filtrar tarefas por status ou prioridade em todos os projetos");
        Console.WriteLine("11. Resumo geral");
        Console.Write("\nEscolha uma opção: ");
    }

    static void AdicionarProjeto()
    {
        Console.WriteLine("\n--- Adicionar Novo Projeto ---");
        Console.Write("Digite o nome do projeto: ");
        string nome = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Erro: O nome do projeto não pode ser vazio.");
            return;
        }

        Projeto novoProjeto = new Projeto(proximoIdProjeto++, nome);
        gerenciadorProjetos.Adicionar(novoProjeto);
        Console.WriteLine($"Projeto '{nome}' (ID: {novoProjeto.Id}) adicionado com sucesso!");
    }

    static void PesquisarProjeto()
    {
        Console.WriteLine("\n--- Pesquisar Projeto ---");
        Console.Write("Digite o ID do projeto: ");
        int.TryParse(Console.ReadLine(), out int id);
        Projeto projeto = gerenciadorProjetos.Buscar(id);

        if (projeto != null)
        {
            Console.WriteLine("\nResultado da Busca:");
            Console.WriteLine(projeto);
            Console.WriteLine($"  - Tarefas Abertas: {projeto.TotalAbertas()}");
            Console.WriteLine($"  - Tarefas Fechadas: {projeto.TotalFechadas()}");
        }
        else
        {
            Console.WriteLine("Projeto com o ID informado não foi encontrado.");
        }
    }

    static void RemoverProjeto()
    {
        Console.WriteLine("\n--- Remover Projeto ---");
        Console.Write("Digite o ID do projeto a ser removido: ");
        int.TryParse(Console.ReadLine(), out int id);
        Projeto projeto = gerenciadorProjetos.Buscar(id);

        if (projeto != null)
        {
            if (gerenciadorProjetos.Remover(projeto))
            {
                Console.WriteLine($"Projeto '{projeto.Nome}' removido com sucesso.");
            }
            else
            {
                Console.WriteLine($"Erro: O projeto '{projeto.Nome}' não pode ser removido pois contém tarefas.");
            }
        }
        else
        {
            Console.WriteLine("Projeto com o ID informado não foi encontrado.");
        }
    }

    static void AdicionarTarefaEmProjeto()
    {
        Console.WriteLine("\n--- Adicionar Tarefa em Projeto ---");
        Console.Write("Digite o ID do projeto: ");
        int.TryParse(Console.ReadLine(), out int idProjeto);
        Projeto projeto = gerenciadorProjetos.Buscar(idProjeto);

        if (projeto != null)
        {
            Console.Write("Título da nova tarefa: ");
            string titulo = Console.ReadLine();
            Console.Write("Descrição da tarefa: ");
            string descricao = Console.ReadLine();
            Console.Write("Prioridade (1=Alta, 2=Média, 3=Baixa): ");
            int.TryParse(Console.ReadLine(), out int prioridade);

            if (string.IsNullOrWhiteSpace(titulo) || (prioridade < 1 || prioridade > 3))
            {
                Console.WriteLine("Erro: Título e prioridade são obrigatórios e a prioridade deve ser 1, 2 ou 3.");
                return;
            }

            Tarefa novaTarefa = new Tarefa(proximoIdTarefa++, titulo, descricao, prioridade);
            projeto.AdicionarTarefa(novaTarefa);
            Console.WriteLine($"Tarefa '{titulo}' (ID: {novaTarefa.Id}) adicionada ao projeto '{projeto.Nome}'.");
        }
        else
        {
            Console.WriteLine("Projeto com o ID informado não foi encontrado.");
        }
    }

    static void MudarStatusTarefa(string acao)
    {
        Console.WriteLine($"\n--- {char.ToUpper(acao[0]) + acao.Substring(1)} Tarefa ---");
        Console.Write("Digite o ID da tarefa: ");
        int.TryParse(Console.ReadLine(), out int idTarefa);

        Tarefa tarefaEncontrada = null;
        foreach (var projeto in gerenciadorProjetos.Listar())
        {
            tarefaEncontrada = projeto.BuscarTarefa(idTarefa);
            if (tarefaEncontrada != null) break;
        }

        if (tarefaEncontrada != null)
        {
            switch (acao)
            {
                case "concluir": tarefaEncontrada.Concluir(); break;
                case "cancelar": tarefaEncontrada.Cancelar(); break;
                case "reabrir": tarefaEncontrada.Reabrir(); break;
            }
            Console.WriteLine($"Status da tarefa '{tarefaEncontrada.Titulo}' (ID: {tarefaEncontrada.Id}) foi alterado para '{tarefaEncontrada.Status}'.");
        }
        else
        {
            Console.WriteLine("Tarefa com o ID informado não foi encontrada em nenhum projeto.");
        }
    }

    static void ListarTarefasDeProjeto()
    {
        Console.WriteLine("\n--- Listar Tarefas de um Projeto ---");
        Console.Write("Digite o ID do projeto: ");
        int.TryParse(Console.ReadLine(), out int idProjeto);
        Projeto projeto = gerenciadorProjetos.Buscar(idProjeto);

        if (projeto != null)
        {
            Console.WriteLine($"\nExibindo tarefas do projeto: {projeto.Nome}");
            if (projeto.Tarefas.Any())
            {
                foreach (var tarefa in projeto.Tarefas)
                {
                    Console.WriteLine(tarefa);
                }
            }
            else
            {
                Console.WriteLine("Este projeto ainda não possui tarefas.");
            }
        }
        else
        {
            Console.WriteLine("Projeto com o ID informado não foi encontrado.");
        }
    }

    static void FiltrarTarefasEmProjeto()
    {
        Console.WriteLine("\n--- Filtrar Tarefas em um Projeto ---");
        Console.Write("Digite o ID do projeto: ");
        int.TryParse(Console.ReadLine(), out int idProjeto);
        Projeto projeto = gerenciadorProjetos.Buscar(idProjeto);

        if (projeto == null)
        {
            Console.WriteLine("Projeto não encontrado.");
            return;
        }

        Console.Write("Filtrar por (S)tatus ou (P)rioridade? ");
        string tipoFiltro = Console.ReadLine().ToUpper();

        List<Tarefa> tarefasFiltradas = new List<Tarefa>();

        if (tipoFiltro == "S")
        {
            Console.Write("Digite o Status (Aberta, Fechada, Cancelada): ");
            string status = Console.ReadLine();
            tarefasFiltradas = projeto.TarefasPorStatus(status);
        }
        else if (tipoFiltro == "P")
        {
            Console.Write("Digite a Prioridade (1, 2 ou 3): ");
            int.TryParse(Console.ReadLine(), out int prioridade);
            tarefasFiltradas = projeto.TarefasPorPrioridade(prioridade);
        }
        else
        {
            Console.WriteLine("Opção de filtro inválida.");
            return;
        }

        Console.WriteLine("\nResultado do Filtro:");
        if (tarefasFiltradas.Any())
        {
            tarefasFiltradas.ForEach(t => Console.WriteLine(t));
        }
        else
        {
            Console.WriteLine("Nenhuma tarefa encontrada com os critérios informados.");
        }
    }

    static void FiltrarTarefasEmTodosProjetos()
    {
        Console.WriteLine("\n--- Filtrar Tarefas em Todos os Projetos ---");
        Console.Write("Filtrar por (S)tatus ou (P)rioridade? ");
        string tipoFiltro = Console.ReadLine().ToUpper();

        List<Tarefa> tarefasFiltradas = new List<Tarefa>();

        if (tipoFiltro == "S")
        {
            Console.Write("Digite o Status (Aberta, Fechada, Cancelada): ");
            string status = Console.ReadLine();
            gerenciadorProjetos.Listar().ForEach(p => tarefasFiltradas.AddRange(p.TarefasPorStatus(status)));
        }
        else if (tipoFiltro == "P")
        {
            Console.Write("Digite a Prioridade (1, 2 ou 3): ");
            int.TryParse(Console.ReadLine(), out int prioridade);
            gerenciadorProjetos.Listar().ForEach(p => tarefasFiltradas.AddRange(p.TarefasPorPrioridade(prioridade)));
        }
        else
        {
            Console.WriteLine("Opção de filtro inválida.");
            return;
        }

        Console.WriteLine("\nResultado do Filtro Global:");
        if (tarefasFiltradas.Any())
        {
            tarefasFiltradas.ForEach(t => Console.WriteLine(t));
        }
        else
        {
            Console.WriteLine("Nenhuma tarefa encontrada com os critérios informados.");
        }
    }

    static void ResumoGeral()
    {
        Console.WriteLine("\n--- Resumo Geral do Sistema ---");

        int totalProjetos = gerenciadorProjetos.Listar().Count;
        int totalTarefasAbertas = gerenciadorProjetos.Listar().Sum(p => p.Tarefas.Count(t => t.Status == "Aberta"));
        int totalTarefasFechadas = gerenciadorProjetos.Listar().Sum(p => p.Tarefas.Count(t => t.Status == "Fechada"));
        int totalTarefasCanceladas = gerenciadorProjetos.Listar().Sum(p => p.Tarefas.Count(t => t.Status == "Cancelada"));

        Console.WriteLine($"Quantidade total de projetos: {totalProjetos}");
        Console.WriteLine($"Total de tarefas abertas: {totalTarefasAbertas}");
        Console.WriteLine($"Total de tarefas fechadas: {totalTarefasFechadas}");
        Console.WriteLine($"Total de tarefas canceladas: {totalTarefasCanceladas}");

        int baseCalculoPercentual = totalTarefasAbertas + totalTarefasFechadas;
        double percentualConcluidas = 0;

        if (baseCalculoPercentual > 0)
        {
            percentualConcluidas = (double)totalTarefasFechadas / baseCalculoPercentual * 100;
        }

        Console.WriteLine($"% de tarefas concluídas (em relação a abertas + fechadas): {percentualConcluidas:F2}%");
    }
}