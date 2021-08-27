using ControleServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ControleServices.Business
{
    public class CategoriaSuporteBusiness
    {
        CategoriaSuporteRepository _categoriaSuporteRepository = new CategoriaSuporteRepository();
        ProjetoRepository _projetoRepository = new ProjetoRepository();

        public CategoriaSuporte GetAll(CategoriaSuporte categoriaSuporte, JQueryDataTableParamModel param)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                CategoriaSuporte _categoriaSuporte = new CategoriaSuporte();
                _categoriaSuporte = _categoriaSuporteRepository.GetAll(db, categoriaSuporte, param);
                return _categoriaSuporte;

            }
        }

        public CategoriaSuporte GetCategoriaSuporte(long Id)
        {

            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                CategoriaSuporte _categoriaSuporte = new CategoriaSuporte();
                if (Id != 0)
                {
                    _categoriaSuporte = _categoriaSuporteRepository.GetCategoriaProjeto(db, Id);
                    _categoriaSuporte.ListaProjeto = _projetoRepository.ListProjeto(db);
                }
                else
                {
                    _categoriaSuporte.ListaProjeto = _projetoRepository.ListProjeto(db);
                }
                return _categoriaSuporte;
            }
        }

        public void AlterProjeto(CategoriaSuporte categoriaSuporte)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {

                if (categoriaSuporte.ID == 0)
                {
                    _categoriaSuporteRepository.Insert(db, categoriaSuporte);
                }
                else
                {
                    _categoriaSuporteRepository.Update(db, categoriaSuporte);
                }
                db.SaveChanges();
            }
        }

        public void RemoveProjeto(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                _categoriaSuporteRepository.Delete(db, Id);
                db.SaveChanges();
            }
        }
    }
}
