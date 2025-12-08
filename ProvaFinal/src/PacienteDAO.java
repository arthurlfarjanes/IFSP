import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class PacienteDAO {

    public PacienteDAO() {
        criarTabela();
    }

    // CRIA TABELA SE NÃO EXISTIR
    private void criarTabela() {
        String sql = "CREATE TABLE IF NOT EXISTS pacientes (" +
                     "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                     "nome TEXT NOT NULL, " +
                     "idade INTEGER NOT NULL, " +
                     "peso REAL NOT NULL, " +
                     "altura REAL NOT NULL" +
                     ");";

        try (Connection conn = ConexaoDb.getConnection();
             Statement stmt = conn.createStatement()) {

            stmt.execute(sql);

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    // INSERE PACIENTE
    public void inserir(Paciente p) {
        String sql = "INSERT INTO pacientes (nome, idade, peso, altura) VALUES (?, ?, ?, ?)";

        try (Connection conn = ConexaoDb.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setString(1, p.getNome());
            stmt.setInt(2, p.getIdade());
            stmt.setFloat(3, p.getPeso());
            stmt.setFloat(4, p.getAltura());

            stmt.executeUpdate();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    // LISTA TODOS
    public List<Paciente> listarTodos() {
        List<Paciente> lista = new ArrayList<>();

        String sql = "SELECT * FROM pacientes";

        try (Connection conn = ConexaoDb.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql);
             ResultSet rs = stmt.executeQuery()) {

            while (rs.next()) {
                Paciente p = new Paciente();
                p.setId(rs.getInt("id"));
                p.setNome(rs.getString("nome"));
                p.setIdade(rs.getInt("idade"));
                p.setPeso(rs.getFloat("peso"));
                p.setAltura(rs.getFloat("altura"));

                lista.add(p);
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

        return lista;
    }

    // PESQUISA POR NOME (LIKE)
    public List<Paciente> pesquisarPorNome(String nome) {
        List<Paciente> lista = new ArrayList<>();

        String sql = "SELECT * FROM pacientes WHERE nome LIKE ?";

        try (Connection conn = ConexaoDb.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setString(1, "%" + nome + "%");

            ResultSet rs = stmt.executeQuery();

            while (rs.next()) {
                Paciente p = new Paciente();
                p.setId(rs.getInt("id"));
                p.setNome(rs.getString("nome"));
                p.setIdade(rs.getInt("idade"));
                p.setPeso(rs.getFloat("peso"));
                p.setAltura(rs.getFloat("altura"));

                lista.add(p);
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

        return lista;
    }

}
