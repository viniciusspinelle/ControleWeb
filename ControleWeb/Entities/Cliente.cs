using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cliente
    {
        public long ID { get; set; }
        public long ID_Projeto { get; set; }
        public string RazaoSocial { get; set; }
        public string CPFCNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public string EmailDescricao { get; set; }
        public string TelefoneDescricao { get; set; }
        public string ProjetoDescricao { get; set; }

        public int Count { get; set; }

        public List<Cliente> ListaCliente { get; set; }
        public List<TelefoneCliente> ListaTelefone { get; set; }
        public List<EmailCliente> ListaEmail { get; set; }
        public List<Projeto> ListaProjeto { get; set; }
    }
}
