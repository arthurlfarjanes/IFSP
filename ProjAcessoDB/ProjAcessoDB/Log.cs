using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessoDB
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime DtAcesso { get; set; }
        public int UsuarioId { get; set; }
        public int AmbienteId { get; set; }
        public Usuario Usuario { get; set; }
        public bool TipoAcesso { get; set; }

        public Log(Usuario usuario, bool tipoAcesso)
        {
            this.DtAcesso = DateTime.Now;
            this.Usuario = usuario;
            this.UsuarioId = usuario.Id;
            this.TipoAcesso = tipoAcesso;
        }

        public Log() { }

        public override string ToString()
        {
            string nomeUsuario = this.Usuario != null ? this.Usuario.Nome : $"ID {this.UsuarioId} (Desconhecido)";
            string status = this.TipoAcesso ? "Autorizado" : "Negado";
            return $"[{this.DtAcesso}] - Usuário: {nomeUsuario} - Acesso: {status}";
        }
    }
}
