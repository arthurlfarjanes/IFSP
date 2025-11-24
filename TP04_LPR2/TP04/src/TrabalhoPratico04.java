// ============================ TRABALHO PRÁTICO 04 ============================
/*
    DUPLA:
    Adriano Júnior de Souza Almeida - CB3030644
    Arthur Lanzilotti Farjanes - CB3031306

    ENUNCIADO:
    1. Elabore um programa em Java que apresente um frame semelhante ao que
    se segue: (formulário com 4 textFilds, 4 labels e 3 botões)
    2. Deverá criar um banco SQL Server chamado aulajava com as tabelas
    conforme esquema abaixo: (tbcargos e tbfuncs)
    3. Acrescente alguns registros, respeitando as chaves e o relacionamento;
    4. Estabeleça a conexão utilizando o JDBC;
    5. Ao clicar no botão Pesquisar, deverá ser efetuado o select (utilize like) para
    “preencher” um recordset e PreparedStatement para fazer o SQL.
    6. Os botões Próximo e Anterior devem permitir a navegação pelo recordset
    até os limites inicial e final.
*/

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class TrabalhoPratico04 extends JFrame {

    private JLabel labelNomeBusca;
    private JTextField campoNomeBusca;
    private JButton botaoPesquisar;

    private JLabel labelNomeResultado;
    private JTextField campoNomeResultado;
    private JLabel labelSalarioResultado;
    private JTextField campoSalarioResultado;
    private JLabel labelCargoResultado;
    private JTextField campoCargoResultado;

    private JButton botaoAnterior;
    private JButton botaoProximo;

    private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;

    class Funcionario {
        String nome;
        double salario;
        String cargo;

        public Funcionario(String nome, double salario, String cargo) {
            this.nome = nome;
            this.salario = salario;
            this.cargo = cargo;
        }
    }

    private List<Funcionario> listaResultados; 
    private int indiceAtual; 

    public TrabalhoPratico04() {
        setTitle("TRABALHO PRATICO 04");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setResizable(false);

        inicializarComponentes();
        configurarLayout();
        conectarBanco();

        pack();
        setLocationRelativeTo(null);
        setVisible(true);
    }

    private void inicializarComponentes() {
        labelNomeBusca = new JLabel("Nome:");
        campoNomeBusca = new JTextField(15);
        botaoPesquisar = new JButton("Pesquisar");

        labelNomeResultado = new JLabel("Nome:");
        campoNomeResultado = new JTextField("", 15);
        campoNomeResultado.setEditable(false);

        labelSalarioResultado = new JLabel("Salário:");
        campoSalarioResultado = new JTextField("", 15);
        campoSalarioResultado.setEditable(false);

        labelCargoResultado = new JLabel("Cargo:");
        campoCargoResultado = new JTextField("", 15);
        campoCargoResultado.setEditable(false);

        botaoAnterior = new JButton("Anterior");
        botaoProximo = new JButton("Próximo");
        
        botaoAnterior.setEnabled(false);
        botaoProximo.setEnabled(false);

        listaResultados = new ArrayList<>();

        botaoPesquisar.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                pesquisarFuncionario();
            }
        });

        botaoAnterior.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if (indiceAtual > 0) {
                    indiceAtual--; // Recua um índice
                    mostrarFuncionarioNaTela();
                } else {
                    JOptionPane.showMessageDialog(null, "Este é o primeiro registo.");
                }
            }
        });

        botaoProximo.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if (indiceAtual < listaResultados.size() - 1) {
                    indiceAtual++; // Avança um índice
                    mostrarFuncionarioNaTela();
                } else {
                    JOptionPane.showMessageDialog(null, "Este é o último registo.");
                }
            }
        });
    }

    private void conectarBanco() {
        try {
            String url = "jdbc:sqlite:aulajava.db"; 
            con = DriverManager.getConnection(url);
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(this, "Erro ao conectar ao banco: " + e.getMessage());
        }
    }

    private void pesquisarFuncionario() {
        try {
            String nomeBusca = campoNomeBusca.getText().trim();
            
            String sql = "SELECT f.nome_func, f.sal_func, c.ds_cargo " +
                         "FROM tbfuncs f " +
                         "INNER JOIN tbcargos c ON f.cod_cargo = c.cd_cargo " +
                         "WHERE f.nome_func LIKE ?";

            ps = con.prepareStatement(sql);
            
            ps.setString(1, "%" + nomeBusca + "%"); 

            rs = ps.executeQuery();

            listaResultados.clear();

            while (rs.next()) {
                String nome = rs.getString("nome_func");
                double sal = rs.getDouble("sal_func");
                String cargo = rs.getString("ds_cargo");
                
                listaResultados.add(new Funcionario(nome, sal, cargo));
            }

            if (!listaResultados.isEmpty()) { 
                indiceAtual = 0; 
                mostrarFuncionarioNaTela();
                
                botaoAnterior.setEnabled(true);
                botaoProximo.setEnabled(true);
            } else {
                JOptionPane.showMessageDialog(this, "Nenhum funcionário encontrado.");
                limparCampos();
                botaoAnterior.setEnabled(false);
                botaoProximo.setEnabled(false);
            }

        } catch (SQLException e) {
            JOptionPane.showMessageDialog(this, "Erro na pesquisa: " + e.getMessage());
        }
    }

    private void mostrarFuncionarioNaTela() {
        if (indiceAtual >= 0 && indiceAtual < listaResultados.size()) {
            Funcionario f = listaResultados.get(indiceAtual);
            campoNomeResultado.setText(f.nome);
            campoSalarioResultado.setText(String.valueOf(f.salario));
            campoCargoResultado.setText(f.cargo);
        }
    }

    private void limparCampos() {
        campoNomeResultado.setText("");
        campoSalarioResultado.setText("");
        campoCargoResultado.setText("");
    }

    private void configurarLayout() {
        setLayout(new BorderLayout(10, 10));

        JPanel painelSuperior = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        painelSuperior.add(labelNomeBusca);
        painelSuperior.add(campoNomeBusca);

        add(painelSuperior, BorderLayout.NORTH);

        JPanel painelBotaoPesquisa = new JPanel(new FlowLayout(FlowLayout.CENTER, 5, 5));
        painelBotaoPesquisa.add(botaoPesquisar);

        JPanel painelResultado = new JPanel(new GridLayout(3, 2, 5, 5));
        painelResultado.add(labelNomeResultado);
        painelResultado.add(campoNomeResultado);
        painelResultado.add(labelSalarioResultado);
        painelResultado.add(campoSalarioResultado);
        painelResultado.add(labelCargoResultado);
        painelResultado.add(campoCargoResultado);

        JPanel painelMiolo = new JPanel();
        painelMiolo.setLayout(new BoxLayout(painelMiolo, BoxLayout.Y_AXIS));
        painelMiolo.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));

        painelBotaoPesquisa.setAlignmentX(Component.CENTER_ALIGNMENT);

        painelMiolo.add(painelBotaoPesquisa);
        painelMiolo.add(Box.createRigidArea(new Dimension(0, 10)));
        painelMiolo.add(painelResultado);

        add(painelMiolo, BorderLayout.CENTER);

        JPanel painelNavegacao = new JPanel(new GridLayout(1, 2, 5, 0));
        painelNavegacao.add(botaoAnterior);
        painelNavegacao.add(botaoProximo);

        add(painelNavegacao, BorderLayout.SOUTH);
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new TrabalhoPratico04());
    }
}