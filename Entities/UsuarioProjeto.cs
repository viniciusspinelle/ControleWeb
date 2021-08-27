using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UsuarioProjeto
    {
        public long ID { get; set; }
        public long ID_Usuario { get; set; }
        public long? ID_Projeto { get; set; }
    }
}
