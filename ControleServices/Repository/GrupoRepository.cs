using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ControleServices.Repository
{
    public class GrupoRepository
    {
         public Grupo GetAll (CONTROLEEEntities db, Grupo grupo, JQueryDataTableParamModel param)
        {
            var data = (from G in db.GRUPO
                    select new Grupo {
                        ID=G.ID,
                        Descricao = G.DESCRICAO,
                    }).ToList();

            if (param.search != null)
            {
                data.Where(c => c.Descricao.Contains(param.search));
            }

            grupo.Count = data.Count();

            var query = param.length != 0 ? data.Skip(param.start).Take(param.length) : data;

            grupo.ListaGrupo = data.ToList();
            return grupo;
        }

        public Grupo GetGrupo(CONTROLEEEntities db, long Id)
        {
            var _grupo = (from G in db.GRUPO
                            where G.ID == Id
                            select new Grupo
                            {
                                ID = G.ID,
                                Descricao= G.DESCRICAO,                               
                            }).FirstOrDefault();

            return _grupo;
        }

        public List<Grupo> ListGrupo(CONTROLEEEntities db)
        {
            return (from G in db.GRUPO
                    select new Grupo
                    {
                        ID = G.ID,
                        Descricao = G.DESCRICAO,
                    }).ToList();
        }

        //Insert
        public void Insert(CONTROLEEEntities db, Grupo grupo)
        {
            GRUPO _GRUPO = new GRUPO();

            _GRUPO.DESCRICAO = grupo.Descricao;

            db.GRUPO.Add(_GRUPO);
        }

        public void Update(CONTROLEEEntities db, Grupo grupo)
        {
            var _grupo = (from G in db.GRUPO
                            where G.ID == grupo.ID
                            select G).FirstOrDefault();

            _grupo.DESCRICAO = grupo.Descricao;
          
        }

        public void Delete(CONTROLEEEntities db, long Id)
        {
            var _grupo = (from G in db.GRUPO
                            where G.ID == Id
                            select G).FirstOrDefault();
            db.GRUPO.Remove(_grupo);
        }
    }
}
