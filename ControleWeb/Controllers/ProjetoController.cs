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
    public class ProjetoController : Controller
    {

        JQueryDataTableParamModel param = new JQueryDataTableParamModel();
        ProjetoBusiness _projetoBusiness = new ProjetoBusiness();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Projeto projeto)
        {
            var Projeto = _projetoBusiness.GetAll(projeto, param);
            try
            {
                return Json(new
                {
                    draw = param.draw,
                    iTotalRecords = param.length,
                    iTotalDisplayRecords = Projeto.Count,
                    data = Projeto.ListaProjeto,
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
        public ActionResult Edit(long Id=0)
        {
            Projeto _projeto = new Projeto();
            if (Id != 0)
            {
                return View(_projetoBusiness.GetProjeto(Id));

            }
            else
            {
                return View(_projetoBusiness.GetProjeto(Id));
            }
        }

        [HttpPost]
        public ActionResult Edit(Projeto projeto)
        {
            try
            {
                _projetoBusiness.AlterProjeto(projeto);
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
            _projetoBusiness.RemoveProjeto(Id);
            return RedirectToAction("Index");
        }

    }
}
