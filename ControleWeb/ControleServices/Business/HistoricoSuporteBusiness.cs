using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ControleServices.Repository;

namespace ControleServices.Business
{
    public class HistoricoSuporteBusiness
    {
        HistoricoSuporteRepository _historicoRepository = new HistoricoSuporteRepository();
        HistoricoSuporteItensRepository _historicoItensRepository = new HistoricoSuporteItensRepository();
        CategoriaSuporteRepository _categoriaSuporteRepository = new CategoriaSuporteRepository();
        AssuntoSuporteRepository _assuntoSuporteRepository = new AssuntoSuporteRepository();


        HistoricoSuporte _historicoSuporte = new HistoricoSuporte();
        HistoricoSuporteItens _historicoItens = new HistoricoSuporteItens();
        HISTORICO_SUPORTE_ITENS HISTORICO_ITEN = new HISTORICO_SUPORTE_ITENS(); //BANCO DE DADOS 
        long IdItens = 0;

        public List<HistoricoSuporteItens> getHistoricos(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                return _historicoItensRepository.getHistoricos(db, Id);

            }
        }

        public HistoricoSuporteItens getHistoricoItens(long Id)  // PAREI NESSA FUNÇÃO COMEÇAR AQUI SEGUNDA FEIRA 
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                
                _historicoItens = _historicoItensRepository.getHistoricoItensById(db, Id);
                _historicoItens.ListaAssunto = _assuntoSuporteRepository.ListAssunto(db);

                foreach (var item in _historicoItens.ListaAssunto)
                {
                    if(item.ID == _historicoItens.ID_AssuntoSuporte)
                    {
                        _historicoItens.ListaAssunto.Add(item);
                    }                  


                }

                return _historicoItens; 
            }
        }

        public List<CategoriaSuporte> getCategoria(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                return _categoriaSuporteRepository.ListCategoria(db);
            }
        }

        public List<AssuntoSuporte> getAssunto(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                return _assuntoSuporteRepository.ListAssunto(db);
            }
        }

        public HistoricoSuporteItens AlterHistorico(HistoricoSuporteItens historicoItens)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                if (historicoItens.ID_HistoricoSuporte == 0)
                {
                    if (_historicoRepository.Exist(db, historicoItens.ID_Cliente) == false)
                    {
                        _historicoSuporte.ID_Cliente = historicoItens.ID_Cliente;

                        var HistoricoID = _historicoRepository.Insert(db, _historicoSuporte);
                        db.SaveChanges();

                        historicoItens.ID_HistoricoSuporte = HistoricoID.ID;
                    }
                    else
                    {
                        var HistoricoID = _historicoRepository.GetID(db, historicoItens.ID_Cliente);
                        historicoItens.ID_HistoricoSuporte = HistoricoID.ID;
                    };

                    if (historicoItens.ID == 0)
                    {
                        HISTORICO_ITEN = _historicoItensRepository.Insert(db, historicoItens);
                    }
                    else
                    {
                        HISTORICO_ITEN = _historicoItensRepository.Update(db, historicoItens);
                    }

                }
                else
                {
                    if (historicoItens.ID == 0)
                    {
                        HISTORICO_ITEN = _historicoItensRepository.Insert(db, historicoItens);
                    }
                    else
                    {
                        HISTORICO_ITEN = _historicoItensRepository.Update(db, historicoItens);
                    }
                }
                db.SaveChanges();
                IdItens = HISTORICO_ITEN.ID;
                historicoItens.Data = HISTORICO_ITEN.DATA;

                historicoItens.ID = IdItens;
                return historicoItens;
            }
        }

        public HistoricoSuporteItens RemoverHistoricoItens(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                HISTORICO_ITEN = _historicoItensRepository.Delete(db, Id);
                _historicoItens.ID = HISTORICO_ITEN.ID;
                db.SaveChanges();
            }
            return _historicoItens;
        }
    }
}

