using System;
using System.Linq;

public class Aluno
{
    private static int proximoId = 1;
    public int Id { get; private set; }
    public string Nome { get; private set; }

    private Disciplina[] disciplinasMatriculadas = new Disciplina[6];
    private Curso cursoMatriculado = null;

    public Aluno(string nome)
    {
        this.Id = proximoId++;
        this.Nome = nome;
    }

    public bool PodeMatricular(Disciplina disciplina)
    {
        int countDisciplinas = 0;
        for (int i = 0; i < disciplinasMatriculadas.Length; i++)
        {
            if (disciplinasMatriculadas[i] != null)
            {
                countDisciplinas++;
            }
        }
        if (countDisciplinas >= 6)
        {
            Console.WriteLine("Erro: Aluno já está no número máximo de 6 disciplinas.");
            return false;
        }

        if (this.cursoMatriculado != null && this.cursoMatriculado != disciplina.GetCurso())
        {
            Console.WriteLine($"Erro: Aluno já está matriculado no curso '{this.cursoMatriculado.Descricao}' e não pode se inscrever em disciplinas de outros cursos.");
            return false;
        }

        return true;
    }

    public void AdicionarDisciplina(Disciplina disciplina)
    {
        for (int i = 0; i < disciplinasMatriculadas.Length; i++)
        {
            if (disciplinasMatriculadas[i] == null)
            {
                disciplinasMatriculadas[i] = disciplina;
                if (this.cursoMatriculado == null)
                {
                    this.cursoMatriculado = disciplina.GetCurso();
                }
                break;
            }
        }
    }

    public void RemoverDisciplina(Disciplina disciplina)
    {
        for (int i = 0; i < disciplinasMatriculadas.Length; i++)
        {
            if (disciplinasMatriculadas[i] != null && disciplinasMatriculadas[i].Id == disciplina.Id)
            {
                disciplinasMatriculadas[i] = null;
                break;
            }
        }
        
        bool temDisciplina = false;
        foreach(var d in disciplinasMatriculadas)
        {
            if (d != null)
            {
                temDisciplina = true;
                break;
            }
        }
        if(!temDisciplina)
        {
            this.cursoMatriculado = null;
        }
    }

    public Disciplina[] GetDisciplinasMatriculadas()
    {
        return disciplinasMatriculadas;
    }
}

public class Disciplina
{
    private static int proximoId = 1;
    public int Id { get; private set; }
    public string Descricao { get; private set; }
    private Aluno[] alunos = new Aluno[15];
    private Curso cursoPai; 

    public Disciplina(string descricao, Curso curso)
    {
        this.Id = proximoId++;
        this.Descricao = descricao;
        this.cursoPai = curso;
    }

    public bool MatricularAluno(Aluno aluno)
    {
        for (int i = 0; i < alunos.Length; i++)
        {
            if (alunos[i] == null)
            {
                alunos[i] = aluno;
                aluno.AdicionarDisciplina(this);
                return true;
            }
        }
        Console.WriteLine("Erro: Disciplina sem vagas!");
        return false;
    }

    public bool DesmatricularAluno(Aluno aluno)
    {
        for (int i = 0; i < alunos.Length; i++)
        {
            if (alunos[i] != null && alunos[i].Id == aluno.Id)
            {
                alunos[i] = null;
                aluno.RemoverDisciplina(this);
                return true;
            }
        }
        return false;
    }
    
    public Aluno[] GetAlunos()
    {
        return alunos;
    }

    public Curso GetCurso()
    {
        return cursoPai;
    }
    
    public bool TemAlunosMatriculados()
    {
        foreach(var aluno in alunos)
        {
            if (aluno != null) return true;
        }
        return false;
    }
}

public class Curso
{
    private static int proximoId = 1;
    public int Id { get; private set; }
    public string Descricao { get; private set; }
    private Disciplina[] disciplinas = new Disciplina[12];

    public Curso(string descricao)
    {
        this.Id = proximoId++;
        this.Descricao = descricao;
    }

    public bool AdicionarDisciplina(Disciplina disciplina)
    {
        for (int i = 0; i < disciplinas.Length; i++)
        {
            if (disciplinas[i] == null)
            {
                disciplinas[i] = disciplina;
                return true;
            }
        }
        Console.WriteLine("Erro: O curso já atingiu o limite de 12 disciplinas.");
        return false;
    }

