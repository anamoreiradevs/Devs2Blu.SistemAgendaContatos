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
        public int Id { get; set; }
      
        public string Descricacao { get; set; }
      
        public StatusEnum Status { get; set; }
        public DateTime  Data { get; set; }

        public Compromisso()
        {
           
        }

        public Compromisso(int id, string descricacao, StatusEnum status, DateTime data)
        {
            Id = id;
            Descricacao = descricacao;
            Status = status;
            Data = data;
        }
    }
}
