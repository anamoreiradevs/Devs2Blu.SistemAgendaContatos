using MySql.Data.MySqlClient;
using SistemAgendaContatos.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAgendaContatos.Forms.DataBase
{
    public class ContatoRepository : BaseRepository
    {
        public ContatoRepository() : base("contatos")
        {

        }
        public Contato FindById(int id)
        {
            Contato contato = new Contato();
            var r = base.FindById(id);
            while (r.Read())
            {
                contato = new Contato(r.GetInt32("id"), r.GetString("nome"), r.GetString("telefone"), r.GetString("celular"), r.GetString("email"), r.GetString("rua"), r.GetInt32("numero"), r.GetString("bairro"), r.GetString("cidade"), r.GetString("uf"), GetStatus(r.GetString("status")));
            }

            return contato;
        }
    }
}

    