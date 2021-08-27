using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using ControleServices;
using ControleWeb.Models;
using Entities;
using ControleServices.Business;
using System.Web.Mvc;

namespace ControleWeb.Controllers
{
    public class EmpresaController : Controller
    {
        EmpresaBusiness _empresaBusiness = new EmpresaBusiness();

        JQueryDataTableParamModel param = new JQueryDataTableParamModel();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Empresa empresa)
        {
            var Empresa = _empresaBusiness.GetAll(empresa, param);
            try
            {
                return Json(new
                {
                    draw = param.draw,
                    iTotalRecords = param.length,
                    iTotalDisplayRecords = Empresa.Count,
                    data = Empresa.ListaEmpresa,
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
            Empresa empresa = new Empresa();
            if (Id != 0)
            {
                return View(_empresaBusiness.GetEmpresa(Id));

            }
            return View(empresa);
        }

        [HttpPost]
        public ActionResult Edit(Empresa empresa)
        {
            try
            {
                _empresaBusiness.Alter_Empresa(empresa);
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

            _empresaBusiness.Remove(Id);
            return RedirectToAction("Index");

        }

    }
}
