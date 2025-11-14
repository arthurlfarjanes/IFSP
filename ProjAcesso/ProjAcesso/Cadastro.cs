using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcesso
{
    public static class Cadastro
    {
        public static List<Usuario> Usuarios { get; private set; }
        public static List<Ambiente> Ambientes { get; private set; }

        static Cadastro()
        {
            Usuarios = new List<Usuario>();
            Ambientes = new List<Ambiente>();
        }

        public static void AdicionarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public static bool RemoverUsuario(Usuario usuario)
        {
            if (usuario.Ambientes.Count == 0)
            {
                return Usuarios.Remove(usuario); 
            }
            return false; 
        }

        public static Usuario PesquisarUsuario(int id)
        {
            return Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public static void AdicionarAmbiente(Ambiente ambiente)
        {
            Ambientes.Add(ambiente);
        }

        public static bool RemoverAmbiente(Ambiente ambiente)
        {
            foreach (var usuario in Usuarios)
            {
                usuario.RevogarPermissao(ambiente);
            }

            return Ambientes.Remove(ambiente);
        }

        public static Ambiente PesquisarAmbiente(int id)
        {
            return Ambientes.FirstOrDefault(a => a.Id == id);
        }


        public static void Upload()
        {
            System.Console.WriteLine("Função Upload() não implementada.");
        }

        public static void Download()
        {
            System.Console.WriteLine("Função Download() não implementada.");
        }
    }
}
