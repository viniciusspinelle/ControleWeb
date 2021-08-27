using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HistoricoSuporte
    {
        public HistoricoSuporte()
        {
            ListaCliente = new List<Cliente>();
        }
        public long ID { get; set; }       
        public long ID_Cliente { get; set; }
        public string Nome { get; set; }

       public List<Cliente> ListaCliente { get; set; }
       public List<HistoricoSuporteItens> ListaItens { get; set; }
    }
}
