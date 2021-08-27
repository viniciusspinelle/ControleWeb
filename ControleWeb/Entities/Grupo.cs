using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Grupo
    {
        public long ID { get; set; }
        public string Descricao { get; set; }
        public int Count { get; set; }

        public List<Grupo> ListaGrupo { get; set; }


    }
}
