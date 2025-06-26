import java.util.Scanner;

public class ConsultaAgendada {
    
    private Data data; 
    private Hora hora;
    private String nomePaciente;
    private static int quantidade;
    private String nomeMedico;

    public ConsultaAgendada() {
        this.setData();
        this.setHora();
        this.setNomePaciente();
        this.setNomeMedico();
        quantidade++;
    }

    public ConsultaAgendada(int h, int mi, int s, int d, int m, int a, String p, String med){
        this.hora = new Hora(h, mi, s);
        this.data = new Data(d, m, a);
        this.nomePaciente = p;
        this.nomeMedico = med;
        quantidade++;
    }

    public ConsultaAgendada(Data d, Hora h, String p, String m){
        this.data = d;
        this.hora = h;
        this.nomePaciente = p;
        this.nomeMedico = m;
        quantidade++;
    }

    public void setData() {
        Scanner sc = new Scanner(System.in);
        System.out.println("--- Digite a data ---");
        System.out.print("Digite o dia (dd): ");
        int d = sc.nextInt();
        System.out.print("Digite o mês (mm): ");
        int m = sc.nextInt();
        System.out.print("Digite o ano (aaaa): ");
        int a = sc.nextInt();
        this.data = new Data(d, m, a);
    }

    public void setHora() {
        Scanner sc = new Scanner(System.in);
        System.out.println("--- Digite a hora ---");
        System.out.print("Digite a hora (hh): ");
        int h = sc.nextInt();
        System.out.print("Digite os minutos (mm): ");
        int m = sc.nextInt();
        System.out.print("Digite os segundos (ss): ");
        int s = sc.nextInt();
        this.hora = new Hora(h, m, s);
    }
    
    public void setNomePaciente() {
        Scanner sc = new Scanner(System.in);
        System.out.print("Digite o nome do paciente: ");
        this.nomePaciente = sc.next();
    }
    
    public void setNomeMedico() {
        Scanner sc = new Scanner(System.in);
        System.out.print("Digite o nome do médico: ");
        this.nomeMedico = sc.next();
    }

    public void setData(int d, int m, int a) {
        this.data = new Data(d, m, a);
    }
    
    public void setHora(int h, int m, int s) {
        this.hora = new Hora(h, m, s);
    }

    public void setNomePaciente(String p) {
        this.nomePaciente = p;
    }

    public void setNomeMedico(String m) {
        this.nomeMedico = m;
    }

    public static int getAmostra() {
        return quantidade;
    }

    public String getData() {
        return this.data.mostra1();
    }

    public String getHora() {
        return this.hora.getHora1();
    }

    public String getNomePaciente() {
        return nomePaciente;
    }

    public String getNomeMedico(){
        return nomeMedico;
    }
}