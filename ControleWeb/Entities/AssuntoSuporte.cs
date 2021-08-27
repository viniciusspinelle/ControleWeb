using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AssuntoSuporte
    {
        public long ID { get; set; }
        public long ID_Categoria { get; set; }
        public long ID_Usuario { get; set; }
        public string Descricao { get; set; }
        public string Link_Manual { get; set; }
        public string Link_Video { get; set; }
        public DateTime Data { get; set; }

        public string CategoriaDescricao { get; set; }
        public string UsuarioDescricao { get; set; }
        public int Count { get; set; }

        public List<AssuntoSuporte> ListaAssuntoSuporte { get; set; }
        public List<CategoriaSuporte> ListaCategoria { get; set; }
        public List<Usuario> ListaUsuario { get; set; }
    }
}
