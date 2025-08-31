using System;
using System.Globalization;

// CLASSE VENDA
public class Venda
{
    public int Qtde { get; set; }
    public double Valor { get; set; }

    public Venda(int qtde, double valor)
    {
        this.Qtde = qtde;
        this.Valor = valor;
    }

    public Venda() : this(0, 0.0) { }

    public double ValorMedio()
    {
        if (this.Qtde == 0)
        {
            return 0.0;
        }
        return this.Valor / this.Qtde;
    }
}

// CLASSE VENDEDOR
public class Vendedor
{
    public int Id { get; private set; }
    public string Nome { get; set; }
    public double PercComissao { get; set; }
    private Venda[] asVendas;

    public Vendedor(int id, string nome, double percComissao)
    {
        this.Id = id;
        this.Nome = nome;
        this.PercComissao = percComissao;
        this.asVendas = new Venda[31];
        for (int i = 0; i < 31; i++)
        {
            asVendas[i] = new Venda();
        }
    }

    public Vendedor(int id)
    {
        this.Id = id;
    }

    public void RegistrarVenda(int dia, Venda venda)
    {
        if (dia >= 1 && dia <= 31)
        {
            asVendas[dia - 1] = venda;
        }
    }

    public double ValorVendas()
    {
        double total = 0;
        foreach (Venda v in asVendas)
        {
            total += v.Valor;
        }
        return total;
    }

    public double ValorComissao()
    {
        return ValorVendas() * (PercComissao / 100.0);
    }
    
    public bool TemVendas()
    {
        return this.ValorVendas() > 0;
    }

    public double ValorMedioVendasDiarias()
    {
        double valorTotal = this.ValorVendas();
        int diasComVenda = 0;

        foreach (Venda v in asVendas)
        {
            if (v.Valor > 0)
            {
                diasComVenda++;
            }
        }

        return diasComVenda == 0 ? 0 : valorTotal / diasComVenda;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Vendedor outro = (Vendedor)obj;
        return this.Id == outro.Id;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}

// CLASSE VENDEDORES (GERENCIADOR)
public class Vendedores
{
    private Vendedor[] osVendedores;
    private const int MAX_VENDEDORES = 10;
    private int qtde;
    
    public int Qtde { get => qtde; }
    public Vendedor[] ListaVendedores { get => osVendedores; }

    public Vendedores()
    {
        osVendedores = new Vendedor[MAX_VENDEDORES];
        qtde = 0;
    }

    public bool AddVendedor(Vendedor v)
    {
        if (qtde >= MAX_VENDEDORES || SearchVendedor(v) != null)
        {
            return false; 
        }
        osVendedores[qtde] = v;
        qtde++;
        return true;
    }
    
    private int FindIndex(Vendedor v)
    {
        for (int i = 0; i < qtde; i++)
        {
            if (osVendedores[i].Equals(v))
            {
                return i;
            }
        }
        return -1;
    }

    public bool DelVendedor(Vendedor v)
    {
        int index = FindIndex(v);
        if (index == -1)
        {
            return false;
        }

        if (osVendedores[index].TemVendas())
        {
            return false;
        }

        for (int i = index; i < qtde - 1; i++)
        {
            osVendedores[i] = osVendedores[i + 1];
        }

        osVendedores[qtde - 1] = null;
        qtde--;
        return true;
    }

    public Vendedor SearchVendedor(Vendedor v)
    {
        foreach (Vendedor vendedor in osVendedores)
        {
            if (vendedor != null && vendedor.Equals(v))
            {
                return vendedor;
            }
        }
        return null;
    }

    public double ValorVendas()
    {
        double total = 0;
        for (int i = 0; i < qtde; i++)
        {
            total += osVendedores[i].ValorVendas();
        }
        return total;
    }

    public double ValorComissao()
    {
        double total = 0;
        for (int i = 0; i < qtde; i++)
        {
            total += osVendedores[i].ValorComissao();
        }
        return total;
    }
}

// CLASSE PRINCIPAL
class Program
{
    static Vendedores todosVendedores = new Vendedores();

    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
        
