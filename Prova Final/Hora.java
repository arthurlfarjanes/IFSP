import java.util.Scanner;

public class Hora {
    private int hora;
    private int min;
    private int seg;

    public Hora(int h, int m, int s) {
        this.hora = h;
        this.min = m;
        this.seg = s;
    }

    public Hora() {
        Scanner sc = new Scanner(System.in);
        System.out.print("Digite a hora (hh): ");
        this.hora = sc.nextInt();
        System.out.print("Digite os minutos (mm): ");
        this.min = sc.nextInt();
        System.out.print("Digite os segundos (ss): ");
        this.seg = sc.nextInt();
    }

    public int getHora() {
        return hora;
    }

    public int getMin() {
        return min;
    }

    public int getSeg() {
        return seg;
    }

    public void setHora(int hora) {
        this.hora = hora;
    }

    public void setMin(int min) {
        this.min = min;
    }

    public void setSeg(int seg) {
        this.seg = seg;
    }

    public String getHora1() {
        return String.format("%02d:%02d:%02d", this.hora, this.min, this.seg);
    }
}