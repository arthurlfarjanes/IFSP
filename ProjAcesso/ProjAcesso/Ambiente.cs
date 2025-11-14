using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcesso
{
    public class Ambiente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Queue<Log> Logs { get; private set; }

        private const int MAX_LOGS = 100;

        public Ambiente(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Logs = new Queue<Log>();
        }

        public void RegistrarLog(Log log)
        {
            if (this.Logs.Count >= MAX_LOGS)
            {
                this.Logs.Dequeue();
            }

            this.Logs.Enqueue(log);
        }
    }
}
