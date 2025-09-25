using System.Collections.Generic;
using System.Linq;

namespace ProjListaAgenda
{
    public class Contatos
    {
        public List<Contato> Agenda { get; private set; }

        public Contatos()
        {
            this.Agenda = new List<Contato>();
        }

        public bool adicionar(Contato c)
        {
            if (Agenda.Contains(c))
            {
                return false; 
            }

            Agenda.Add(c);
            return true;
        }

        public Contato pesquisar(Contato c)
        {
            return Agenda.FirstOrDefault(contato => contato.Equals(c));
        }

        public bool alterar(Contato c)
        {
            int index = Agenda.IndexOf(c);
            if (index != -1)
            {
                Agenda[index] = c;
                return true;
            }
            return false;
        }

        public bool remover(Contato c)
        {
            return Agenda.Remove(c);
        }
    }
}
