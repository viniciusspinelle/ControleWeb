using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EmailCliente
    {
        public long ID { get; set; }
        public long ID_Cliente { get; set; }
        public string Email { get; set; }
        public bool Principal { get; set; }

        public List<EmailCliente> ListEmail { get; set; }
    }
}
