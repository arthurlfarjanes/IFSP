using Microsoft.Data.Sqlite;
using ProjAcessoDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjAcessoDB
{
    public static class AcessoDB
    {
        private const string DB_FILE = "acessos.db";
        private static string ConnectionString = $"Data Source={DB_FILE}";

        public static void InicializarDB()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                string sqlUsuario = @"CREATE TABLE IF NOT EXISTS Usuario (
                                        Id INTEGER PRIMARY KEY,
                                        Nome TEXT NOT NULL
                                      );";

                string sqlAmbiente = @"CREATE TABLE IF NOT EXISTS Ambiente (
                                         Id INTEGER PRIMARY KEY,
                                         Nome TEXT NOT NULL
                                       );";

                string sqlLog = @"CREATE TABLE IF NOT EXISTS Log (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    DtAcesso TEXT NOT NULL,
                                    TipoAcesso INTEGER NOT NULL,
                                    UsuarioId INTEGER NOT NULL,
                                    AmbienteId INTEGER NOT NULL,
                                    FOREIGN KEY(UsuarioId) REFERENCES Usuario(Id),
                                    FOREIGN KEY(AmbienteId) REFERENCES Ambiente(Id)
                                  );";

                string sqlPermissao = @"CREATE TABLE IF NOT EXISTS Permissao (
                                          UsuarioId INTEGER NOT NULL,
                                          AmbienteId INTEGER NOT NULL,
                                          PRIMARY KEY (UsuarioId, AmbienteId),
                                          FOREIGN KEY(UsuarioId) REFERENCES Usuario(Id) ON DELETE CASCADE,
                                          FOREIGN KEY(AmbienteId) REFERENCES Ambiente(Id) ON DELETE CASCADE
                                        );";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sqlUsuario + sqlAmbiente + sqlLog + sqlPermissao;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void SalvarDados(List<Usuario> usuarios, List<Ambiente> ambientes)
        {
            InicializarDB();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM Log; DELETE FROM Permissao; DELETE FROM Ambiente; DELETE FROM Usuario;";
                        command.ExecuteNonQuery();
                    }

                    foreach (var u in usuarios)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Usuario (Id, Nome) VALUES (@id, @nome);";
                            command.Parameters.AddWithValue("@id", u.Id);
                            command.Parameters.AddWithValue("@nome", u.Nome);
                            command.ExecuteNonQuery();
                        }
                    }

                    foreach (var a in ambientes)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Ambiente (Id, Nome) VALUES (@id, @nome);";
                            command.Parameters.AddWithValue("@id", a.Id);
                            command.Parameters.AddWithValue("@nome", a.Nome);
                            command.ExecuteNonQuery();
                        }
                    }

                    foreach (var u in usuarios)
                    {
                        foreach (var a in u.Ambientes)
                        {
                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = "INSERT INTO Permissao (UsuarioId, AmbienteId) VALUES (@uid, @aid);";
                                command.Parameters.AddWithValue("@uid", u.Id);
                                command.Parameters.AddWithValue("@aid", a.Id);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    foreach (var a in ambientes)
                    {
                        var logsParaSalvar = a.LogsParaPersistencia
                                              .OrderByDescending(l => l.DtAcesso)
                                              .Take(Ambiente.MAX_LOGS)
                                              .ToList();

                        foreach (var log in logsParaSalvar)
                        {
                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = "INSERT INTO Log (DtAcesso, TipoAcesso, UsuarioId, AmbienteId) VALUES (@dt, @tipo, @uid, @aid);";
                                command.Parameters.AddWithValue("@dt", log.DtAcesso.ToString("o"));
                                command.Parameters.AddWithValue("@tipo", log.TipoAcesso ? 1 : 0);
                                command.Parameters.AddWithValue("@uid", log.UsuarioId);
                                command.Parameters.AddWithValue("@aid", log.AmbienteId);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        public static (List<Usuario> Usuarios, List<Ambiente> Ambientes) CarregarDados()
        {
            InicializarDB();

            List<Usuario> usuarios = new List<Usuario>();
            List<Ambiente> ambientes = new List<Ambiente>();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id, Nome FROM Usuario;";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario(reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id, Nome FROM Ambiente;";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ambientes.Add(new Ambiente(reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT UsuarioId, AmbienteId FROM Permissao;";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int uId = reader.GetInt32(0);
                            int aId = reader.GetInt32(1);

                            var usuario = usuarios.FirstOrDefault(u => u.Id == uId);
                            var ambiente = ambientes.FirstOrDefault(a => a.Id == aId);

                            if (usuario != null && ambiente != null)
                            {
                                usuario.ConcederPermissao(ambiente);
                            }
                        }
                    }
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id, DtAcesso, TipoAcesso, UsuarioId, AmbienteId FROM Log ORDER BY DtAcesso ASC;";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var log = new Log();
                            log.Id = reader.GetInt32(0);
                            log.DtAcesso = DateTime.Parse(reader.GetString(1));
                            log.TipoAcesso = reader.GetInt32(2) == 1;
                            log.UsuarioId = reader.GetInt32(3);
                            log.AmbienteId = reader.GetInt32(4);

                            log.Usuario = usuarios.FirstOrDefault(u => u.Id == log.UsuarioId);

                            var ambiente = ambientes.FirstOrDefault(a => a.Id == log.AmbienteId);
                            if (ambiente != null)
                            {
                                ambiente.LogsParaPersistencia.Add(log);
                            }
                        }
                    }
                }
            }

            foreach (var ambiente in ambientes)
            {
                var logsOrdenados = ambiente.LogsParaPersistencia
                                          .OrderBy(l => l.DtAcesso)
                                          .TakeLast(Ambiente.MAX_LOGS);

                ambiente.Logs.Clear();
                foreach (var log in logsOrdenados)
                {
                    ambiente.Logs.Enqueue(log);
                }
            }

            return (usuarios, ambientes);
        }
    }
}