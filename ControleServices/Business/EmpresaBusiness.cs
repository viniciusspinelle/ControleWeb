using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ControleServices.Repository;


namespace ControleServices.Business
{
    public class EmpresaBusiness
    {
        EmpresaRepository _empresaRepository = new EmpresaRepository();

        public Empresa GetAll( Empresa empresa,JQueryDataTableParamModel param)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                return _empresaRepository.GetAll(db,empresa,param);
            }
        }

        public Empresa GetEmpresa(long Id)
        {
            
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {                
               return _empresaRepository.GetEmpresa(db, Id);
            }
           
        }

        public void Alter_Empresa(Empresa empresa)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                
                if(empresa.ID == 0)
                {
                  _empresaRepository.Insert(db,empresa);
                }
                else
                {
                    _empresaRepository.Update(db, empresa);
                }
                db.SaveChanges();
                
            }
        }

        public void Remove(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                _empresaRepository.Delete(db, Id);
                db.SaveChanges();
            }
        }

    }
}
