using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        public Usuario()
        {
            ListaGrupo = new List<Grupo>();
            ListaEmpresa = new List<Empresa>();
            ListaAcesso = new List<UsuarioProjeto>();
        }
        public long ID { get; set; }
        public long ID_Empresa { get; set; }
        public long ID_Grupo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool ? Supervisor { get; set; }
        public string Email { get; set; }

        public string GrupoDescricao { get; set; }
        public string EmpresaDescricao { get; set; }

       
        public long ID_Projeto { get; set; }

        public int Count { get; set; }
        public List<Usuario> ListaUsuario { get; set; }

        public List<Grupo> ListaGrupo { get; set; }
        public List<Empresa> ListaEmpresa { get; set; }
        public List<Projeto> ListaProjeto { get; set; }
        public List<UsuarioProjeto>ListaAcesso { get; set;}
    }
}
