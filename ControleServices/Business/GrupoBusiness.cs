using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ControleServices.Repository;

namespace ControleServices.Business
{
    public class GrupoBusiness
    {
        GrupoRepository _grupoRepository = new GrupoRepository();

        public Grupo GetAll(Grupo grupo, JQueryDataTableParamModel param)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                return _grupoRepository.GetAll(db, grupo, param);
            }
        }

        public Grupo GetGrupo(long Id)
        {
            
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
               return  _grupoRepository.GetGrupo(db,Id);
               
            }

        }

        public void Alter_Grupo(Grupo grupo)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {

                if (grupo.ID == 0)
                {
                    _grupoRepository.Insert(db, grupo);
                }
                else
                {
                    _grupoRepository.Update(db, grupo);
                }
                db.SaveChanges();

            }
        }

        public void Remove(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                _grupoRepository.Delete(db, Id);
                db.SaveChanges();
            }
        }

    }
}
