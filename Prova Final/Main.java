import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        
        String caminhoArquivo = "C:/Users/Arthur/IFSP/Disciplinas/LPR1/Prova Final/ResultadosEX3.txt";

        try (PrintWriter writer = new PrintWriter(new FileWriter(caminhoArquivo))) {
            
            System.out.println("Iniciando teste e gravando resultados em " + caminhoArquivo);
            
            ConsultaAgendada p1 = new ConsultaAgendada(13, 30, 15, 25, 3, 2025, "Adriano", "Arthur");

            String titulo1 = "--------------------- CONSULTA 1 ---------------------";
            System.out.println(titulo1);
            writer.println(titulo1);

            String saidaMedico1 = String.format("Nome do Médico: %s", p1.getNomeMedico());
            System.out.println(saidaMedico1);
            writer.println(saidaMedico1);

            String saidaPaciente1 = String.format("Nome do Paciente: %s", p1.getNomePaciente());
            System.out.println(saidaPaciente1);
            writer.println(saidaPaciente1);

            String saidaData1 = String.format("Data: %s", p1.getData());
            System.out.println(saidaData1);
            writer.println(saidaData1);

            String saidaHora1 = String.format("Hora: %s", p1.getHora());
            System.out.println(saidaHora1);
            writer.println(saidaHora1);

            ConsultaAgendada p2 = new ConsultaAgendada();

            String titulo2 = "\n--------------------- CONSULTA 2 ---------------------";
            System.out.println(titulo2);
            writer.println(titulo2);
            
            String saidaMedico2 = String.format("Nome do Médico: %s", p2.getNomeMedico());
            System.out.println(saidaMedico2);
            writer.println(saidaMedico2);

            String saidaPaciente2 = String.format("Nome do Paciente: %s", p2.getNomePaciente());
            System.out.println(saidaPaciente2);
            writer.println(saidaPaciente2);

            String saidaData2 = String.format("Data: %s", p2.getData());
            System.out.println(saidaData2);
            writer.println(saidaData2);

            String saidaHora2 = String.format("Hora: %s", p2.getHora());
            System.out.println(saidaHora2);
            writer.println(saidaHora2);

            System.out.println("\n------------- ATUALIZAÇÃO DOS DADOS DA CONSULTA 1 -------------");
            p1.setData();
            p1.setHora();
            p1.setNomePaciente();
            p1.setNomeMedico();

            String titulo1Up = "\n--------------------- CONSULTA 1 ATUALIZADA ---------------------";
            System.out.println(titulo1Up);
            writer.println(titulo1Up);

            String saidaMedico1Up = String.format("Nome do Médico: %s", p1.getNomeMedico());
            System.out.println(saidaMedico1Up);
            writer.println(saidaMedico1Up);

            String saidaPaciente1Up = String.format("Nome do Paciente: %s", p1.getNomePaciente());
            System.out.println(saidaPaciente1Up);
            writer.println(saidaPaciente1Up);

            String saidaData1Up = String.format("Data: %s", p1.getData());
            System.out.println(saidaData1Up);
            writer.println(saidaData1Up);

            String saidaHora1Up = String.format("Hora: %s", p1.getHora());
            System.out.println(saidaHora1Up);
            writer.println(saidaHora1Up);

            String tituloFinal = "\n-------------------------------------------------------";
            System.out.println(tituloFinal);
            writer.println(tituloFinal);
            
            String saidaTotal = String.format("Quantidade de consultas agendadas: %d", ConsultaAgendada.getAmostra());
            System.out.println(saidaTotal);
            writer.println(saidaTotal);
            
            System.out.println("\nArquivo 'ResultadosEX3.txt' gerado com sucesso!");

        } catch (IOException e) {
            System.err.println("ERRO AO ESCREVER O ARQUIVO: " + e.getMessage());
            System.err.println("Verifique se o caminho C:/Users/Arthur/IFSP/Disciplinas/LPR1/Prova Final/ existe e se você tem permissão para escrever nele.");
        } finally {
            scanner.close();
        }
    }
}