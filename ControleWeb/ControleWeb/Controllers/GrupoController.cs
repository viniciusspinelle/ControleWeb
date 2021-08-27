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
    public class GrupoController : Controller
    {
        GrupoBusiness _grupoBusiness = new GrupoBusiness();
        JQueryDataTableParamModel param = new JQueryDataTableParamModel();

        // GET: Grupo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Grupo grupo)
        {
            var Grupo = _grupoBusiness.GetAll(grupo, param);
            try
            {
                return Json(new
                {
                    draw = param.draw,
                    iTotalRecords = param.length,
                    iTotalDisplayRecords = Grupo.Count,
                    data = Grupo.ListaGrupo,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Json(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult Edit(long Id = 0)
        {
            Grupo _grupo = new Grupo();
            if (Id != 0)
            {
                return View(_grupoBusiness.GetGrupo(Id));

            }
            return View(_grupo);
        }

        [HttpPost]
        public ActionResult Edit(Grupo grupo)
        {
            try
            {
                _grupoBusiness.Alter_Grupo(grupo);
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

            _grupoBusiness.Remove(Id);
            return RedirectToAction("Index");

        }
    }
}
