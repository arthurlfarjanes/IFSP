using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjListBiblioteca
{
    public class Livros
    {
        public List<Livro> Acervo { get; private set; }

        public Livros()
        {
            this.Acervo = new List<Livro>();
        }

        public void adicionar(Livro livro)
        {
            this.Acervo.Add(livro);
        }

        public Livro pesquisar(int isbn)
        {
            return Acervo.FirstOrDefault(l => l.Isbn == isbn);
        }
    }
}
