using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjListBiblioteca
{
    public class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public List<Exemplar> Exemplares { get; private set; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.Isbn = isbn;
            this.Titulo = titulo;
            this.Autor = autor;
            this.Editora = editora;
            this.Exemplares = new List<Exemplar>();
        }

        public Livro()
        {
            this.Exemplares = new List<Exemplar>();
        }

        public void adicionarExemplar(Exemplar exemplar)
        {
            this.Exemplares.Add(exemplar);
        }

        public int qtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int qtdeDisponiveis()
        {
            return Exemplares.Count(e => e.disponivel());
        }

        public int qtdeEmprestimos()
        {
            return Exemplares.Sum(e => e.qtdeEmprestimos());
        }

        public double percDisponibilidade()
        {
            if (qtdeExemplares() == 0)
            {
                return 0.0;
            }

            return (double)qtdeDisponiveis() / qtdeExemplares() * 100.0;
        }
    }
}
