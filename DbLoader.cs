using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace AutoEBookBuilder
{
    public static class DbLoader
    {
        public static string databasePath = "..\\eBookBuilderSetup.db";
        static public void write(string tableName, string data)
        {
            using (var connection = new SQLiteConnection($"Data Source={databasePath}"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"
                CREATE TABLE IF NOT EXISTS {tableName} (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Content TEXT NOT NULL
                );";
                command.ExecuteNonQuery();

                command.CommandText = $@"
                INSERT INTO {tableName} (Content)
                VALUES ($content);";
                command.Parameters.AddWithValue("$content", data);
                command.ExecuteNonQuery();
            }
        }
        static public List<string> getAll(string tableName)
        {
            using (var connection = new SQLiteConnection($"Data Source={databasePath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Content FROM " + tableName + ";";

                using (var reader = command.ExecuteReader())
                {
                    var data = new System.Collections.Generic.List<string>();
                    while (reader.Read())
                    {
                        data.Add(reader.GetString(0));
                    }
                    return data;
                }
            }
        }
        static public void delete(string tableName)
        {
            using (var connection = new SQLiteConnection($"Data Source={databasePath}"))
            {
                connection.Open();
                string deleteQuery = $"DELETE FROM {tableName};";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} rows deleted.");
                }
            }
        }
        public static bool isValidId (string input, bool create)
        {
            string hash = ""; 
            using (SHA1 sha1 = System.Security.Cryptography.SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }
                hash = sb.ToString();
            }
            if (hash.Equals(""))
                return false;
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath}"))
            {
                try
                {
                    connection.Open();
                    string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS MyTable (
                        id TEXT UNIQUE
                    );";
                    using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    if (create)
                    {
                        string insertQuery = "INSERT INTO MyTable (id) VALUES (@id);";
                        using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@id", hash);
                            int rowsAffected = command.ExecuteNonQuery();
                        }
                    } 
                    else
                    {
                        using (SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM MyTable WHERE id = @id;", connection))
                        {
                            command.Parameters.AddWithValue("@id", hash);
                            int count = Convert.ToInt32(command.ExecuteScalar());
                            return count > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
            return true;
        }
    }
}
