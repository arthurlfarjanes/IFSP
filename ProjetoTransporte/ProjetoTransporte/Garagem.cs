namespace ProjetoTransporte
{
    public class Garagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Stack<Veiculo> VeiculosEstacionados { get; set; }

        public Garagem(int id, string nome)
        {
            Id = id;
            Nome = nome;
            VeiculosEstacionados = new Stack<Veiculo>();
        }

        public int QuantidadeVeiculos()
        {
            return VeiculosEstacionados.Count;
        }

        public int PotencialTransporte()
        {
            return VeiculosEstacionados.Sum(v => v.Capacidade);
        }
    }
}
