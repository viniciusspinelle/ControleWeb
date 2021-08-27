using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Empresa
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }        
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public List<Empresa> ListaEmpresa { get; set;}
        public int Count { get; set; }
    }
}
