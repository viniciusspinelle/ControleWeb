using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ControleServices.Repository
{
    public class UsuarioProjetoRepository
    {

        public void Insert(CONTROLEEEntities db, Usuario usuario)
        {
            USUARIO_PROJETO _USUARIOPROJETO = new USUARIO_PROJETO();

            _USUARIOPROJETO.ID_USUARIO = usuario.ID;
            _USUARIOPROJETO.ID_PROJETO = usuario.ID_Projeto;

            db.USUARIO_PROJETO.Add(_USUARIOPROJETO);

        }

        public bool Exist(CONTROLEEEntities db, Usuario usuario)
        {
            var _usuario = (from UP in db.USUARIO_PROJETO
                            where UP.ID_USUARIO == usuario.ID && UP.ID_PROJETO == usuario.ID_Projeto
                            select UP).FirstOrDefault();

            return _usuario == null ? false : true;
        }

        public void Delete(CONTROLEEEntities db, Usuario usuario)
        {
            var _usuario = (from UP in db.USUARIO_PROJETO
                            where UP.ID_USUARIO == usuario.ID && UP.ID_PROJETO == usuario.ID_Projeto
                            select UP).FirstOrDefault();
            db.USUARIO_PROJETO.Remove(_usuario);
        }

        public List<UsuarioProjeto> ListAcesso(CONTROLEEEntities db, long Id)
        {
            var _usuarioProjeto =(from UP in db.USUARIO_PROJETO
                    where UP.ID_USUARIO== Id
                    select new UsuarioProjeto {

                        ID = UP.ID,
                        ID_Projeto= UP.ID_PROJETO,
                        ID_Usuario = UP.ID_USUARIO

                    }).ToList();

            return _usuarioProjeto;
        }
    }
}
