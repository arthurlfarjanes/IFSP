using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGerenciadorProjetos
{
    public class Projetos
    {
        public List<Projeto> Itens { get; private set; }

        public Projetos()
        {
            Itens = new List<Projeto>();
        }

        public void Adicionar(Projeto p) => Itens.Add(p);

        public bool Remover(Projeto p)
        {
            if (p.Tarefas.Count == 0)
            {
                return Itens.Remove(p);
            }
            return false;
        }

        public Projeto Buscar(int id) => Itens.FirstOrDefault(p => p.Id == id);

        public List<Projeto> Listar() => Itens;
    }
}
