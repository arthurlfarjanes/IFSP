using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGerenciadorProjetos
{
    public class Tarefa
    {
        public int Id { get; private set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public string Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataConclusao { get; private set; }

        public Tarefa(int id, string titulo, string descricao, int prioridade)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = "Aberta";
            DataCriacao = DateTime.Now;
            DataConclusao = null;
        }

        public void Concluir()
        {
            Status = "Fechada";
            DataConclusao = DateTime.Now;
        }

        public void Cancelar()
        {
            Status = "Cancelada";
        }

        public void Reabrir()
        {
            Status = "Aberta";
            DataConclusao = null;
        }

        public override string ToString()
        {
            string prioridadeStr = Prioridade == 1 ? "Alta" : (Prioridade == 2 ? "Média" : "Baixa");
            string dataConclusaoStr = DataConclusao.HasValue ? DataConclusao.Value.ToShortDateString() : "Pendente";
            return $"ID: {Id} | Título: {Titulo} | Status: {Status} | Prioridade: {prioridadeStr}\n   Criação: {DataCriacao.ToShortDateString()} | Conclusão: {dataConclusaoStr}\n   Descrição: {Descricao}\n";
        }
    }
}
