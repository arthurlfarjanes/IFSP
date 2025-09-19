namespace ProjListaAgenda
{
    public class Data
    {
        public int Dia { get; private set; }
        public int Mes { get; private set; }
        public int Ano { get; private set; }

        public Data()
        {
            setData(0, 0, 0);
        }

        public Data(int dia, int mes, int ano)
        {
            setData(dia, mes, ano);
        }

        public void setData(int dia, int mes, int ano)
        {
            this.Dia = dia;
            this.Mes = mes;
            this.Ano = ano;
        }

        public override string ToString()
        {
            return $"{Dia:D2}/{Mes:D2}/{Ano:D4}";
        }
    }
}
