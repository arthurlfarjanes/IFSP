using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGerenciadorProjetos
{
    public class Projeto
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public List<Tarefa> Tarefas { get; private set; }

        public Projeto(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Tarefas = new List<Tarefa>(); 
        }

        public void AdicionarTarefa(Tarefa t) => Tarefas.Add(t);
        public bool RemoverTarefa(Tarefa t) => Tarefas.Remove(t);
        public Tarefa BuscarTarefa(int id) => Tarefas.FirstOrDefault(t => t.Id == id);
        public List<Tarefa> TarefasPorStatus(string s) => Tarefas.FindAll(t => t.Status.Equals(s, StringComparison.OrdinalIgnoreCase));
        public List<Tarefa> TarefasPorPrioridade(int p) => Tarefas.FindAll(t => t.Prioridade == p);

        public int TotalAbertas() => Tarefas.Count(t => t.Status == "Aberta");
        public int TotalFechadas() => Tarefas.Count(t => t.Status == "Fechada");

        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Quantidade de Tarefas: {Tarefas.Count}";
        }
    }
}
