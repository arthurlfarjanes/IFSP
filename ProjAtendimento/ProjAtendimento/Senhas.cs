using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAtendimento
{
    public class Senhas
    {
        private int proximoAtendimento;
        private Queue<Senha> filaSenhas;

        public Queue<Senha> FilaSenhas
        {
            get { return filaSenhas; }
        }

        public Senhas()
        {
            filaSenhas = new Queue<Senha>();
            proximoAtendimento = 1;
        }

        public void gerar()
        {
            Senha novaSenha = new Senha(proximoAtendimento);
            filaSenhas.Enqueue(novaSenha);
            proximoAtendimento++;
        }
    }
}
