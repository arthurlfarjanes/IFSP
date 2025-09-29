import java.awt.BorderLayout;
import java.awt.Button;
import java.awt.Frame;
import java.awt.GridLayout;
import java.awt.Label;
import java.awt.Panel;
import java.awt.TextField;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JOptionPane;

public class FormRegisterAluno extends Frame {

	private Button btnOk = new Button("Ok");
	private Button btnLimpar = new Button("Limpar");
	private Button btnMostrar = new Button("Mostrar");
	private Button btnSair = new Button("Sair");
	private Label lblNome = new Label("Nome:");
	private Label lblIdade = new Label("Idade:");
	private Label lblEnd = new Label("Endereço:");
	private TextField txtNome = new TextField();
	private TextField txtIdade = new TextField();
	private TextField txtEndereco = new TextField();

	private List<Aluno> listaAlunos = new ArrayList<>();

	public FormRegisterAluno() {
		setTitle("TP02 - LP2");
		setSize(400, 180);
		setLayout(new BorderLayout());

		Panel pnlSuperior = new Panel();
		pnlSuperior.setLayout(new GridLayout(3, 2, 10, 10));
		pnlSuperior.add(lblNome);
		pnlSuperior.add(txtNome);
		pnlSuperior.add(lblIdade);
		pnlSuperior.add(txtIdade);
		pnlSuperior.add(lblEnd);
		pnlSuperior.add(txtEndereco);

		Panel pnlInferior = new Panel();
		pnlInferior.setLayout(new GridLayout(1, 4));
		pnlInferior.add(btnOk);
		pnlInferior.add(btnLimpar);
		pnlInferior.add(btnMostrar);
		pnlInferior.add(btnSair);

		add(pnlSuperior, BorderLayout.CENTER);
		add(pnlInferior, BorderLayout.SOUTH);

		btnOk.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				try {
					String nome = txtNome.getText();
					int idade = Integer.parseInt(txtIdade.getText());
					String endereco = txtEndereco.getText();

					Aluno novoAluno = new Aluno(nome, idade, endereco);
					listaAlunos.add(novoAluno);

					JOptionPane.showMessageDialog(null, "Aluno cadastrado com sucesso!");
					limparCampos();
				} catch (NumberFormatException ex) {
					JOptionPane.showMessageDialog(null, "Erro: A idade deve ser um número válido.", "Erro de Entrada",
							JOptionPane.ERROR_MESSAGE);
				} catch (IllegalArgumentException ex) {
					JOptionPane.showMessageDialog(null, "Erro: " + ex.getMessage(), "Erro de Entrada",
							JOptionPane.ERROR_MESSAGE);
				}
			}
		});

		btnLimpar.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				limparCampos();
			}
		});

		btnMostrar.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				if (listaAlunos.isEmpty()) {
					JOptionPane.showMessageDialog(null, "Nenhum aluno cadastrado.");
					return;
				}
				StringBuilder mensagem = new StringBuilder();
				for (Aluno aluno : listaAlunos) {
					mensagem.append("Id: ").append(aluno.getUUID().toString())
							.append(" Nome: ").append(aluno.getNome()).append("\n");
				}
				JOptionPane.showMessageDialog(null, mensagem.toString(), "Alunos Cadastrados",
						JOptionPane.INFORMATION_MESSAGE);
			}
		});

		btnSair.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				System.exit(0);
			}
		});

		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent we) {
				System.exit(0);
			}
		});

		setVisible(true);
	}

	private void limparCampos() {
		txtNome.setText("");
		txtIdade.setText("");
		txtEndereco.setText("");
		txtNome.requestFocus();
	}

	public static void main(String[] args) {
		new FormRegisterAluno();
	}
}