    public Disciplina PesquisarDisciplina(int id)
    {
        foreach (var disciplina in disciplinas)
        {
            if (disciplina != null && disciplina.Id == id)
            {
                return disciplina;
            }
        }
        return null;
    }

    public bool RemoverDisciplina(Disciplina disciplina)
    {
        for (int i = 0; i < disciplinas.Length; i++)
        {
            if (disciplinas[i] != null && disciplinas[i].Id == disciplina.Id)
            {
                disciplinas[i] = null;
                return true;
            }
        }
        return false;
    }

    public Disciplina[] GetDisciplinas()
    {
        return disciplinas;
    }
    
    public bool TemDisciplinas()
    {
        foreach(var disciplina in disciplinas)
        {
            if (disciplina != null) return true;
        }
        return false;
    }
}

public class Escola
{
    private Curso[] cursos = new Curso[5];
    private Aluno[] todosOsAlunos = new Aluno[1000];

    public bool AdicionarCurso(Curso curso)
    {
        for (int i = 0; i < cursos.Length; i++)
        {
            if (cursos[i] == null)
            {
                cursos[i] = curso;
                return true;
            }
        }
        Console.WriteLine("Erro: A escola já atingiu o limite de 5 cursos.");
        return false;
    }

    public Curso PesquisarCurso(int id)
    {
        foreach (var curso in cursos)
        {
            if (curso != null && curso.Id == id)
            {
                return curso;
            }
        }
        return null;
    }

    public bool RemoverCurso(Curso curso)
    {
        for (int i = 0; i < cursos.Length; i++)
        {
            if (cursos[i] != null && cursos[i].Id == curso.Id)
            {
                cursos[i] = null;
                return true;
            }
        }
        return false;
    }

    public void AdicionarAlunoNaEscola(Aluno aluno)
    {
        for (int i = 0; i < todosOsAlunos.Length; i++)
        {
            if (todosOsAlunos[i] == null)
            {
                todosOsAlunos[i] = aluno;
                break;
            }
        }
    }
    
    public Aluno PesquisarAluno(int id)
    {
        foreach (var aluno in todosOsAlunos)
        {
            if (aluno != null && aluno.Id == id)
            {
                return aluno;
            }
        }
        return null;
    }

    public Curso[] GetCursos()
    {
        return cursos;
    }
}

public class Program
{
    static Escola minhaEscola = new Escola();

