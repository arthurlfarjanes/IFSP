using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFilaMedicamentos
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio { get; set; }
        public Queue<Lote> Lotes { get; set; }

        public Medicamento()
        {
            this.Id = 0;
            this.Nome = "";
            this.Laboratorio = "";
            this.Lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.Id = id;
            this.Nome = nome;
            this.Laboratorio = laboratorio;
            this.Lotes = new Queue<Lote>();
        }

        public int QtdeDisponivel()
        {
            return this.Lotes.Sum(l => l.Qtde);
        }

        public void Comprar(Lote lote)
        {
            this.Lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            if (qtde > QtdeDisponivel())
            {
                return false;
            }

            int qtdeRestante = qtde;
            while (qtdeRestante > 0 && this.Lotes.Count > 0)
            {
                Lote loteAtual = this.Lotes.Peek();
                if (loteAtual.Qtde > qtdeRestante)
                {
                    loteAtual.Qtde -= qtdeRestante;
                    qtdeRestante = 0;
                }
                else
                {
                    qtdeRestante -= loteAtual.Qtde;
                    this.Lotes.Dequeue();
                }
            }
            return true;
        }

        public override string ToString()
        {
            return $"{this.Id}-{this.Nome}-{this.Laboratorio}-{QtdeDisponivel()}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Medicamento outroMedicamento = (Medicamento)obj;
            return this.Id == outroMedicamento.Id;
        }
    }
}
