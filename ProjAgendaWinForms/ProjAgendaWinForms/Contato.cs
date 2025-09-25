using System;

namespace ProjListaAgenda
{
    public class Contato
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; } 
        public Data DtNasc { get; set; }

        public Contato(string email, string nome, string telefone, Data dtNasc)
        {
            this.Email = email;
            this.Nome = nome;
            this.Telefone = telefone;
            this.DtNasc = dtNasc;
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

        public override string ToString()
        {
            return $"Nome: {Nome}" +
                   $"\nEmail: {Email}" +
                   $"\nTelefone: {Telefone}" + 
                   $"\nNascimento: {DtNasc.ToString()}" +
                   $"\nIdade: {getIdade()} anos";
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