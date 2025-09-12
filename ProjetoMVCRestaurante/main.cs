using System;

public class Item
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }

    public Item(int id, string descricao, double preco)
    {
        Id = id;
        Descricao = descricao;
        Preco = preco;
    }
}

public class Pedido
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    private Item[] itens;
    private int proximoItemIndex;

    public Pedido(int id, string cliente)
    {
        Id = id;
        Cliente = cliente;
        itens = new Item[10];
        proximoItemIndex = 0;
    }

    public bool AdicionarItem(Item item)
    {
        if (proximoItemIndex < itens.Length)
        {
            itens[proximoItemIndex] = item;
            proximoItemIndex++;
            return true;
        }
        return false;
    }

    public bool RemoverItem(int idDoItem)
    {
        for (int i = 0; i < proximoItemIndex; i++)
        {
            if (itens[i] != null && itens[i].Id == idDoItem)
            {
                for (int j = i; j < proximoItemIndex - 1; j++)
                {
                    itens[j] = itens[j + 1];
                }
                itens[proximoItemIndex - 1] = null;
                proximoItemIndex--;
                return true;
            }
        }
        return false;
    }

    public double CalcularTotal()
    {
        double total = 0;
        for (int i = 0; i < proximoItemIndex; i++)
        {
            if (itens[i] != null)
            {
                total = total + itens[i].Preco;
            }
        }
        return total;
    }
    
    public string DadosDoPedido()
    {
        string dados = "";
        dados += $"ID do Pedido: {Id}\n";
        dados += $"Cliente: {Cliente}\n";
        dados += "Itens:\n";
        
        for (int i = 0; i < proximoItemIndex; i++)
        {
            if (itens[i] != null)
            {
                dados += $"  - ID: {itens[i].Id}, Descrição: {itens[i].Descricao}, Preço: R$ {itens[i].Preco:F2}\n";
            }
        }

        dados += $"\nValor Total do Pedido: R$ {CalcularTotal():F2}";
        return dados;
    }
}

public class Restaurante
{
    private Pedido[] pedidos;
    private int proxPedido;

    public Restaurante()
    {
        pedidos = new Pedido[50];
        proxPedido = 0;
    }

    public bool NovoPedido(string nomeCliente)
    {
        if (proxPedido < pedidos.Length)
        {
            int novoId = proxPedido + 1;
            Pedido novoPedido = new Pedido(novoId, nomeCliente);
            pedidos[proxPedido] = novoPedido;
            proxPedido++;
            return true;
        }
        return false;
    }

    public Pedido BuscarPedido(int id)
    {
        int index = id - 1;
        if (index >= 0 && index < proxPedido && pedidos[index] != null)
        {
            return pedidos[index];
        }
        return null;
    }

    public bool CancelarPedido(int id)
    {
        int index = id - 1;
        if (index >= 0 && index < proxPedido && pedidos[index] != null)
        {
            pedidos[index] = null;
            return true;
        }
        return false;
    }

    public Pedido[] ListarPedidos()
    {
        return pedidos;
    }
}

public class ConsoleView
{
    public void ExibirMenu()
    {
        Console.WriteLine("\n--- Sistema de Gestão de Restaurante ---");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Criar novo pedido");
        Console.WriteLine("2. Adicionar item ao pedido");
        Console.WriteLine("3. Remover item do pedido");
        Console.WriteLine("4. Consultar pedido");
        Console.WriteLine("5. Cancelar pedido");
        Console.WriteLine("6. Listar todos os pedidos do dia");
        Console.Write("Escolha uma opção: ");
    }
    
    public string LerOpcao()
    {
        return Console.ReadLine();
    }
    
    public string ObterNomeCliente()
    {
        Console.Write("Digite o nome do cliente: ");
        return Console.ReadLine();
    }

    public int ObterIdPedido()
    {
        Console.Write("Digite o ID do pedido: ");
        int.TryParse(Console.ReadLine(), out int id);
        return id;
    }

    public int ObterIdItem()
    {
        Console.Write("Digite o ID do item a ser removido: ");
        int.TryParse(Console.ReadLine(), out int id);
        return id;
    }
    
    public Item ObterDadosNovoItem()
    {
        Console.Write("Digite o ID do item do cardápio: ");
        int.TryParse(Console.ReadLine(), out int id);
        Console.Write("Digite a descrição do item: ");
        string descricao = Console.ReadLine();
        Console.Write("Digite o preço do item: ");
        double.TryParse(Console.ReadLine(), out double preco);
        return new Item(id, descricao, preco);
    }

