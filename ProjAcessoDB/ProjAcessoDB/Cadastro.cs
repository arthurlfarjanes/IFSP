using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessoDB
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
            System.Console.WriteLine("Iniciando Upload (Salvando dados no SQLite)...");
            AcessoDB.SalvarDados(Usuarios, Ambientes);
            System.Console.WriteLine("Upload concluído! Dados salvos com sucesso.");
        }

        public static void Download()
        {
            System.Console.WriteLine("Iniciando Download (Carregando dados do SQLite)...");

            var (usuariosCarregados, ambientesCarregados) = AcessoDB.CarregarDados();

            Usuarios = usuariosCarregados;
            Ambientes = ambientesCarregados;

            System.Console.WriteLine($"Carregados {Usuarios.Count} usuários e {Ambientes.Count} ambientes.");
            System.Console.WriteLine("Download concluído! Dados carregados com sucesso.");
        }
    }
}
