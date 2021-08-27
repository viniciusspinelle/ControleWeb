using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class CategoriaSuporte
    {
        public long ID { get; set; }
        public string Descricao { get; set; }
        public long ID_Projeto { get; set; }

        public string ProjetoDescricao { get; set; }
        public int Count { get; set; }
        public List<CategoriaSuporte> ListaCategoriaSuporte { get; set; }
        public List<Projeto> ListaProjeto { get; set; }
    }
}
