using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessoDB
{
    public class Ambiente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Queue<Log> Logs { get; private set; }
        public List<Log> LogsParaPersistencia { get; set; } = new List<Log>();

        public const int MAX_LOGS = 100;

        public Ambiente(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Logs = new Queue<Log>();
        }

        public Ambiente()
        {
            this.Logs = new Queue<Log>();
        }

        public void RegistrarLog(Log log)
        {
            if (this.Logs.Count >= MAX_LOGS)
            {
                this.Logs.Dequeue();
            }
            this.Logs.Enqueue(log);

            log.AmbienteId = this.Id;
            this.LogsParaPersistencia.Add(log);
        }
    }
}
