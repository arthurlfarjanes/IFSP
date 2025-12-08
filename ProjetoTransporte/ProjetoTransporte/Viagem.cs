namespace ProjetoTransporte
{
    public class Viagem
    {
        public Garagem Origem { get; set; }
        public Garagem Destino { get; set; }
        public Veiculo Veiculo { get; set; }
        public int Passageiros { get; set; }
    }
}
