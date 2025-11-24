import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;
import java.sql.SQLException;

public class CriarBanco {

    public static void main(String[] args) {
        String url = "jdbc:sqlite:aulajava.db";

        String sqlCargos = "CREATE TABLE IF NOT EXISTS tbcargos (" +
                "cd_cargo INTEGER PRIMARY KEY," + 
                "ds_cargo TEXT" + 
                ");";

        String sqlFuncs = "CREATE TABLE IF NOT EXISTS tbfuncs (" +
                "cod_func INTEGER PRIMARY KEY," + 
                "nome_func TEXT," +
                "sal_func REAL," + 
                "cod_cargo INTEGER," +
                "FOREIGN KEY(cod_cargo) REFERENCES tbcargos(cd_cargo)" +
                ");";

        String insertCargos = "INSERT INTO tbcargos (cd_cargo, ds_cargo) VALUES " +
                "(1, 'Administrativo'), " +
                "(2, 'Desenvolvedor'), " +
                "(3, 'Gerente');";

        String insertFuncs = "INSERT INTO tbfuncs (cod_func, nome_func, sal_func, cod_cargo) VALUES " +
                "(1, 'Marcelo', 2000.00, 1), " +
                "(2, 'Ana Silva', 4500.50, 2), " +
                "(3, 'Carlos Souza', 3000.00, 1), " +
                "(4, 'Maria Oliveira', 8000.00, 3);";

        try (Connection conn = DriverManager.getConnection(url);
             Statement stmt = conn.createStatement()) {

            stmt.execute(sqlCargos);
            stmt.execute(sqlFuncs);
            System.out.println("Tabelas criadas com sucesso!");

            stmt.execute("DELETE FROM tbfuncs;");
            stmt.execute("DELETE FROM tbcargos;");

            stmt.execute(insertCargos);
            stmt.execute(insertFuncs);
            System.out.println("Dados iniciais inseridos!");

        } catch (SQLException e) {
            System.out.println("Erro ao criar banco: " + e.getMessage());
        }
    }
}