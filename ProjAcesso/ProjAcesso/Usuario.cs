using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcesso
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public List<Ambiente> Ambientes { get; private set; }

        public Usuario(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Ambientes = new List<Ambiente>(); 
        }

        public bool ConcederPermissao(Ambiente ambiente)
        {
            if (!this.Ambientes.Contains(ambiente))
            {
                this.Ambientes.Add(ambiente);
                return true; 
            }
            return false; 
        }

        public bool RevogarPermissao(Ambiente ambiente)
        {
            return this.Ambientes.Remove(ambiente);
        }
    }
}
