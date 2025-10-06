using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjListBiblioteca
{
    public class Exemplar
    {
        public int Tombo { get; set; }
        public List<Emprestimo> Emprestimos { get; private set; }

        public Exemplar(int tombo)
        {
            this.Tombo = tombo;
            this.Emprestimos = new List<Emprestimo>();
        }

        public bool emprestar()
        {
            if (disponivel())
            {
                Emprestimos.Add(new Emprestimo());
                return true;
            }
            return false;
        }

        public bool devolver()
        {
            if (!disponivel())
            {
                Emprestimos.Last().DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool disponivel()
        {
            if (Emprestimos.Count == 0)
            {
                return true;
            }

            return Emprestimos.Last().DtDevolucao != null;
        }

        public int qtdeEmprestimos()
        {
            return Emprestimos.Count;
        }
    }
}
