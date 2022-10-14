using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemAgendaContatos.Models.Model
{
    public class Estado
    {
        public int Id { get; set; }
        public string UF { get; set; }
        public string Descricao { get; set; }
        public Estado()
        {

        }
        public Estado(int id, string uf, string descricao)
        {
            Id = id;
            UF = uf;
            Descricao = descricao;
        }
    }
}
