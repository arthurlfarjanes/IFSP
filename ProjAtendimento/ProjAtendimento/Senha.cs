using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAtendimento
{
    public class Senha
    {
        private int id;
        private DateTime dataGerac;
        private DateTime horaGerac;
        private DateTime dataAtend;
        private DateTime horaAtend;

        public DateTime DataAtend { set { dataAtend = value; } }
        public DateTime HoraAtend { set { horaAtend = value; } }

        public Senha(int id)
        {
            this.id = id;
            this.dataGerac = DateTime.Now; 
            this.horaGerac = DateTime.Now; 
        }

        public string dadosParciais()
        {
            return id.ToString() + " - " +
                   dataGerac.ToString("dd/MM/yyyy") + " - " +
                   horaGerac.ToString("HH:mm:ss");
        }

        public string dadosCompletos()
        {
            return id.ToString() + " - " +
                   dataGerac.ToString("dd/MM/yyyy") + " - " +
                   horaGerac.ToString("HH:mm:ss") + " - " +
                   dataAtend.ToString("dd/MM/yyyy") + " - " +
                   horaAtend.ToString("HH:mm:ss");
        }
    }
}
