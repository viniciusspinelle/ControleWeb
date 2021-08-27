using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ControleServices.Repository;

namespace ControleServices.Business
{
    public class ProjetoBusiness
    {
        ProjetoRepository _projetoRepository = new ProjetoRepository();
        EmpresaRepository _empresaRepository = new EmpresaRepository();

        public Projeto GetAll(Projeto projeto, JQueryDataTableParamModel param)
        {                
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                Projeto _projeto = new Projeto();
                _projeto = _projetoRepository.GetAll(db, projeto, param);
                return _projeto;

            }
        }


        public Projeto GetProjeto(long Id)
        {

            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                Projeto _projeto = new Projeto();
                if (Id != 0)
                {
                    _projeto =_projetoRepository.GetProjeto(db, Id);
                    _projeto.ListaEmpresa = _empresaRepository.ListEmpresa(db);
                }
                else
                {
                    _projeto.ListaEmpresa = _empresaRepository.ListEmpresa(db);
                }
                return _projeto;
            }

        }

        public void AlterProjeto(Projeto projeto)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {

                if (projeto.ID == 0)
                {
                    _projetoRepository.Insert(db, projeto);
                }
                else
                {
                    _projetoRepository.Update(db, projeto);
                }
                db.SaveChanges();
            }
        }

        public void RemoveProjeto(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                _projetoRepository.Delete(db, Id);
                db.SaveChanges();
            }
        }
    }
}
