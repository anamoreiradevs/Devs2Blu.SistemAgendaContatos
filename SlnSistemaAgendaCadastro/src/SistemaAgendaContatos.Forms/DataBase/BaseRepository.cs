using MySql.Data.MySqlClient;
using SistemAgendaContatos.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAgendaContatos.Forms.DataBase
{
    public class BaseRepository
    {
        public string Table { get; set; }

        public BaseRepository(string table)
        {
            Table = table;
        }

        public StatusEnum GetStatus(string status)
        {
            if (status.Equals(StatusEnum.I))
            {
                return StatusEnum.I;
            }
            if (status.Equals(StatusEnum.A))
            {
                return StatusEnum.A;
            }
            if (status.Equals(StatusEnum.C))
            {
                return StatusEnum.C;
            }
            if (status.Equals(StatusEnum.R))
            {
                return StatusEnum.R;
            }
            return StatusEnum.A;
        }
        #region Executes

        public MySqlDataReader FindById(int id)
        {
            string sqlFind = SQL_FIND_BY_ID.Replace("@TABLE", Table)
                                           .Replace("@ID", id.ToString());
            return Get(sqlFind);
        }
        public MySqlDataReader Get(string sqlGet)
        {
            MySqlConnection conn = ConnectionMysql.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlGet, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                return dataReader;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public int Insert(string columns, string values)
        {
            MySqlConnection conn = ConnectionMysql.GetConnection();

            try
            {
                string sqlInsert = SQL_INSERT.Replace("@TABLE", Table)
                                             .Replace("@COLUMNS", columns)
                                             .Replace("@VALUES", values);
                MySqlCommand cmd = new MySqlCommand(sqlInsert, conn);
                cmd.ExecuteNonQuery();

                return (int)cmd.LastInsertedId;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public int Update(string columns, int id)
        {
            MySqlConnection conn = ConnectionMysql.GetConnection();

            try
            {
                string sqlInsert = SQL_UPDATE.Replace("@TABLE", Table)
                                             .Replace("@COLUMNS", columns);
                MySqlCommand cmd = new MySqlCommand(sqlInsert, conn);
                cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
                return cmd.ExecuteNonQuery();

            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public MySqlDataReader GetAll()
        {
            MySqlConnection conn = ConnectionMysql.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_ALL.Replace("@TABLE", Table), conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                return dataReader;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public bool DeleteById(int id)
        {
            MySqlConnection conn = ConnectionMysql.GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_DELETE_BY_ID.Replace("@TABLE", Table), conn);
                cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        #endregion


        #region SQLs
        private const string SQL_SELECT_ALL = @"SELECT * FROM @TABLE";
        private const string SQL_FIND_BY_ID = @"SELECT * FROM @TABLE WHERE id = @ID";
        private const string SQL_DELETE_BY_ID = @"DELETE FROM @TABLE WHERE id = @ID";
        private const string SQL_INSERT = @"INSERT INTO @TABLE (@COLUMNS) VALUES (@VALUES)";
        private const string SQL_UPDATE = @"UPDATE @TABLE SET @COLUMNS WHERE id = @ID";
        #endregion

    }
}
