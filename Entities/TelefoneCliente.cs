using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TelefoneCliente
    {
        public long ID { get; set; }
        public long ID_Cliente { get; set; }
        public string Telefone { get; set; }
        public string Responsavel { get; set; }
        public bool Principal { get; set; }

        public List<TelefoneCliente>  ListFone { get; set; }
    }
}
