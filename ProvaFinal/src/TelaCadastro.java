import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.List;

public class TelaCadastro extends JFrame {

    // Componentes da tela
    private JTextField txtNome, txtIdade, txtPeso, txtAltura;
    private JLabel lblNome, lblIdade, lblPeso, lblAltura;
    
    // Botões
    private JButton btnIncluir, btnLimpar, btnApresentar, btnPesquisar, btnCreditos, btnSair;

    // Instância do DAO para comunicar com o banco
    private PacienteDAO dao = new PacienteDAO();

    public TelaCadastro() {
        // Configurações da Janela
        setTitle("Cadastro de Pacientes - Hospital");
        setSize(500, 400);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(null);
        setLocationRelativeTo(null);

        inicializarComponentes();
        configurarEventos();
    }

    private void inicializarComponentes() {
        // ========== Rótulos e Campos ==========
        // Nome
        lblNome = new JLabel("Nome:");
        lblNome.setBounds(20, 20, 100, 25);
        add(lblNome);

        txtNome = new JTextField();
        txtNome.setBounds(80, 20, 300, 25);
        add(txtNome);

        // Idade
        lblIdade = new JLabel("Idade:");
        lblIdade.setBounds(20, 60, 100, 25);
        add(lblIdade);

        txtIdade = new JTextField();
        txtIdade.setBounds(80, 60, 100, 25);
        add(txtIdade);

        // Peso
        lblPeso = new JLabel("Peso:");
        lblPeso.setBounds(20, 100, 100, 25);
        add(lblPeso);

        txtPeso = new JTextField();
        txtPeso.setBounds(80, 100, 100, 25);
        add(txtPeso);

        // Altura
        lblAltura = new JLabel("Altura:");
        lblAltura.setBounds(200, 100, 100, 25);
        add(lblAltura);

        txtAltura = new JTextField();
        txtAltura.setBounds(250, 100, 100, 25);
        add(txtAltura);

        // ========== Botões ==========
        btnIncluir = new JButton("Incluir");
        btnIncluir.setBounds(20, 150, 100, 30);
        add(btnIncluir);

        btnLimpar = new JButton("Limpar");
        btnLimpar.setBounds(130, 150, 100, 30);
        add(btnLimpar);

        btnApresentar = new JButton("Apresentar Dados");
        btnApresentar.setBounds(240, 150, 150, 30);
        add(btnApresentar);

        btnPesquisar = new JButton("Pesquisar");
        btnPesquisar.setBounds(20, 200, 100, 30);
        add(btnPesquisar);

        btnCreditos = new JButton("Créditos");
        btnCreditos.setBounds(130, 200, 100, 30);
        add(btnCreditos);

        btnSair = new JButton("Sair");
        btnSair.setBounds(240, 200, 100, 30);
        add(btnSair);
    }

    private void configurarEventos() {
        
        // Botão Incluir 
        btnIncluir.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    // Captura os dados da tela
                    String nome = txtNome.getText();
                    int idade = Integer.parseInt(txtIdade.getText());
                    float peso = Float.parseFloat(txtPeso.getText());
                    float altura = Float.parseFloat(txtAltura.getText());

                    // Cria o objeto Paciente
                    Paciente p = new Paciente(nome, idade, peso, altura);
                    
                    // Salva no Banco
                    dao.inserir(p);

                    JOptionPane.showMessageDialog(null, "Paciente salvo com sucesso!");
                    limparCampos(); // Limpa após salvar

                } catch (NumberFormatException ex) {
                    JOptionPane.showMessageDialog(null, "Erro: Verifique se Idade, Peso e Altura são números válidos.");
                } catch (Exception ex) {
                    JOptionPane.showMessageDialog(null, "Erro ao salvar: " + ex.getMessage());
                }
            }
        });

        // Botão Limpar 
        btnLimpar.addActionListener(e -> limparCampos());

        // Botão Apresentar Dados 
        btnApresentar.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                List<Paciente> lista = dao.listarTodos();
                StringBuilder sb = new StringBuilder();
                
                if (lista.isEmpty()) {
                    sb.append("Nenhum paciente cadastrado.");
                } else {
                    for (Paciente p : lista) {
                        sb.append(p.toString()).append("\n-----------------\n");
                    }
                }
                
                // Mostra num painel rolável caso a lista seja grande
                JTextArea textArea = new JTextArea(sb.toString());
                JScrollPane scrollPane = new JScrollPane(textArea);
                textArea.setLineWrap(true);
                textArea.setWrapStyleWord(true);
                scrollPane.setPreferredSize(new java.awt.Dimension(400, 300));
                
                JOptionPane.showMessageDialog(null, scrollPane, "Lista de Pacientes", JOptionPane.INFORMATION_MESSAGE);
            }
        });

        // Botão Pesquisar (Like)
        btnPesquisar.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String nomePesquisa = JOptionPane.showInputDialog("Digite o nome para pesquisar:");
                if (nomePesquisa != null && !nomePesquisa.isEmpty()) {
                    List<Paciente> resultados = dao.pesquisarPorNome(nomePesquisa);
                    
                    StringBuilder sb = new StringBuilder();
                    for (Paciente p : resultados) {
                        sb.append(p.toString()).append("\n");
                    }

                    if (resultados.isEmpty()) {
                        JOptionPane.showMessageDialog(null, "Nenhum paciente encontrado com esse nome.");
                    } else {
                        JOptionPane.showMessageDialog(null, sb.toString());
                    }
                }
            }
        });

        // Botão Créditos 
        btnCreditos.addActionListener(e -> 
            JOptionPane.showMessageDialog(null, "Trabalho realizado por:\n- Arthur Lanzilotti Farjanes (CB3031306)\n- Adriano Júnior de Souza Almeida (CB3030644)")
        );

        // Botão Sair
        btnSair.addActionListener(e -> System.exit(0));
    }

    // Método auxiliar para limpar os campos de texto
    private void limparCampos() {
        txtNome.setText("");
        txtIdade.setText("");
        txtPeso.setText("");
        txtAltura.setText("");
    }
}