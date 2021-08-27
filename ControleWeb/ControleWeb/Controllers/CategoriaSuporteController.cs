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
    public class CategoriaSuporteController : Controller
    {
        CategoriaSuporteBusiness _categoriasuporteBusiness = new CategoriaSuporteBusiness();
        JQueryDataTableParamModel param = new JQueryDataTableParamModel();
        // GET: CategoriaSuporte
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public JsonResult Index(CategoriaSuporte categoriasuporte)
        {
            var Categoriasuporte = _categoriasuporteBusiness.GetAll(categoriasuporte, param);
            try
            {
                return Json(new
                {
                    draw = param.draw,
                    iTotalRecords = param.length,
                    iTotalDisplayRecords = Categoriasuporte.Count,
                    data = Categoriasuporte.ListaCategoriaSuporte,
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
            CategoriaSuporte _categoriaSuporte = new CategoriaSuporte();
            if (Id != 0)
            {
                return View(_categoriasuporteBusiness.GetCategoriaSuporte(Id));

            }
            else
            {
                return View(_categoriasuporteBusiness.GetCategoriaSuporte(Id));
            }
        }

        [HttpPost]
        public ActionResult Edit(CategoriaSuporte categoriaSuporte)
        {
            try
            {
                _categoriasuporteBusiness.AlterProjeto(categoriaSuporte);
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
            _categoriasuporteBusiness.RemoveProjeto(Id);
            return RedirectToAction("Index");
        }


    }
}
