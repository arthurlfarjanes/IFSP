using ProjFilaMedicamentos;
using System;

class Program
{
    static Medicamentos cadastroMedicamentos = new Medicamentos();

    static void Main(string[] args)
    {
        int opcao = -1;
        do
        {
            Console.Clear();
            Console.WriteLine("==== SISTEMA DE GESTÃO DE MEDICAMENTOS ====");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Cadastrar medicamento");
            Console.WriteLine("2. Consultar medicamento (sintético)");
            Console.WriteLine("3. Consultar medicamento (analítico)");
            Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
            Console.WriteLine("5. Vender medicamento");
            Console.WriteLine("6. Listar medicamentos");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 0: Console.WriteLine("Finalizando o programa..."); break;
                    case 1: CadastrarMedicamento(); break;
                    case 2: ConsultarSintetico(); break;
                    case 3: ConsultarAnalitico(); break;
                    case 4: ComprarMedicamento(); break;
                    case 5: VenderMedicamento(); break;
                    case 6: ListarMedicamentos(); break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida! Digite um número.");
            }
            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcao != 0);
    }

    static void CadastrarMedicamento()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Nome: "); string nome = Console.ReadLine();
        Console.Write("Laboratório: "); string lab = Console.ReadLine();
        cadastroMedicamentos.Adicionar(new Medicamento(id, nome, lab));
        Console.WriteLine("Medicamento cadastrado com sucesso!");
    }

    static void ConsultarSintetico()
    {
        Console.Write("ID do Medicamento: "); int id = int.Parse(Console.ReadLine());
        Medicamento med = cadastroMedicamentos.Pesquisar(new Medicamento { Id = id });
        if (med != null) Console.WriteLine(med.ToString());
        else Console.WriteLine("Medicamento não encontrado.");
    }

    static void ConsultarAnalitico()
    {
        Console.Write("ID do Medicamento: "); int id = int.Parse(Console.ReadLine());
        Medicamento med = cadastroMedicamentos.Pesquisar(new Medicamento { Id = id });
        if (med != null)
        {
            Console.WriteLine(med.ToString());
            foreach (Lote lote in med.Lotes) Console.WriteLine("  Lote: " + lote.ToString());
        }
        else Console.WriteLine("Medicamento não encontrado.");
    }

    static void ComprarMedicamento()
    {
        Console.Write("ID do Medicamento: "); int id = int.Parse(Console.ReadLine());
        Medicamento med = cadastroMedicamentos.Pesquisar(new Medicamento { Id = id });
        if (med != null)
        {
            Console.Write("ID Lote: "); int idLote = int.Parse(Console.ReadLine());
            Console.Write("Qtde: "); int qtde = int.Parse(Console.ReadLine());
            Console.Write("Vencimento (dd/mm/aaaa): "); DateTime venc = DateTime.Parse(Console.ReadLine());
            med.Comprar(new Lote(idLote, qtde, venc));
            Console.WriteLine("Compra registada!");
        }
        else Console.WriteLine("Medicamento não encontrado.");
    }

    static void VenderMedicamento()
    {
        Console.Write("ID do Medicamento: "); int id = int.Parse(Console.ReadLine());
        Medicamento med = cadastroMedicamentos.Pesquisar(new Medicamento { Id = id });
        if (med != null)
        {
            Console.Write("Qtde a vender: "); int qtde = int.Parse(Console.ReadLine());
            if (med.Vender(qtde)) Console.WriteLine("Venda realizada!");
            else Console.WriteLine("Quantidade insuficiente.");
        }
        else Console.WriteLine("Medicamento não encontrado.");
    }

    static void ListarMedicamentos()
    {
        foreach (Medicamento med in cadastroMedicamentos.GetLista())
        {
            Console.WriteLine(med.ToString());
        }
    }
}