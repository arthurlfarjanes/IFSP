using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFilaMedicamentos
{
    public class Lote
    {
        public int Id { get; set; }
        public int Qtde { get; set; }
        public DateTime Venc { get; set; }

        public Lote()
        {
            this.Id = 0;
            this.Qtde = 0;
            this.Venc = DateTime.MinValue;
        }

        public Lote(int id, int qtde, DateTime venc)
        {
            this.Id = id;
            this.Qtde = qtde;
            this.Venc = venc;
        }

        public override string ToString()
        {
            return $"{this.Id}-{this.Qtde}-{this.Venc.ToShortDateString()}";
        }
    }
}
