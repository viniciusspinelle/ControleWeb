using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ControleServices.Repository;
using System.Security.Cryptography;
using System.Net.Mail;
using ControleServices.Utils;
using System.Data.SqlClient;

namespace ControleServices.Business
{
    public class UsuarioBusiness
    {
        UsuarioRepository _usuarioRepository = new UsuarioRepository();
        EmpresaRepository _empresaRepository = new EmpresaRepository();
        GrupoRepository _grupoRepository = new GrupoRepository();
        ProjetoRepository _projetoRepository = new ProjetoRepository();
        UsuarioProjetoRepository _usuarioProjetoRepository = new UsuarioProjetoRepository();

        public Usuario GetAll(Usuario usuario, JQueryDataTableParamModel param)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                Usuario _usuario = new Usuario();
                _usuario = _usuarioRepository.GetAll(db, usuario, param);
                return _usuario;

            }
        }

        //Metodo que verifica o login 
        public Usuario Login(Usuario usuario)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                usuario.Senha = UtilsBusiness.MD5Hash(usuario.Senha, "");
                if (_usuarioRepository.Exist(db, usuario) == true)
                {
                    return usuario;
                }
                else
                {
                    throw new Exception(" Usuario ou senha Invalido !!");
                }
            }

        }

        public Usuario GetUsuario(long Id)
        {

            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                
                Usuario _usuario = new Usuario();
                if (Id != 0)
                {
                    _usuario = _usuarioRepository.GetUsuario(db, Id);
                    _usuario.ListaGrupo = _grupoRepository.ListGrupo(db);
                    _usuario.ListaEmpresa = _empresaRepository.ListEmpresa(db);
                    _usuario.ListaProjeto = _projetoRepository.ListProjeto(db);
                    _usuario.ListaAcesso = _usuarioProjetoRepository.ListAcesso(db, Id);
                    
                    foreach(var item in _usuario.ListaProjeto)
                    {
                         var ExistUsuario = _usuario.ListaAcesso.Where(c => c.ID_Projeto == item.ID).FirstOrDefault();

                        if(ExistUsuario != null)
                        {
                            item.Status = true;
                        }
                        

                    }
                }
                else
                {
                    _usuario.ListaGrupo = _grupoRepository.ListGrupo(db);
                    _usuario.ListaEmpresa = _empresaRepository.ListEmpresa(db);
                    _usuario.ListaProjeto = _projetoRepository.ListProjeto(db);
                    foreach (var item in _usuario.ListaProjeto)
                    {
                        var ExistUsuario = _usuario.ListaAcesso.Where(c => c.ID_Projeto == item.ID).FirstOrDefault();

                        if (ExistUsuario != null)
                        {
                            item.Status = true;
                        }
                        else
                        {
                            item.Status = false;
                        }

                    }
                }
                return _usuario;
            }

        }


        public Usuario AlterUsuario(Usuario usuario)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                USUARIO _Usuario = new USUARIO();

                if (usuario.ID == 0)
                {
                    usuario.Senha = UtilsBusiness.MD5Hash("", usuario.Email);
                    _Usuario = _usuarioRepository.Insert(db, usuario);

                    foreach (var item in usuario.ListaProjeto)
                    {
                        if (item.Status == true)
                        {
                            usuario.ID = _Usuario.ID;
                            usuario.ID_Projeto = item.ID;
                            _usuarioProjetoRepository.Insert(db, usuario);
                        }
                    }
                }
                else
                {
                    _usuarioRepository.Update(db, usuario);


                    foreach (var item in usuario.ListaProjeto)
                    {
                        if (item.Status == true)
                        {
                            usuario.ID_Projeto = item.ID;
                            if (_usuarioProjetoRepository.Exist(db, usuario) == false)
                            {
                                usuario.ID = usuario.ID;
                                usuario.ID_Projeto = item.ID;
                                _usuarioProjetoRepository.Insert(db, usuario);
                            }
                        }
                        else
                        {
                            usuario.ID_Projeto = item.ID;
                            if (_usuarioProjetoRepository.Exist(db, usuario))
                            {                               
                                _usuarioProjetoRepository.Delete(db, usuario);
                            }
                        }
                    }
                }
                db.SaveChanges();

            }
            return usuario;
        }

        public void RemoveUsuario(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                try
                {
                    _usuarioRepository.Delete(db, Id);
                    db.SaveChanges();
                }
                catch (SqlException ex)
                {
                }
            }

        }
    }
}
