using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessoDB
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Ambiente> Ambientes { get; private set; }

        public Usuario(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Ambientes = new List<Ambiente>();
        }

        public Usuario()
        {
            this.Ambientes = new List<Ambiente>();
        }

        public bool ConcederPermissao(Ambiente ambiente)
        {
            if (!this.Ambientes.Any(a => a.Id == ambiente.Id))
            {
                this.Ambientes.Add(ambiente);
                return true;
            }
            return false;
        }

        public bool RevogarPermissao(Ambiente ambiente)
        {
            return this.Ambientes.RemoveAll(a => a.Id == ambiente.Id) > 0;
        }
    }
}
