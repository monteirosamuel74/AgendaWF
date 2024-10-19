using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace AgendaWF
{
    public class DALAgenda
    {
        public static string path = Directory.GetCurrentDirectory() + "\\banco.sqlite";
        private static SQLiteConnection sqliteConnection;

        private static SQLiteConnection DbConnection() 
        {
            sqliteConnection = new SQLiteConnection("Data Source=" + path);
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void CriarBancoSQLite()
        {
            try
            {
                if (File.Exists(path) == false)
                {
                    SQLiteConnection.CreateFile(path);
                }
            }
            catch 
            { 
                throw; 
            }
        }

        public static void CriarTabelaSQLite()
        {
            try
            {
                using(var cmd=DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Constatos(id int, nome VarChar(50), email VarChar(80))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public static DataTable GetContatos()
        {
            SQLiteDataAdapter adapter = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Contatos";
                    adapter = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetContato(int id)
        {
            SQLiteDataAdapter adapter = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Contato Where Id=" + id;
                    adapter = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Add(Contato contato)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Contatos(id, nome, email) values (@id, @nome, @email)";
                    cmd.Parameters.AddWithValue("@id", contato.Id);
                    cmd.Parameters.AddWithValue("@nome", contato.Nome);
                    cmd.Parameters.AddWithValue("@email", contato.Email);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(Contato contato)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "UPDATE Contatos SET Nome=@Nome, Email=@Email WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", contato.Id);
                    cmd.Parameters.AddWithValue("@Nome", contato.Nome);
                    cmd.Parameters.AddWithValue("@Email", contato.Email);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(Contato contato)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Contatos WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", contato.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
