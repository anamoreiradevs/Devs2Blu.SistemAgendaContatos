using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemAgendaContatos.Models.Enum
{
    public enum StatusContatos
    {
        [Description("Ativo")]
        A = 0,
        [Description("Inativo")]
        I = 1
    }
}
