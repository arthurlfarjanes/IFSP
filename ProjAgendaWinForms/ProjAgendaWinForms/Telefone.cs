namespace ProjListaAgenda
{
    public class Telefone
    {
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public bool Principal { get; set; }

        public Telefone()
        {
            this.Tipo = "Celular";
            this.Numero = "";
            this.Principal = false;
        }

        public Telefone(string tipo, string numero, bool principal)
        {
            this.Tipo = tipo;
            this.Numero = numero;
            this.Principal = principal;
        }
    }
}
