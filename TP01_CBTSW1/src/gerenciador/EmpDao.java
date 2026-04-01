// NOME: Adriano Junior de Souza Almeida
// NOME: Arthur Lanzilotti Farjanes
package gerenciador;

import java.util.*;
import java.sql.*;
import java.io.File;

public class EmpDao {
    
    private static final String dbURL = "jdbc:sqlite:banco_crud.db";

    public static Connection getConnection() {
        Connection con = null;
        try {
            Class.forName("org.sqlite.JDBC");
            con = DriverManager.getConnection(dbURL);
            criaTabela(con);
        } catch (Exception e) {
            System.err.println("Erro ao conectar: " + e.getMessage());
        }
        return con;
    }

    private static void criaTabela(Connection con) {
        String sql = "CREATE TABLE IF NOT EXISTS user905 (" +
                     "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                     "name TEXT, " +
                     "password TEXT, " +
                     "email TEXT, " +
                     "country TEXT)";
        try (Statement stmt = con.createStatement()) {
            stmt.execute(sql);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public static int save(Emp e) {
        int status = 0;
        String sql = "insert into user905(name,password,email,country) values (?,?,?,?)";
        // Try-with-resources: Garante o fechamento automático da conexão
        try (Connection con = getConnection(); 
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, e.getName());
            ps.setString(2, e.getPassword());
            ps.setString(3, e.getEmail());
            ps.setString(4, e.getCountry());
            status = ps.executeUpdate();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return status;
    }

    public static List<Emp> getAllEmployees() {
        List<Emp> list = new ArrayList<>();
        String sql = "select * from user905";
        try (Connection con = getConnection(); 
             PreparedStatement ps = con.prepareStatement(sql);
             ResultSet rs = ps.executeQuery()) {
            while (rs.next()) {
                Emp e = new Emp();
                e.setId(rs.getInt(1));
                e.setName(rs.getString(2));
                e.setPassword(rs.getString(3));
                e.setEmail(rs.getString(4));
                e.setCountry(rs.getString(5));
                list.add(e);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return list;
    }

    public static int delete(int id) {
        int status = 0;
        try (Connection con = getConnection(); 
             PreparedStatement ps = con.prepareStatement("delete from user905 where id=?")) {
            ps.setInt(1, id);
            status = ps.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return status;
    }

    public static Emp getEmployeeById(int id) {
        Emp e = new Emp();
        try (Connection con = getConnection(); 
             PreparedStatement ps = con.prepareStatement("select * from user905 where id=?")) {
            ps.setInt(1, id);
            try (ResultSet rs = ps.executeQuery()) {
                if (rs.next()) {
                    e.setId(rs.getInt(1));
                    e.setName(rs.getString(2));
                    e.setPassword(rs.getString(3));
                    e.setEmail(rs.getString(4));
                    e.setCountry(rs.getString(5));
                }
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return e;
    }

    public static int update(Emp e) {
        int status = 0;
        String sql = "update user905 set name=?,password=?,email=?,country=? where id=?";
        try (Connection con = getConnection(); 
             PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, e.getName());
            ps.setString(2, e.getPassword());
            ps.setString(3, e.getEmail());
            ps.setString(4, e.getCountry());
            ps.setInt(5, e.getId());
            status = ps.executeUpdate();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return status;
    }
}