using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ControleServices.Utils;

namespace ControleServices.Repository
{
   public class ProjetoRepository
    {
        public Projeto GetAll(CONTROLEEEntities db, Projeto projeto, JQueryDataTableParamModel param)
        {
            var data = (from P in db.PROJETO
                        join E in db.EMPRESA on P.ID_EMPRESA equals E.ID
                        select new Projeto
                        {
                            ID = P.ID,
                            ID_Empresa = P.ID_EMPRESA,
                            Descricao = P.DESCRICAO,
                            Data = P.DATA,
                            EmpresaDescricao= E.NOME

                        }).ToList();

            if (param.search != null)
            {
                data.Where(c => c.Descricao.Contains(param.search));
            }
            projeto.Count = data.Count();


            var query = param.length != 0 ? data.Skip(param.start).Take(param.length) : data;

            projeto.ListaProjeto = data.ToList();

            return projeto;
        }

        public Projeto GetProjeto(CONTROLEEEntities db, long Id)
        {
            var _projeto = (from P in db.PROJETO
                            where P.ID == Id
                            select new Projeto
                            {
                                ID = P.ID,
                                ID_Empresa = P.ID_EMPRESA,
                                Descricao = P.DESCRICAO,
                                                                                                
                            }).FirstOrDefault();

            return _projeto;

        }

        public List<Projeto> ListProjeto(CONTROLEEEntities db)
        {
            return (from P in db.PROJETO
                    select new Projeto
                    {
                        ID = P.ID,
                        Descricao = P.DESCRICAO,
                    }).ToList();

        }


        //Insert
        public void Insert(CONTROLEEEntities db, Projeto projeto)
        {
            PROJETO _PROJETO = new PROJETO();

            _PROJETO.ID_EMPRESA = projeto.ID_Empresa;
            _PROJETO.DESCRICAO = projeto.Descricao;
            _PROJETO.DATA = UtilsBusiness.GetData();

            db.PROJETO.Add(_PROJETO);
        }

        public void Update(CONTROLEEEntities db, Projeto projeto)
        {
            var _projeto = (from P in db.PROJETO
                            where P.ID == projeto.ID
                            select P).FirstOrDefault();

            _projeto.ID_EMPRESA = projeto.ID_Empresa;
            _projeto.DESCRICAO = projeto.Descricao;
            _projeto.DATA = UtilsBusiness.GetData();

        }

        public void Delete(CONTROLEEEntities db, long Id)
        {
            var _projeto = (from P in db.PROJETO
                            where P.ID == Id
                            select P).FirstOrDefault();
            db.PROJETO.Remove(_projeto);
        }
    }
}
