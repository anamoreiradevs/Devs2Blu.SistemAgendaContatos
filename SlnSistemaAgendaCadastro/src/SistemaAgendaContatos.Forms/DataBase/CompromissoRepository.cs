using SistemAgendaContatos.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendaContatos.Forms.DataBase
{
    public class CompromissoRepository : BaseRepository
    {
        public CompromissoRepository() : base("compromissos")
        {

        }
        public Compromisso FindById(int id)
        {
            Compromisso compromisso = new Compromisso();
            var r = base.FindById(id);
            while (r.Read())
            {
                compromisso = new Compromisso(r.GetInt32("id"), r.GetString("descricao"), GetStatus(r.GetString("status")), r.GetString("data_compromisso"));
            }

            return compromisso;
        }
    }
}
