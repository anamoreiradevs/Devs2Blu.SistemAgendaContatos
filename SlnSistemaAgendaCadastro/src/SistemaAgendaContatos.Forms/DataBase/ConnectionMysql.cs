using System.Data.SqlClient;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SistemaAgendaContatos.Forms.DataBase
{
    public static class ConnectionMysql
    {
        public static String ConnectionString { get; set; }
        public static String Server { get; set; }
        public static String Database { get; set; }
        public static String User { get; set; }
        public static String Password { get; set; }

        public static MySqlConnection GetConnection()
        {
            Server = "localhost";
            Database = "agendacontatos";
            User = "root";
            Password = "mysql";
            ConnectionString = $"Persist Security Info=False;Convert Zero Datetime=True;server={Server};database={Database};uid={User};server={Server};uid={User};pwd='{Password}'";
            var conn = new MySqlConnection(ConnectionString);

            try
            {
                conn.Open();
            }
            catch (MySqlException myex)
            {
                MessageBox.Show(myex.Message, "Erro ao Conectar");
                throw;
            }
            return conn;
        }
    }
}
