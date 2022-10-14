using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAgendaContatos.Forms.DataBase
{
    public class EstadoRepository : BaseRepository
    {

        public EstadoRepository() : base("estados")
        {

        }
    }
}