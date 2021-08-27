using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entities
{
   public class HistoricoSuporteItens
    {

        public long ID { get; set; }
        public long ID_Usuario { get; set; }
        public long ID_AssuntoSuporte { get; set; }
        public long ID_HistoricoSuporte { get; set; }
        public DateTime? Data { get; set; }
        public string Nome_Cliente { get; set; }
        public string Clinica_Cliente { get; set; }
        public string Observacao { get; set; }
        public long ID_CategoriaSuporte { get; set; }

        public long ID_Cliente { get; set; }

        public List<HistoricoSuporteItens> ListaItens { get; set; }
        public List<AssuntoSuporte> ListaAssunto { get; set; }
        public List<CategoriaSuporte>ListaCategoria { get; set; }

    }
}