    public static void Main(string[] args)
    {
        int opcao = -1;

        while (opcao != 0)
        {
            ExibirMenu();
            try
            {
                opcao = int.Parse(Console.ReadLine());
                ExecutarOpcao(opcao);
            }
            catch (Exception)
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
            }
            
            if(opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("==     SISTEMA DE GESTÃO ESCOLAR    ==");
        Console.WriteLine("========================================");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Adicionar curso");
        Console.WriteLine("2. Pesquisar curso");
        Console.WriteLine("3. Remover curso");
        Console.WriteLine("4. Adicionar disciplina no curso");
        Console.WriteLine("5. Pesquisar disciplina");
        Console.WriteLine("6. Remover disciplina do curso");
        Console.WriteLine("7. Matricular aluno na disciplina");
        Console.WriteLine("8. Remover aluno da disciplina");
        Console.WriteLine("9. Pesquisar aluno");
        Console.WriteLine("----------------------------------------");
        Console.Write("Digite a sua opção: ");
    }

    static void ExecutarOpcao(int opcao)
    {
        switch (opcao)
        {
            case 0:
                Console.WriteLine("Saindo do sistema. Até logo!");
                break;
            case 1:
                AdicionarCurso();
                break;
            case 2:
                PesquisarCurso();
                break;
            case 3:
                RemoverCurso();
                break;
            case 4:
                AdicionarDisciplina();
                break;
            case 5:
                PesquisarDisciplina();
                break;
            case 6:
                RemoverDisciplina();
                break;
            case 7:
                MatricularAluno();
                break;
            case 8:
                RemoverAluno();
                break;
            case 9:
                PesquisarAluno();
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
  
    static void AdicionarCurso()
    {
        Console.Write("Digite o nome do curso: ");
        string nome = Console.ReadLine();
        if (minhaEscola.AdicionarCurso(new Curso(nome)))
        {
            Console.WriteLine("Curso adicionado com sucesso!");
        }
    }

    static void PesquisarCurso()
    {
        Console.Write("Digite o ID do curso a pesquisar: ");
        int id = int.Parse(Console.ReadLine());
        Curso curso = minhaEscola.PesquisarCurso(id);
        if (curso != null)
        {
            Console.WriteLine($"\n--- Dados do Curso ---");
            Console.WriteLine($"ID: {curso.Id}");
            Console.WriteLine($"Nome: {curso.Descricao}");
            Console.WriteLine("Disciplinas associadas:");
            bool encontrouDisciplina = false;
            foreach (var disciplina in curso.GetDisciplinas())
            {
                if (disciplina != null)
                {
                    Console.WriteLine($"  - ID: {disciplina.Id}, Nome: {disciplina.Descricao}");
                    encontrouDisciplina = true;
                }
            }
            if (!encontrouDisciplina)
            {
                Console.WriteLine("  Nenhuma disciplina cadastrada neste curso.");
            }
        }
        else
        {
            Console.WriteLine("Curso não encontrado!");
        }
    }

    static void RemoverCurso()
    {
        Console.Write("Digite o ID do curso a remover: ");
        int id = int.Parse(Console.ReadLine());
        Curso curso = minhaEscola.PesquisarCurso(id);
        if (curso != null)
        {
            if (curso.TemDisciplinas())
            {
                Console.WriteLine("Erro: Não é possível remover um curso que possui disciplinas.");
            }
            else
            {
                minhaEscola.RemoverCurso(curso);
                Console.WriteLine("Curso removido com sucesso!");
            }
        }
        else
        {
            Console.WriteLine("Curso não encontrado!");
        }
    }

    static void AdicionarDisciplina()
    {
        Console.Write("Digite o ID do curso onde a disciplina será adicionada: ");
        int idCurso = int.Parse(Console.ReadLine());
        Curso curso = minhaEscola.PesquisarCurso(idCurso);
        if (curso != null)
        {
            Console.Write("Digite o nome da nova disciplina: ");
            string nomeDisciplina = Console.ReadLine();
            Disciplina novaDisciplina = new Disciplina(nomeDisciplina, curso);
            if(curso.AdicionarDisciplina(novaDisciplina))
            {
                Console.WriteLine("Disciplina adicionada com sucesso!");
            }
        }
        else
        {
            Console.WriteLine("Curso não encontrado!");
        }
    }

    static void PesquisarDisciplina()
    {
        Console.Write("Digite o ID do curso: ");
        int idCurso = int.Parse(Console.ReadLine());
        Curso curso = minhaEscola.PesquisarCurso(idCurso);
        if (curso != null)
        {
            Console.Write("Digite o ID da disciplina a pesquisar: ");
            int idDisc = int.Parse(Console.ReadLine());
            Disciplina disc = curso.PesquisarDisciplina(idDisc);
            if (disc != null)
            {
                Console.WriteLine($"\n--- Dados da Disciplina ---");
                Console.WriteLine($"ID: {disc.Id}");
                Console.WriteLine($"Nome: {disc.Descricao}");
                Console.WriteLine($"Curso: {curso.Descricao}");
                Console.WriteLine("Alunos matriculados:");
                bool encontrouAluno = false;
                foreach (var aluno in disc.GetAlunos())
                {
                    if (aluno != null)
                    {
                        Console.WriteLine($"  - ID: {aluno.Id}, Nome: {aluno.Nome}");
                        encontrouAluno = true;
                    }
                }
                if (!encontrouAluno)
                {
                    Console.WriteLine("  Nenhum aluno matriculado nesta disciplina.");
                }
            }
            else
            {
                Console.WriteLine("Disciplina não encontrada neste curso!");
            }
        }
        else
        {
            Console.WriteLine("Curso não encontrado!");
        }
    }

    static void RemoverDisciplina()
    {
        Console.Write("Digite o ID do curso: ");
        int idCurso = int.Parse(Console.ReadLine());
        Curso curso = minhaEscola.PesquisarCurso(idCurso);
        if(curso != null)
        {
            Console.Write("Digite o ID da disciplina a ser removida: ");
            int idDisc = int.Parse(Console.ReadLine());
            Disciplina disc = curso.PesquisarDisciplina(idDisc);
            if (disc != null)
            {
                if (disc.TemAlunosMatriculados())
                {
                    Console.WriteLine("Erro: Não é possível remover uma disciplina que possui alunos matriculados.");
                }
                else
                {
                    curso.RemoverDisciplina(disc);
                    Console.WriteLine("Disciplina removida com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Disciplina não encontrada!");
            }
        }
        else
        {
            Console.WriteLine("Curso não encontrado!");
        }
    }
    
    static void MatricularAluno()
    {
        Console.Write("Digite o ID do curso: ");
        int idCurso = int.Parse(Console.ReadLine());
        Curso curso = minhaEscola.PesquisarCurso(idCurso);

        if (curso == null)
        {
            Console.WriteLine("Curso não encontrado!");
            return;
        }

        Console.Write("Digite o ID da disciplina: ");
        int idDisc = int.Parse(Console.ReadLine());
        Disciplina disciplina = curso.PesquisarDisciplina(idDisc);

        if (disciplina == null)
        {
            Console.WriteLine("Disciplina não encontrada!");
            return;
        }

        Console.Write("Digite o ID do aluno (ou 0 para criar um novo aluno): ");
        int idAluno = int.Parse(Console.ReadLine());
        Aluno aluno;

        if (idAluno == 0)
        {
            Console.Write("Digite o nome do novo aluno: ");
            string nomeAluno = Console.ReadLine();
            aluno = new Aluno(nomeAluno);
            minhaEscola.AdicionarAlunoNaEscola(aluno);
            Console.WriteLine($"Aluno {aluno.Nome} criado com ID {aluno.Id}.");
        }
        else
        {
            aluno = minhaEscola.PesquisarAluno(idAluno);
        }

        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado!");
            return;
        }

        if(aluno.PodeMatricular(disciplina))
        {
            if(disciplina.MatricularAluno(aluno))
            {
                Console.WriteLine("Matrícula realizada com sucesso!");
            }
        }
    }

    static void RemoverAluno()
    {
        Console.Write("Digite o ID do curso: ");
        int idCurso = int.Parse(Console.ReadLine());
        Curso curso = minhaEscola.PesquisarCurso(idCurso);

        if (curso == null)
        {
            Console.WriteLine("Curso não encontrado!");
            return;
        }

        Console.Write("Digite o ID da disciplina: ");
        int idDisc = int.Parse(Console.ReadLine());
        Disciplina disciplina = curso.PesquisarDisciplina(idDisc);

        if (disciplina == null)
        {
            Console.WriteLine("Disciplina não encontrada!");
            return;
        }

        Console.Write("Digite o ID do aluno a ser removido da disciplina: ");
        int idAluno = int.Parse(Console.ReadLine());
        Aluno aluno = minhaEscola.PesquisarAluno(idAluno);

        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado!");
            return;
        }

        if(disciplina.DesmatricularAluno(aluno))
        {
            Console.WriteLine("Aluno removido da disciplina com sucesso!");
        }
        else
        {
            Console.WriteLine("Erro: Aluno não estava matriculado nesta disciplina.");
        }
    }

    static void PesquisarAluno()
    {
        Console.Write("Digite o ID do aluno: ");
        int idAluno = int.Parse(Console.ReadLine());
        Aluno aluno = minhaEscola.PesquisarAluno(idAluno);

        if (aluno != null)
        {
            Console.WriteLine($"\n--- Dados do Aluno ---");
            Console.WriteLine($"ID: {aluno.Id}");
            Console.WriteLine($"Nome: {aluno.Nome}");
            Console.WriteLine("Disciplinas em que está matriculado:");

            bool encontrouDisciplina = false;
            foreach (var disciplina in aluno.GetDisciplinasMatriculadas())
            {
                if (disciplina != null)
                {
                    Console.WriteLine($"  - ID: {disciplina.Id}, Nome: {disciplina.Descricao} (Curso: {disciplina.GetCurso().Descricao})");
                    encontrouDisciplina = true;
                }
            }

            if (!encontrouDisciplina)
            {
                Console.WriteLine("  O aluno não está matriculado em nenhuma disciplina.");
            }
        }
        else
        {
            Console.WriteLine("Aluno não encontrado!");
        }
    }
}