using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAtendimento
{
    public class Guiche
    {
        private int id;
        private Queue<Senha> atendimentos;

        public int Id { get { return id; } }
        public Queue<Senha> Atendimentos { get { return atendimentos; } }

        public Guiche()
        {
            atendimentos = new Queue<Senha>();
            this.id = 0;
        }

        public Guiche(int id)
        {
            atendimentos = new Queue<Senha>();
            this.id = id;
        }

        public bool chamar(Queue<Senha> filaSenhas)
        {
            if (filaSenhas.Count > 0)
            {
                Senha senhaChamada = filaSenhas.Dequeue();

                senhaChamada.DataAtend = DateTime.Now;
                senhaChamada.HoraAtend = DateTime.Now;

                this.atendimentos.Enqueue(senhaChamada);

                return true; 
            }
            return false; 
        }
    }
}