    public void ExibirDetalhesPedido(string dadosDoPedido)
    {
        Console.WriteLine("\n--- Detalhes do Pedido ---");
        Console.WriteLine(dadosDoPedido);
    }

    public void ListarTodosPedidos(Pedido[] pedidos)
    {
        Console.WriteLine("\n--- Histórico de Pedidos do Dia ---");
        double somaGeral = 0;
        bool encontrouPedido = false;

        foreach (var pedido in pedidos)
        {
            if (pedido != null)
            {
                encontrouPedido = true;
                double totalPedido = pedido.CalcularTotal();
                somaGeral += totalPedido;
                Console.WriteLine($"ID: {pedido.Id}, Cliente: {pedido.Cliente}, Valor Total: R$ {totalPedido:F2}");
            }
        }
        if (encontrouPedido == false)
        {
            Console.WriteLine("Nenhum pedido registrado hoje.");
        }
        else
        {
             Console.WriteLine($"\nSOMA GERAL DO DIA: R$ {somaGeral:F2}");
        }
    }
    
    public void ExibirMensagem(string mensagem)
    {
        Console.WriteLine(mensagem);
    }
}

public class RestauranteController
{
    private Restaurante model;
    private ConsoleView view;

    public RestauranteController()
    {
        model = new Restaurante();
        view = new ConsoleView();
    }

    public void Iniciar()
    {
        bool executando = true;
        while (executando)
        {
            view.ExibirMenu();
            string opcao = view.LerOpcao();
            switch (opcao)
            {
                case "0": executando = false; view.ExibirMensagem("Saindo..."); break;
                case "1": CriarNovoPedido(); break;
                case "2": AdicionarItemAoPedido(); break;
                case "3": RemoverItemDoPedido(); break;
                case "4": ConsultarPedido(); break;
                case "5": CancelarPedido(); break;
                case "6": ListarPedidos(); break;
                default: view.ExibirMensagem("Opção inválida."); break;
            }
        }
    }

    private void CriarNovoPedido()
    {
        string nomeCliente = view.ObterNomeCliente();
        bool sucesso = model.NovoPedido(nomeCliente);
        
        view.ExibirMensagem(sucesso ? "Pedido criado com sucesso!" : "Erro: Limite de pedidos diários atingido.");
    }

    private void AdicionarItemAoPedido()
    {
        int idPedido = view.ObterIdPedido();
        Pedido pedido = model.BuscarPedido(idPedido);
        if (pedido != null)
        {
            Item novoItem = view.ObterDadosNovoItem();
            bool sucesso = pedido.AdicionarItem(novoItem);
            
            view.ExibirMensagem(sucesso ? "Item adicionado com sucesso!" : "Erro: Limite de itens no pedido atingido.");
        }
        else
        {
            view.ExibirMensagem("Erro: Pedido não encontrado.");
        }
    }
    
    private void RemoverItemDoPedido()
    {
        int idPedido = view.ObterIdPedido();
        Pedido pedido = model.BuscarPedido(idPedido);
        if (pedido != null)
        {
            int idItem = view.ObterIdItem();
            bool sucesso = pedido.RemoverItem(idItem);
            
            view.ExibirMensagem(sucesso ? "Item removido com sucesso!" : "Erro: Item não encontrado no pedido.");
        }
        else
        {
            view.ExibirMensagem("Erro: Pedido não encontrado.");
        }
    }

    private void ConsultarPedido()
    {
        int idPedido = view.ObterIdPedido();
        Pedido pedido = model.BuscarPedido(idPedido);
        if (pedido != null)
        {
            view.ExibirDetalhesPedido(pedido.DadosDoPedido());
        }
        else
        {
            view.ExibirMensagem("Erro: Pedido não encontrado.");
        }
    }

    private void CancelarPedido()
    {
        int idPedido = view.ObterIdPedido();
        bool sucesso = model.CancelarPedido(idPedido);
        
        view.ExibirMensagem(sucesso ? "Pedido cancelado com sucesso." : "Erro: Pedido não encontrado.");
    }

    private void ListarPedidos()
    {
        var pedidos = model.ListarPedidos();
        view.ListarTodosPedidos(pedidos);
    }
}

class Program
{
    static void Main(string[] args)
    {
        RestauranteController controller = new RestauranteController();
        controller.Iniciar();
    }
}