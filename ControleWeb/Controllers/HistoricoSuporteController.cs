using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleServices;
using Entities;
using ControleServices.Business;

namespace ControleWeb.Controllers
{
    public class HistoricoSuporteController : Controller
    {

        HistoricoSuporteBusiness _historicoSuporteBusiness = new HistoricoSuporteBusiness();


        // GET: HistoricoSuporte
        public ActionResult Index(long Id=0)
        {
            ViewBag.ListaCategoria = _historicoSuporteBusiness.getCategoria(Id);
            //ViewBag.ListaAssunto = _historicoSuporteBusiness.getAssunto(Id);


            return View();
        }

        public ActionResult GetHistorico(long Id)
        {

            return Json(new { historico = _historicoSuporteBusiness.getHistoricos(Id) }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetHistoricoItens(long Id)
        {
            return Json(_historicoSuporteBusiness.getHistoricoItens(Id), JsonRequestBehavior.AllowGet);
        }

   

        [HttpGet]
        public ActionResult Edit(long Id=0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(HistoricoSuporteItens historicosuporteItens)
        {
            try
            {
              var historico =  _historicoSuporteBusiness.AlterHistorico(historicosuporteItens);
                return Json(new {historico},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete(long Id=0)
        {
           return Json(_historicoSuporteBusiness.RemoverHistoricoItens(Id));
            
        }

    }
}
