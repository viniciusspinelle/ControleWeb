using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ControleServices.Utils;
using System.Data;


namespace ControleServices.Repository
{
    public class HistoricoSuporteItensRepository
    {
        public List<HistoricoSuporteItens> getHistoricos(CONTROLEEEntities db, long Id)
        {
            var data = (from HI in db.HISTORICO_SUPORTE_ITENS
                        join HS in db.HISTORICO_SUPORTE on HI.ID_HISTORICO_SUPORTE equals HS.ID
                        where HS.ID_CLIENTE == Id
                        select new HistoricoSuporteItens
                        {
                            ID = HI.ID,
                            ID_AssuntoSuporte = HI.ID_ASSUNTO_SUPORTE,
                            ID_HistoricoSuporte = HS.ID,
                            Data =  HI.DATA,
                            Observacao = HI.OBSERVACAO,
                            Nome_Cliente =HI.CLINICA_CLIENTE,
                            Clinica_Cliente = HI.CLINICA_CLIENTE,
                            ID_Usuario = HI.ID_USUARIO

                        }).ToList();
            return data;
        }

        public HistoricoSuporteItens getHistoricoItensById(CONTROLEEEntities db, long Id)
        {
            var data = (from HI in db.HISTORICO_SUPORTE_ITENS
                        where HI.ID == Id
                        select new HistoricoSuporteItens
                        {
                            ID = HI.ID,
                            ID_AssuntoSuporte = HI.ID_ASSUNTO_SUPORTE,
                            ID_HistoricoSuporte = HI.ID_HISTORICO_SUPORTE,
                            ID_CategoriaSuporte = HI.ID_CATEGORIA_SUPORTE,
                            Data = HI.DATA,
                            Observacao = HI.OBSERVACAO,
                            Nome_Cliente = HI.NOME_CLIENTE,
                            Clinica_Cliente = HI.CLINICA_CLIENTE,
                            ID_Usuario = HI.ID_USUARIO,
                        }).FirstOrDefault();

            return data;
        }

        public HISTORICO_SUPORTE_ITENS Insert(CONTROLEEEntities db, HistoricoSuporteItens historicoItens)
        {
            HISTORICO_SUPORTE_ITENS _ITENS = new HISTORICO_SUPORTE_ITENS();

            historicoItens.ID_Usuario = 11;

            _ITENS.ID_ASSUNTO_SUPORTE = historicoItens.ID_AssuntoSuporte;
            _ITENS.ID_HISTORICO_SUPORTE = historicoItens.ID_HistoricoSuporte;
            _ITENS.ID_CATEGORIA_SUPORTE = historicoItens.ID_CategoriaSuporte;
            _ITENS.ID_USUARIO = historicoItens.ID_Usuario;
            _ITENS.NOME_CLIENTE = historicoItens.Nome_Cliente;
            _ITENS.CLINICA_CLIENTE = historicoItens.Clinica_Cliente;
            _ITENS.OBSERVACAO = historicoItens.Observacao;
            _ITENS.DATA = UtilsBusiness.GetData();

            db.HISTORICO_SUPORTE_ITENS.Add(_ITENS);
            return _ITENS;


        }

        public HISTORICO_SUPORTE_ITENS Update(CONTROLEEEntities db, HistoricoSuporteItens historicoItens)
        {
            var _Itens = (from HI in db.HISTORICO_SUPORTE_ITENS
                          where HI.ID == historicoItens.ID
                          select HI).FirstOrDefault();

            
            _Itens.ID_ASSUNTO_SUPORTE = historicoItens.ID_AssuntoSuporte;
            _Itens.ID_CATEGORIA_SUPORTE = historicoItens.ID_CategoriaSuporte;
            _Itens.NOME_CLIENTE = historicoItens.Nome_Cliente;
            _Itens.CLINICA_CLIENTE = historicoItens.Clinica_Cliente;
            _Itens.OBSERVACAO = historicoItens.Observacao;

            return _Itens;
        }

        public HISTORICO_SUPORTE_ITENS Delete(CONTROLEEEntities db, long Id)
        {
            var _Itens = (from HI in db.HISTORICO_SUPORTE_ITENS
                          where HI.ID == Id
                          select HI).FirstOrDefault();

            db.HISTORICO_SUPORTE_ITENS.Remove(_Itens);
            return _Itens;
        }
    }
}
