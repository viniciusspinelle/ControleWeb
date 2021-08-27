using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace ControleServices.Repository
{
    public class CategoriaSuporteRepository
    {
        public CategoriaSuporte GetAll(CONTROLEEEntities db, CategoriaSuporte categoriaSuporte, JQueryDataTableParamModel param)
        {
            var data = (from CS in db.CATEGORIA_SUPORTE
                        join P in db.PROJETO on CS.ID_PROJETO equals P.ID
                        select new CategoriaSuporte
                        {
                            ID = CS.ID,
                            Descricao = CS.DESCRICAO,
                            ID_Projeto = CS.ID_PROJETO,
                            ProjetoDescricao = P.DESCRICAO

                        }).ToList();

            if (param.search != null)
            {
                data.Where(c => c.Descricao.Contains(param.search));
            }
            categoriaSuporte.Count = data.Count();


            var query = param.length != 0 ? data.Skip(param.start).Take(param.length) : data;

            categoriaSuporte.ListaCategoriaSuporte = data.ToList();

            return categoriaSuporte;
        }

        public CategoriaSuporte GetCategoriaProjeto(CONTROLEEEntities db, long Id)
        {
            var _categoriaSuporte = (from CS in db.CATEGORIA_SUPORTE
                            where CS.ID == Id
                            select new CategoriaSuporte
                            {
                                ID = CS.ID,
                                Descricao = CS.DESCRICAO,
                                ID_Projeto = CS.ID_PROJETO,

                            }).FirstOrDefault();

            return _categoriaSuporte;

        }

        public List<CategoriaSuporte> ListCategoria(CONTROLEEEntities db)
        {
            return (from CS in db.CATEGORIA_SUPORTE
                    select new CategoriaSuporte
                    {
                        ID = CS.ID,
                        Descricao= CS.DESCRICAO
                    }).ToList();

        }
        //Insert
        public void Insert(CONTROLEEEntities db, CategoriaSuporte categoriaSuporte)
        {
            CATEGORIA_SUPORTE _CATEGORIA_SUPORTE = new CATEGORIA_SUPORTE();
                       
            _CATEGORIA_SUPORTE.DESCRICAO = categoriaSuporte.Descricao;
            _CATEGORIA_SUPORTE.ID_PROJETO = categoriaSuporte.ID_Projeto;

            db.CATEGORIA_SUPORTE.Add(_CATEGORIA_SUPORTE);
        }

        public void Update(CONTROLEEEntities db, CategoriaSuporte categoriaSuporte)
        {
            var _categoriaSuporte = (from CS in db.CATEGORIA_SUPORTE
                            where CS.ID == categoriaSuporte.ID
                            select CS).FirstOrDefault();

            _categoriaSuporte.DESCRICAO = categoriaSuporte.Descricao;
            _categoriaSuporte.ID_PROJETO = categoriaSuporte.ID_Projeto;

        }

        public void Delete(CONTROLEEEntities db, long Id)
        {
            var _categoriaSuporte = (from CS in db.CATEGORIA_SUPORTE
                            where CS.ID == Id
                            select CS).FirstOrDefault();
            db.CATEGORIA_SUPORTE.Remove(_categoriaSuporte);
        }
    }
}
