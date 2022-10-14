using SistemAgendaContatos.Models.Enum;
using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SistemAgendaContatos.Models.Model
{
    public class Contato
    {
        public Int32 Id { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String Celular { get; set; }
        public String Email { get; set; }
        public String Rua { get; set; }
        public int Numero { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String UF { get; set; }
        public StatusEnum Status { get; set; }

        public Contato()
        {

        }

        public Contato(Int32? id, String nome, String telefone, String celular, String email, String rua, Int32? numero, String bairro, String cidade, String uF, StatusEnum? status)
        {
            Id = (int)id;
            Nome = nome;
            Telefone = telefone;
            Celular = celular;
            Email = email;
            Rua = rua;
            Numero = (int)numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
            Status = (StatusEnum)status;
        }
    }


}
