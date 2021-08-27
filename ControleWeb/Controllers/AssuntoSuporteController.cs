using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleServices;
using ControleServices.Business;
using Entities;

namespace ControleWeb.Controllers
{
    public class AssuntoSuporteController : Controller
    {
        AssuntoSuporteBusiness _assuntoSuporteBusiness = new AssuntoSuporteBusiness();
        JQueryDataTableParamModel param = new JQueryDataTableParamModel();

        // GET: AssuntoSuporte
        public ActionResult Index()
        {
            
            return View();
        }

        

        [HttpPost]
        public JsonResult Index(AssuntoSuporte assuntoSuporte)
        {
            var AssuntoSuporte = _assuntoSuporteBusiness.GetAll(assuntoSuporte, param);
            try
            {
                return Json(new
                {
                    draw = param.draw,
                    iTotalRecords = param.length,
                    iTotalDisplayRecords = AssuntoSuporte.Count,
                    data = AssuntoSuporte.ListaAssuntoSuporte,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Json(ex.Message);
            }

        }

        public ActionResult GetAssunto(long Id=0)
        {
            return Json(_assuntoSuporteBusiness.getAssunto(Id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(long Id = 0)
        {
            AssuntoSuporte _assuntosuporte = new AssuntoSuporte();
            if (Id != 0)
            {
                return View(_assuntoSuporteBusiness.GetAssuntoSuporte(Id));

            }
            else
            {
                return View(_assuntoSuporteBusiness.GetAssuntoSuporte(Id));
            }
        }

        [HttpPost]
        public ActionResult Edit(AssuntoSuporte assuntoSuporte)
        {
            try
            {
                _assuntoSuporteBusiness.Alter_AssuntoSuporte(assuntoSuporte);
                return Json(JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Json(ex.Message);
            }
        }

        public ActionResult Delete(long Id)
        {

            _assuntoSuporteBusiness.Remove_AssuntoSuporte(Id);
            return RedirectToAction("Index");

        }
    }
}
