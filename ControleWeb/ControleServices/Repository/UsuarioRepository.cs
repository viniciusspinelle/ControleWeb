using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ControleServices.Repository
{
    public class UsuarioRepository
    {
        public Usuario GetAll(CONTROLEEEntities db, Usuario usuario, JQueryDataTableParamModel param)
        {
            var data = (from U in db.USUARIO
                        join G in db.GRUPO on U.ID_GRUPO equals G.ID into g
                        from G in g.DefaultIfEmpty()
                        join E in db.EMPRESA on U.ID_EMPRESA equals E.ID
                        select new Usuario
                        {
                            ID = U.ID,
                            ID_Empresa = U.ID_EMPRESA,
                            ID_Grupo = U.ID_GRUPO,
                            Login = U.LOGINN,
                            Senha = U.SENHA,
                            Supervisor = U.SUPERVISOR,
                            GrupoDescricao = G.DESCRICAO,
                            EmpresaDescricao = E.NOME,

                        }).ToList();

            if (param.search != null)
            {
                data.Where(c => c.Login.Contains(param.search));
            }
            usuario.Count = data.Count();


            var query = param.length != 0 ? data.Skip(param.start).Take(param.length) : data;

            usuario.ListaUsuario = data.ToList();

            foreach(Usuario item in usuario.ListaUsuario)
            {
                if(item.ID_Grupo == null)
                {
                    item.GrupoDescricao = "SUPERVISOR"; 
                }
            }
            return usuario;
        }

        public Usuario GetUsuario(CONTROLEEEntities db, long Id)
        {
            var _usuario = (from U in db.USUARIO
                            where U.ID == Id
                            select new Usuario
                            {
                                ID = U.ID,
                                ID_Empresa = U.ID_EMPRESA,
                                ID_Grupo = U.ID_GRUPO,
                                Login = U.LOGINN,
                                Senha = U.SENHA,
                                Supervisor = U.SUPERVISOR,
                                Email = U.EMAIL,
                            }).FirstOrDefault();

            return _usuario;

        }

        public bool Exist(CONTROLEEEntities db, Usuario usuario)
        {
            var _usuario = (from U in db.USUARIO
                            where U.LOGINN == usuario.Login && U.SENHA == usuario.Senha
                            select U).FirstOrDefault();

            return _usuario == null ? false : true;
        }


        public List<Usuario> ListUsuario(CONTROLEEEntities db)
        {
            return (from U in db.USUARIO
                    select new Usuario
                    {
                        ID = U.ID,
                        Login= U.LOGINN
                    }).ToList();

        }

        //Insert
        public USUARIO Insert(CONTROLEEEntities db, Usuario usuario)
        {
            USUARIO _USUARIO = new USUARIO();

            _USUARIO.ID_EMPRESA = usuario.ID_Empresa;
            _USUARIO.ID_GRUPO = usuario.ID_Grupo;
            _USUARIO.LOGINN = usuario.Login;
            _USUARIO.SENHA = usuario.Senha;
            _USUARIO.SUPERVISOR = Convert.ToBoolean(usuario.Supervisor);
            _USUARIO.EMAIL = usuario.Email;


            db.USUARIO.Add(_USUARIO);
            db.SaveChanges();
            return _USUARIO;

            
        }

        public void Update(CONTROLEEEntities db, Usuario usuario)
        {
            var _usuario = (from U in db.USUARIO
                            where U.ID == usuario.ID
                            select U).FirstOrDefault();

            _usuario.ID_GRUPO = usuario.ID_Grupo;
            _usuario.ID_EMPRESA = usuario.ID_Empresa;
            _usuario.LOGINN = usuario.Login;
            _usuario.SUPERVISOR = Convert.ToBoolean(usuario.Supervisor);
            _usuario.EMAIL = usuario.Email;

        }

        public void Delete(CONTROLEEEntities db, long Id)
        {
            var _usuario = (from U in db.USUARIO
                            where U.ID == Id
                            select U).FirstOrDefault();
            db.USUARIO.Remove(_usuario);
        }
    }
}
