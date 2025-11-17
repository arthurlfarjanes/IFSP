import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class Calculadora extends JFrame {

    private JTextField display;
    private String operador = "";
    private double num1 = 0;

    public Calculadora() {
        super("Calculadora");

        setLayout(new BorderLayout());

        // DISPLAY
        display = new JTextField("0");
        display.setHorizontalAlignment(SwingConstants.RIGHT);
        display.setEditable(false);
        display.setFont(new Font("Arial", Font.BOLD, 22));
        add(display, BorderLayout.NORTH);

        JPanel painel = new JPanel();
        painel.setLayout(new GridLayout(5, 4, 5, 5));

        // LINHA 1
        painel.add(criarBotao("7"));
        painel.add(criarBotao("8"));
        painel.add(criarBotao("9"));
        painel.add(criarBotao("/"));

        // LINHA 2
        painel.add(criarBotao("4"));
        painel.add(criarBotao("5"));
        painel.add(criarBotao("6"));
        painel.add(criarBotao("*"));

        // LINHA 3
        painel.add(criarBotao("1"));
        painel.add(criarBotao("2"));
        painel.add(criarBotao("3"));
        painel.add(criarBotao("-"));

        // LINHA 4
        painel.add(criarBotao("0"));
        painel.add(criarBotao("."));
        painel.add(criarBotao("="));
        painel.add(criarBotao("+"));

        // LINHA 5 — BOTÃO “C” OCUPANDO 4 COLUNAS
        JButton btnClear = new JButton("C");
        btnClear.setFont(new Font("Arial", Font.BOLD, 20));
        btnClear.addActionListener(e -> {
            display.setText("0"); 
            num1 = 0;             
            operador = "";        
        });

        painel.add(btnClear);
        painel.add(new JLabel()); 
        painel.add(new JLabel()); 
        painel.add(new JLabel()); 

        add(painel, BorderLayout.CENTER);

        setSize(280, 350);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setVisible(true);
    }

    private JButton criarBotao(String texto) {
        JButton btn = new JButton(texto);
        btn.setFont(new Font("Arial", Font.BOLD, 20));

        btn.addActionListener(e -> clique(texto));

        return btn;
    }

    private void clique(String tecla) {
        try {
            if (tecla.matches("[0-9]")) {
                if (display.getText().equals("0"))
                    display.setText(tecla);
                else
                    display.setText(display.getText() + tecla);
            }

            else if (tecla.equals(".")) {
                if (!display.getText().contains("."))
                    display.setText(display.getText() + ".");
            }

            else if (tecla.matches("[/\\*\\-\\+]")) {
                num1 = Double.parseDouble(display.getText());
                operador = tecla;
                display.setText("0");
            }

            else if (tecla.equals("=")) {
                double num2 = Double.parseDouble(display.getText());
                double resultado = 0;

                switch (operador) {
                    case "+": resultado = num1 + num2; break;
                    case "-": resultado = num1 - num2; break;
                    case "*": resultado = num1 * num2; break;
                    case "/":
                        if (num2 == 0) {
                            throw new ArithmeticException("Divisão por zero!");
                        }
                        resultado = num1 / num2;
                        break;
                }

                display.setText(String.valueOf(resultado));
            }

        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this,
                    "Erro: " + ex.getMessage(),
                    "Erro",
                    JOptionPane.ERROR_MESSAGE);
        }
    }

    public static void main(String[] args) {
        new Calculadora();
    }
}
