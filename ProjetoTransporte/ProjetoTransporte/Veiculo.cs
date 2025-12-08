namespace ProjetoTransporte
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int Capacidade { get; set; } = 15;
        public int TotalPassageirosTransportados { get; set; }

        public Veiculo(int id)
        {
            Id = id;
            TotalPassageirosTransportados = 0;
        }
    }
}