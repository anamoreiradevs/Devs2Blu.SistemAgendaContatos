using SistemAgendaContatos.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemAgendaContatos.Models.Model
{
    public class Compromisso
    {
        public Int32 Id { get; set; }
        public String Descricao { get; set; }
        public DateTime Data { get; set; }
        public StatusCompromisso Status { get; set; }

        public Compromisso()
        {
            Status = StatusCompromisso.A;
        }
        public Compromisso(int id, string descricao, DateTime data, StatusCompromisso status)
        {
            Id = id;
            Descricao = descricao;
            Data = data;
            Status = status;
        }
    }
}
