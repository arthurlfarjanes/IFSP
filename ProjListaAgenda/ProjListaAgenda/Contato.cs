using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjListaAgenda
{
    public class Contato
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public Data DtNasc { get; set; }

        public List<Telefone> Telefones { get; private set; }

        public Contato(string email, string nome, Data dtNasc)
        {
            this.Email = email;
            this.Nome = nome;
            this.DtNasc = dtNasc;
            this.Telefones = new List<Telefone>(); 
        }

        public Contato(string email)
        {
            this.Email = email;
        }

        public int getIdade()
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - DtNasc.Ano;
            if (hoje.Month < DtNasc.Mes || (hoje.Month == DtNasc.Mes && hoje.Day < DtNasc.Dia))
            {
                idade--;
            }
            return idade;
        }

        public void adicionarTelefone(Telefone t)
        {
            this.Telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            Telefone telPrincipal = this.Telefones.FirstOrDefault(t => t.Principal);

            if (telPrincipal != null)
            {
                return $"{telPrincipal.Tipo}: {telPrincipal.Numero}";
            }

            return "Nenhum telefone principal cadastrado.";
        }

        public override string ToString()
        {
            return $"Nome: {Nome}" +
                   $"\nEmail: {Email}" +
                   $"\nNascimento: {DtNasc.ToString()}" +
                   $"\nIdade: {getIdade()} anos" +
                   $"\nTelefone Principal: {getTelefonePrincipal()}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Contato))
            {
                return false;
            }
            Contato outro = (Contato)obj;
            return this.Email.Equals(outro.Email);
        }

        public override int GetHashCode()
        {
            return Email != null ? Email.GetHashCode() : 0;
        }
    }
}
