using ProjListBiblioteca;
using System;
using System.Linq;

class Program
{
    static Livros minhaBiblioteca = new Livros();

    static void Main(string[] args)
    {
        int opcao = -1;

        while (opcao != 0)
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|       GESTÃO DE BIBLIOTECA       |");
            Console.WriteLine("======================================");
            Console.WriteLine("| 0. Sair                            |");
            Console.WriteLine("| 1. Adicionar livro                 |");
            Console.WriteLine("| 2. Pesquisar livro (sintético)     |");
            Console.WriteLine("| 3. Pesquisar livro (analítico)     |");
            Console.WriteLine("| 4. Adicionar exemplar              |");
            Console.WriteLine("| 5. Registrar empréstimo            |");
            Console.WriteLine("| 6. Registrar devolução             |");
            Console.WriteLine("======================================");
            Console.Write("Digite a opção desejada: ");

            try
            {
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        AdicionarLivro();
                        break;
                    case 2:
                        PesquisarLivroSintetico();
                        break;
                    case 3:
                        PesquisarLivroAnalitico();
                        break;
                    case 4:
                        AdicionarExemplar();
                        break;
                    case 5:
                        RegistrarEmprestimo();
                        break;
                    case 6:
                        RegistrarDevolucao();
                        break;
                    case 0:
                        Console.WriteLine("\nSaindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Tente novamente.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nEntrada inválida. Por favor, digite um número.");
                opcao = -1;
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void AdicionarLivro()
    {
        Console.WriteLine("\n--- Adicionar Novo Livro ---");
        Console.Write("Digite o ISBN: ");
        int isbn = int.Parse(Console.ReadLine());

        if (minhaBiblioteca.pesquisar(isbn) != null)
        {
            Console.WriteLine("ERRO: Já existe um livro cadastrado com este ISBN.");
            return;
        }

        Console.Write("Digite o Título: ");
        string titulo = Console.ReadLine();
        Console.Write("Digite o Autor: ");
        string autor = Console.ReadLine();
        Console.Write("Digite a Editora: ");
        string editora = Console.ReadLine();

        Livro novoLivro = new Livro(isbn, titulo, autor, editora);
        minhaBiblioteca.adicionar(novoLivro);

        Console.WriteLine("\nLivro adicionado com sucesso!");
    }

    static void PesquisarLivroSintetico()
    {
        Console.WriteLine("\n--- Pesquisa Sintética de Livro ---");
        Console.Write("Digite o ISBN do livro a pesquisar: ");
        int isbn = int.Parse(Console.ReadLine());

        Livro livroEncontrado = minhaBiblioteca.pesquisar(isbn);

        if (livroEncontrado != null)
        {
            ExibirDadosSinteticos(livroEncontrado);
        }
        else
        {
            Console.WriteLine("\nLivro não encontrado.");
        }
    }

    static void ExibirDadosSinteticos(Livro livro)
    {
        Console.WriteLine("\n--- Dados do Livro ---");
        Console.WriteLine($"Título: {livro.Titulo}");
        Console.WriteLine($"Autor: {livro.Autor}");
        Console.WriteLine($"Editora: {livro.Editora}");
        Console.WriteLine($"Total de Exemplares: {livro.qtdeExemplares()}");
        Console.WriteLine($"Exemplares Disponíveis: {livro.qtdeDisponiveis()}");
        Console.WriteLine($"Total de Empréstimos: {livro.qtdeEmprestimos()}");
        Console.WriteLine($"Percentual de Disponibilidade: {livro.percDisponibilidade():F2}%");
    }

    static void PesquisarLivroAnalitico()
    {
        Console.WriteLine("\n--- Pesquisa Analítica de Livro ---");
        Console.Write("Digite o ISBN do livro a pesquisar: ");
        int isbn = int.Parse(Console.ReadLine()); 

        Livro livroEncontrado = minhaBiblioteca.pesquisar(isbn);

        if (livroEncontrado != null)
        {
            ExibirDadosSinteticos(livroEncontrado);

            Console.WriteLine("\n--- Detalhes dos Exemplares ---");
            if (livroEncontrado.Exemplares.Count == 0)
            {
                Console.WriteLine("Este livro ainda não possui exemplares cadastrados.");
            }
            else
            {
                foreach (var exemplar in livroEncontrado.Exemplares)
                {
                    string status = exemplar.disponivel() ? "Disponível" : "Emprestado";
                    Console.WriteLine($"\nTombo: {exemplar.Tombo} ({status})");
                    Console.WriteLine($"  Total de Empréstimos deste exemplar: {exemplar.qtdeEmprestimos()}");

                    foreach (var emprestimo in exemplar.Emprestimos)
                    {
                        string dataDevolucao = emprestimo.DtDevolucao.HasValue
                            ? emprestimo.DtDevolucao.Value.ToString("g")
                            : "Pendente";
                        Console.WriteLine($"  - Emprestado em: {emprestimo.DtEmprestimo:g} | Devolvido em: {dataDevolucao}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("\nLivro não encontrado.");
        }
    }

    static void AdicionarExemplar()
    {
        Console.WriteLine("\n--- Adicionar Exemplar ---");
        Console.Write("Digite o ISBN do livro ao qual o exemplar pertence: ");
        int isbn = int.Parse(Console.ReadLine());

        Livro livroEncontrado = minhaBiblioteca.pesquisar(isbn);

        if (livroEncontrado != null)
        {
            Console.Write("Digite o número do Tombo para o novo exemplar: ");
            int tombo = int.Parse(Console.ReadLine());

            if (livroEncontrado.Exemplares.Any(e => e.Tombo == tombo))
            {
                Console.WriteLine("ERRO: Já existe um exemplar com este tombo para este livro.");
                return;
            }

            Exemplar novoExemplar = new Exemplar(tombo);
            livroEncontrado.adicionarExemplar(novoExemplar);

            Console.WriteLine("\nExemplar adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nLivro não encontrado. Não é possível adicionar o exemplar.");
        }
    }

    static void RegistrarEmprestimo()
    {
        Console.WriteLine("\n--- Registrar Empréstimo ---");
        Console.Write("Digite o ISBN do livro a ser emprestado: ");
        int isbn = int.Parse(Console.ReadLine());

        Livro livroEncontrado = minhaBiblioteca.pesquisar(isbn);

        if (livroEncontrado != null)
        {
            Exemplar exemplarParaEmprestar = livroEncontrado.Exemplares.FirstOrDefault(e => e.disponivel());

            if (exemplarParaEmprestar != null)
            {
                exemplarParaEmprestar.emprestar();
                Console.WriteLine($"\nEmpréstimo do exemplar com tombo '{exemplarParaEmprestar.Tombo}' registrado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNão há exemplares disponíveis deste livro para empréstimo.");
            }
        }
        else
        {
            Console.WriteLine("\nLivro não encontrado.");
        }
    }

    static void RegistrarDevolucao()
    {
        Console.WriteLine("\n--- Registrar Devolução ---");
        Console.Write("Digite o ISBN do livro a ser devolvido: ");
        int isbn = int.Parse(Console.ReadLine());

        Livro livroEncontrado = minhaBiblioteca.pesquisar(isbn);

        if (livroEncontrado != null)
        {
            Console.Write("Digite o Tombo do exemplar a ser devolvido: ");
            int tombo = int.Parse(Console.ReadLine());

            Exemplar exemplarParaDevolver = livroEncontrado.Exemplares.FirstOrDefault(e => e.Tombo == tombo && !e.disponivel());

            if (exemplarParaDevolver != null)
            {
                exemplarParaDevolver.devolver();
                Console.WriteLine($"\nDevolução do exemplar com tombo '{exemplarParaDevolver.Tombo}' registrada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nExemplar não encontrado ou já consta como devolvido.");
            }
        }
        else
        {
            Console.WriteLine("\nLivro não encontrado.");
        }
    }
}