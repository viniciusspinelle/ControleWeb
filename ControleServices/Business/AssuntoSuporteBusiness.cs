using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ControleServices.Repository;

namespace ControleServices.Business
{
   public class AssuntoSuporteBusiness
    {
        AssuntoSuporteRepository _assuntoSuporteRepository = new AssuntoSuporteRepository();
        CategoriaSuporteRepository _categoriaSuporteRepository = new CategoriaSuporteRepository();
        UsuarioRepository _usuarioRepository = new UsuarioRepository();

        public AssuntoSuporte GetAll(AssuntoSuporte assuntosuporte, JQueryDataTableParamModel param)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                AssuntoSuporte _assuntoSuporte = new AssuntoSuporte();
                _assuntoSuporte = _assuntoSuporteRepository.GetAll(db, assuntosuporte, param);
                return _assuntoSuporte;

            }
        }

        public List<AssuntoSuporte> getAssunto(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
               return _assuntoSuporteRepository.getAssunto(db, Id);
            }
        }

        public AssuntoSuporte GetAssuntoSuporte(long Id)
        {

            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                AssuntoSuporte _assuntoSuporte = new AssuntoSuporte();
                if (Id != 0)
                {
                    _assuntoSuporte = _assuntoSuporteRepository.GetAssuntoSuporte(db, Id);
                    _assuntoSuporte.ListaCategoria = _categoriaSuporteRepository.ListCategoria(db);
                    _assuntoSuporte.ListaUsuario = _usuarioRepository.ListUsuario(db);
                }
                else
                {
                    _assuntoSuporte.ListaCategoria = _categoriaSuporteRepository.ListCategoria(db);
                    _assuntoSuporte.ListaUsuario = _usuarioRepository.ListUsuario(db);
                }
                return _assuntoSuporte;
            }
        }

        public void Alter_AssuntoSuporte(AssuntoSuporte assuntoSuporte)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {

                if (assuntoSuporte.ID == 0)
                {
                    _assuntoSuporteRepository.Insert(db, assuntoSuporte);
                }
                else
                {
                   _assuntoSuporteRepository.Update(db, assuntoSuporte);
                }
                db.SaveChanges();
            }
        }

        public void Remove_AssuntoSuporte(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                _assuntoSuporteRepository.Delete(db, Id);
                db.SaveChanges();
            }
        }
    }
}
