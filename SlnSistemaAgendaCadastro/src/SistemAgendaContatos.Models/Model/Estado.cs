using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemAgendaContatos.Models.Model
{
    public class Estado
    {
        public Int32 ID { get; set; }
        public String UF { get; set; }
        public String Descricao { get; set; }

        public Estado(int iD, string uF, string descricao)
        {
            ID = iD;
            UF = uF;
            Descricao = descricao;
        }
    }
}
