package tp03;

import javax.swing.*;
import java.awt.event.*;

public class FormPessoaV1 extends JFrame {

    private JLabel lblNumero, lblNome, lblSexo, lblIdade;
    private JTextField txtNumero, txtNome, txtIdade;

    // === V1 - Campo de Texto ===
    private JTextField txtSexo;
    
    private JButton btnOk, btnLimpar, btnMostrar, btnSair;

    private Pessoa umaPessoa;

    public FormPessoaV1() {
        super("Formulário Pessoa");
        setLayout(null); 
        
        lblNumero = new JLabel("Numero:");
        lblNumero.setBounds(20, 20, 80, 25);
        add(lblNumero);

        lblNome = new JLabel("Nome:");
        lblNome.setBounds(20, 60, 80, 25);
        add(lblNome);

        lblSexo = new JLabel("Sexo:");
        lblSexo.setBounds(20, 100, 80, 25);
        add(lblSexo);

        lblIdade = new JLabel("Idade:");
        lblIdade.setBounds(20, 140, 80, 25);
        add(lblIdade);

        txtNumero = new JTextField();
        txtNumero.setBounds(100, 20, 100, 25);
        txtNumero.setEditable(false); 
        add(txtNumero);

        txtNome = new JTextField();
        txtNome.setBounds(100, 60, 200, 25);
        add(txtNome);

        // === V1 - Campo de Texto ===
        txtSexo = new JTextField();
        txtSexo.setBounds(100, 100, 50, 25); 
        add(txtSexo);

        txtIdade = new JTextField();
        txtIdade.setBounds(100, 140, 50, 25);
        add(txtIdade);

        btnOk = new JButton("OK");
        btnOk.setBounds(20, 190, 80, 30);
        add(btnOk);

        btnLimpar = new JButton("Limpar");
        btnLimpar.setBounds(110, 190, 80, 30);
        add(btnLimpar);

        btnMostrar = new JButton("Mostrar");
        btnMostrar.setBounds(200, 190, 80, 30);
        add(btnMostrar);

        btnSair = new JButton("Sair");
        btnSair.setBounds(290, 190, 80, 30);
        add(btnSair);
        
        setSize(400, 270);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 
        setVisible(true); 
        setLocationRelativeTo(null); 
        
        btnOk.addActionListener(e -> {
            try {

                // === V1 - Campo de Texto ===
                if (txtNome.getText().isEmpty() || txtSexo.getText().isEmpty() || txtIdade.getText().isEmpty()) {
                    JOptionPane.showMessageDialog(this, "Nome, Sexo e Idade são obrigatórios.", "Erro", JOptionPane.ERROR_MESSAGE);
                    return;
                }
                char sexo = txtSexo.getText().toUpperCase().charAt(0);
                if (sexo != 'M' && sexo != 'F') {
                    JOptionPane.showMessageDialog(this, "Sexo deve ser 'M' ou 'F'.", "Erro", JOptionPane.ERROR_MESSAGE);
                    return;
                }
                
                int idade = Integer.parseInt(txtIdade.getText());
                String nome = txtNome.getText();

                umaPessoa = new Pessoa(nome, sexo, idade); 

                txtNumero.setText(String.valueOf(Pessoa.getKp()));

                JOptionPane.showMessageDialog(this, "Pessoa registrada com sucesso!");

            } catch (NumberFormatException ex) {
                JOptionPane.showMessageDialog(this, "Idade deve ser um número válido.", "Erro", JOptionPane.ERROR_MESSAGE);
            } catch (Exception ex) {
                JOptionPane.showMessageDialog(this, "Erro: " + ex.getMessage(), "Erro", JOptionPane.ERROR_MESSAGE);
            }
        });

        // === V1 - Campo de Texto ===
        btnLimpar.addActionListener(e -> {
            txtNome.setText("");
            txtSexo.setText("");
            txtIdade.setText("");
            umaPessoa = null; 
        });

        btnMostrar.addActionListener(e -> {
            if (umaPessoa != null) {
                String dados = "Número (kp): " + Pessoa.getKp() + "\n" +
                               "Nome: " + umaPessoa.getNome() + "\n" +
                               "Sexo: " + umaPessoa.getSexo() + "\n" +
                               "Idade: " + umaPessoa.getIdade();
                JOptionPane.showMessageDialog(this, dados, "Dados da Pessoa", JOptionPane.INFORMATION_MESSAGE);
            } else {
                JOptionPane.showMessageDialog(this, "Nenhuma pessoa foi registrada ainda (clique em 'OK' primeiro).", "Aviso", JOptionPane.WARNING_MESSAGE);
            }
        });

        btnSair.addActionListener(e -> System.exit(0));
    }

    public static void main(String[] args) {
        new FormPessoaV1();
    }
}