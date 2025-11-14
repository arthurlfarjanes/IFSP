using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcesso
{
    public class Log
    {
        public DateTime DtAcesso { get; private set; }
        public Usuario Usuario { get; private set; }
        public bool TipoAcesso { get; private set; } 

        public Log(Usuario usuario, bool tipoAcesso)
        {
            this.DtAcesso = DateTime.Now; 
            this.Usuario = usuario;
            this.TipoAcesso = tipoAcesso;
        }

        public override string ToString()
        {
            string status = this.TipoAcesso ? "Autorizado" : "Negado";
            return $"[{this.DtAcesso}] - Usuário: {this.Usuario.Nome} - Acesso: {status}";
        }
    }
}
