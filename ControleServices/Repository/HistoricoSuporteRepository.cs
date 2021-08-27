using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ControleServices.Repository
{
    public class HistoricoSuporteRepository
    {

        public bool Exist(CONTROLEEEntities db, long Id)
        {
            var _historico = (from HS in db.HISTORICO_SUPORTE
                             where HS.ID_CLIENTE == Id
                             select HS).FirstOrDefault();

            return _historico == null ? false : true;
        }

        public HistoricoSuporte GetID(CONTROLEEEntities db, long Id)
        {
            var _historico = (from HS in db.HISTORICO_SUPORTE
                              where HS.ID_CLIENTE == Id
                              select new HistoricoSuporte {
                                  ID = HS.ID,
                              }).FirstOrDefault();

            return _historico;

        }

        //Insert
        public HISTORICO_SUPORTE Insert(CONTROLEEEntities db, HistoricoSuporte historicoSuporte)
        {
            HISTORICO_SUPORTE _HISTORICO = new HISTORICO_SUPORTE();

            _HISTORICO.ID_CLIENTE = historicoSuporte.ID_Cliente;
            
            db.HISTORICO_SUPORTE.Add(_HISTORICO);
            return _HISTORICO;


        }
    }
}
