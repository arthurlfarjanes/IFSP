using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFilaMedicamentos
{
    public class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public Medicamentos()
        {
            this.listaMedicamentos = new List<Medicamento>();
        }

        public void Adicionar(Medicamento medicamento)
        {
            this.listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            Medicamento medParaDeletar = Pesquisar(medicamento);
            if (medParaDeletar != null && medParaDeletar.QtdeDisponivel() == 0)
            {
                this.listaMedicamentos.Remove(medParaDeletar);
                return true;
            }
            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            return this.listaMedicamentos.FirstOrDefault(m => m.Equals(medicamento));
        }

        public List<Medicamento> GetLista()
        {
            return this.listaMedicamentos;
        }
    }
}
