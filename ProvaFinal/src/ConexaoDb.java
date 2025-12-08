import java.sql.Connection;
import java.sql.DriverManager;

public class ConexaoDb {

    private static final String URL = "jdbc:sqlite:pacientes.db";

    public static Connection getConnection() {
        try {
            return DriverManager.getConnection(URL);
        } catch (Exception e) {
            e.printStackTrace();
            throw new RuntimeException("Erro ao conectar ao banco.");
        }
    }
}

