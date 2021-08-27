using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ControleServices;
using ControleServices.Utils;

namespace ControleServices.Repository
{
   public class AssuntoSuporteRepository
    {
        public AssuntoSuporte GetAll(CONTROLEEEntities db, AssuntoSuporte assuntoSuporte, JQueryDataTableParamModel param)
        {
            var data = (from AS in db.ASSUNTO_SUPORTE
                        join CS in db.CATEGORIA_SUPORTE on AS.ID_CATEGORIA equals CS.ID
                        join U in db.USUARIO on AS.ID_USUARIO equals U.ID
                        select new AssuntoSuporte
                        {
                            ID = AS.ID,
                            Descricao = AS.DESCRICAO,
                            Data = Convert.ToDateTime(AS.DATA),
                            UsuarioDescricao = U.LOGINN,
                            CategoriaDescricao= CS.DESCRICAO,                           

                        }).ToList();

            if (param.search != null)
            {
                data.Where(c => c.Descricao.Contains(param.search));
            }
            assuntoSuporte.Count = data.Count();


            var query = param.length != 0 ? data.Skip(param.start).Take(param.length) : data;

            assuntoSuporte.ListaAssuntoSuporte = data.ToList();

            return assuntoSuporte;
        }


        public AssuntoSuporte GetAssuntoSuporte(CONTROLEEEntities db, long Id)
        {
            var _assunto = (from AS in db.ASSUNTO_SUPORTE
                            where AS.ID == Id
                            select new AssuntoSuporte
                            {
                                ID = AS.ID,
                                ID_Usuario = AS.ID_USUARIO,
                                ID_Categoria  = AS.ID_CATEGORIA,
                                Descricao= AS.DESCRICAO,
                                Link_Manual= AS.LINK_MANUAL,
                                Link_Video = AS.LINK_VIDEO
                            }).FirstOrDefault();

            return _assunto;

        }

        public List<AssuntoSuporte> getAssunto(CONTROLEEEntities db,long Id)
        {
            return (from AS in db.ASSUNTO_SUPORTE
                    join CS in db.CATEGORIA_SUPORTE on AS.ID_CATEGORIA equals CS.ID
                    where CS.ID == Id
                    select new AssuntoSuporte
                    {
                        ID = AS.ID,
                        Descricao = AS.DESCRICAO,
                        Link_Manual = AS.LINK_MANUAL,
                        Link_Video = AS.LINK_VIDEO
                    }).ToList();

        }

        public List<AssuntoSuporte> ListAssunto(CONTROLEEEntities db)
        {
            return (from AS in db.ASSUNTO_SUPORTE
                    select new AssuntoSuporte
                    {
                        ID = AS.ID,
                        Descricao= AS.DESCRICAO
                    }).ToList();

        }

        //Insert
        public void Insert(CONTROLEEEntities db, AssuntoSuporte assuntoSuporte)
        {
            ASSUNTO_SUPORTE _ASSUNTOSUPORTE = new ASSUNTO_SUPORTE();

            _ASSUNTOSUPORTE.ID_CATEGORIA = assuntoSuporte.ID_Categoria;
            _ASSUNTOSUPORTE.ID_USUARIO = assuntoSuporte.ID_Usuario;
            _ASSUNTOSUPORTE.LINK_MANUAL = assuntoSuporte.Link_Manual;
            _ASSUNTOSUPORTE.LINK_VIDEO = assuntoSuporte.Link_Video;
            _ASSUNTOSUPORTE.DESCRICAO = assuntoSuporte.Descricao;
            _ASSUNTOSUPORTE.DATA = UtilsBusiness.GetData();

            db.ASSUNTO_SUPORTE.Add(_ASSUNTOSUPORTE);
        }

        public void Update(CONTROLEEEntities db,AssuntoSuporte assuntoSuporte)
        {
            var _assunto = (from AS in db.ASSUNTO_SUPORTE
                            where AS.ID == assuntoSuporte.ID
                            select AS).FirstOrDefault();

            _assunto.ID_CATEGORIA = assuntoSuporte.ID_Categoria;
            _assunto.ID_USUARIO = assuntoSuporte.ID_Usuario;
            _assunto.LINK_MANUAL = assuntoSuporte.Link_Manual;
            _assunto.LINK_VIDEO = assuntoSuporte.Link_Video;
            _assunto.DESCRICAO = assuntoSuporte.Descricao;
            //_assunto.DATA= UtilsBusiness.GetData();


        }

        public void Delete(CONTROLEEEntities db, long Id)
        {
            var _assunto = (from AS in db.ASSUNTO_SUPORTE
                            where AS.ID == Id
                            select AS).FirstOrDefault();
            db.ASSUNTO_SUPORTE.Remove(_assunto);
        }
    }
}

