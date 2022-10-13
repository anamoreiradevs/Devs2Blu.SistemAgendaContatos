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
        public String Email { get; set; }
        public String Rua { get; set; }
        public Int32 Numero { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public StatusContatos Status { get; set; }

        public Contato()
        {
            Status = StatusContatos.A;
        }
        public Contato(Int32 id, String nome, String email, String rua, Int32 numero, String bairro, String cidade, StatusContatos status )
        {
            Id = id;
            Nome = nome;
            Email = email;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Status = status;
        }
       
        
    }

    
}
