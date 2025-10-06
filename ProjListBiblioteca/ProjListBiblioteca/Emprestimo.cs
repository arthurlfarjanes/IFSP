using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjListBiblioteca
{
    public class Emprestimo
    {
        public DateTime DtEmprestimo { get; set; }
        public DateTime? DtDevolucao { get; set; }
        public Emprestimo()
        {
            this.DtEmprestimo = DateTime.Now;
            this.DtDevolucao = null;
        }
    }
}
