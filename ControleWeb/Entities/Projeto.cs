using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Projeto
    {
        public long ID { get; set; }
        public long ID_Empresa { get; set; }
        public string Descricao { get; set; }
        public DateTime ? Data { get; set; }
        public bool Status { get; set; }

        public int Count { get; set; }
        public string EmpresaDescricao { get; set; }

        public List<Projeto> ListaProjeto { get; set; }
        public List<Empresa> ListaEmpresa { get; set; } 
    }
}