        int opcao = -1;
        while (opcao != 0)
        {
            ExibirMenu();
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.Clear();
                switch (opcao)
                {
                    case 1: CadastrarVendedor(); break;
                    case 2: ConsultarVendedor(); break;
                    case 3: ExcluirVendedor(); break;
                    case 4: RegistrarVenda(); break;
                    case 5: ListarVendedores(); break;
                    case 0: Console.WriteLine("Saindo do sistema..."); break;
                    default: Console.WriteLine("Opção inválida. Tente novamente."); break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Entrada inválida. Por favor, digite um número.");
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void ExibirMenu()
    {
        Console.WriteLine("========= MENU DE OPÇÕES =========");
        Console.WriteLine("1. Cadastrar vendedor");
        Console.WriteLine("2. Consultar vendedor");
        Console.WriteLine("3. Excluir vendedor");
        Console.WriteLine("4. Registrar venda");
        Console.WriteLine("5. Listar vendedores");
        Console.WriteLine("0. Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void CadastrarVendedor()
    {
        Console.WriteLine("--- Cadastrar Vendedor ---");
        if (todosVendedores.Qtde >= 10)
        {
            Console.WriteLine("ERRO: Limite de 10 vendedores atingido!");
            return;
        }

        Console.Write("ID do vendedor: ");
        if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        if (todosVendedores.SearchVendedor(new Vendedor(id)) != null)
        {
            Console.WriteLine("ERRO: Já existe um vendedor com este ID.");
            return;
        }

        Console.Write("Nome do vendedor: ");
        string nome = Console.ReadLine();

        Console.Write("Percentual de comissão (ex: 5 para 5%): ");
        if (!double.TryParse(Console.ReadLine(), out double percComissao) || percComissao < 0)
        {
             Console.WriteLine("Percentual de comissão inválido.");
            return;
        }

        Vendedor novoVendedor = new Vendedor(id, nome, percComissao);
        if (todosVendedores.AddVendedor(novoVendedor))
        {
            Console.WriteLine("Vendedor cadastrado com sucesso!");
        }
    }

    static void ConsultarVendedor()
    {
        Console.WriteLine("--- Consultar Vendedor ---");
        Console.Write("Digite o ID do vendedor a consultar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }
        
        Vendedor vendedorEncontrado = todosVendedores.SearchVendedor(new Vendedor(id));

        if (vendedorEncontrado != null)
        {
            Console.WriteLine("\n--- Dados do Vendedor ---");
            Console.WriteLine($"ID: {vendedorEncontrado.Id}");
            Console.WriteLine($"Nome: {vendedorEncontrado.Nome}");
            Console.WriteLine($"Total de Vendas: {vendedorEncontrado.ValorVendas():C}");
            Console.WriteLine($"Valor da Comissão: {vendedorEncontrado.ValorComissao():C}");
            Console.WriteLine($"Valor Médio das Vendas Diárias: {vendedorEncontrado.ValorMedioVendasDiarias():C}");
        }
        else
        {
            Console.WriteLine("Vendedor não encontrado.");
        }
    }

    static void ExcluirVendedor()
    {
        Console.WriteLine("--- Excluir Vendedor ---");
        Console.Write("Digite o ID do vendedor a excluir: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }
        
        Vendedor vendedorParaExcluir = new Vendedor(id);
        Vendedor vendedorEncontrado = todosVendedores.SearchVendedor(vendedorParaExcluir);

        if (vendedorEncontrado == null)
        {
            Console.WriteLine("Vendedor não encontrado.");
            return;
        }

        if (vendedorEncontrado.TemVendas())
        {
            Console.WriteLine("ERRO: Vendedor possui vendas registradas e não pode ser excluído.");
            return;
        }

        if (todosVendedores.DelVendedor(vendedorParaExcluir))
        {
            Console.WriteLine("Vendedor excluído com sucesso!");
        }
    }

    static void RegistrarVenda()
    {
        Console.WriteLine("--- Registrar Venda ---");
        Console.Write("Digite o ID do vendedor: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        Vendedor vendedorEncontrado = todosVendedores.SearchVendedor(new Vendedor(id));

        if (vendedorEncontrado == null)
        {
            Console.WriteLine("Vendedor não encontrado.");
            return;
        }

        Console.Write($"Registrando venda para {vendedorEncontrado.Nome}.\n");
        Console.Write("Digite o dia do mês (1-31): ");
        if (!int.TryParse(Console.ReadLine(), out int dia) || dia < 1 || dia > 31)
        {
            Console.WriteLine("Dia inválido.");
            return;
        }
        
        Console.Write("Digite a quantidade de vendas: ");
        if (!int.TryParse(Console.ReadLine(), out int qtde) || qtde < 0)
        {
             Console.WriteLine("Quantidade inválida.");
            return;
        }

        Console.Write("Digite o valor total das vendas: ");
        if (!double.TryParse(Console.ReadLine(), out double valor) || valor < 0)
        {
            Console.WriteLine("Valor inválido.");
            return;
        }

        Venda novaVenda = new Venda(qtde, valor);
        vendedorEncontrado.RegistrarVenda(dia, novaVenda);

        Console.WriteLine("Venda registrada com sucesso!");
    }

    static void ListarVendedores()
    {
        Console.WriteLine("--- Lista de Vendedores ---");
        if (todosVendedores.Qtde == 0)
        {
            Console.WriteLine("Nenhum vendedor cadastrado.");
            return;
        }

        Vendedor[] lista = todosVendedores.ListaVendedores;
        for (int i = 0; i < todosVendedores.Qtde; i++)
        {
            Vendedor v = lista[i];
            Console.WriteLine($"ID: {v.Id} | Nome: {v.Nome}");
            Console.WriteLine($"  Total de Vendas: {v.ValorVendas():C}");
            Console.WriteLine($"  Valor da Comissão: {v.ValorComissao():C}");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine("\n--- TOTAIS DA EQUIPE ---");
        Console.WriteLine($"Valor Total Geral de Vendas: {todosVendedores.ValorVendas():C}");
        Console.WriteLine($"Valor Total Geral de Comissão: {todosVendedores.ValorComissao():C}");
    }
}