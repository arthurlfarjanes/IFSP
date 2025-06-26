import java.util.Scanner;

public class Data {
    private int dia;
    private int mes;
    private int ano;

    public Data(int dia, int mes, int ano) {
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
    }

    public Data() {
        Scanner sc = new Scanner(System.in);
        System.out.print("Digite o dia (dd): ");
        this.dia = sc.nextInt();
        System.out.print("Digite o mês (mm): ");
        this.mes = sc.nextInt();
        System.out.print("Digite o ano (aaaa): ");
        this.ano = sc.nextInt();
    }

    public int getDia() {
        return dia;
    }

    public int getMes() {
        return mes;
    }

    public int getAno() {
        return ano;
    }

    public void setDia(int dia) {
        this.dia = dia;
    }

    public void setMes(int mes) {
        this.mes = mes;
    }

    public void setAno(int ano) {
        this.ano = ano;
    }

    public String mostra1() {
        return String.format("%02d/%02d/%04d", this.dia, this.mes, this.ano);
    }
}