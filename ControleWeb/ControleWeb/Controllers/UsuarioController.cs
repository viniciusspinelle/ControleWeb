using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleServices.Business;
using Entities;
using System.Security.Cryptography;
using System.Text;


namespace ControleWeb.Controllers
{
    public class UsuarioController : Controller
    {
        JQueryDataTableParamModel param = new JQueryDataTableParamModel();
        UsuarioBusiness _usuarioBusiness = new UsuarioBusiness();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Usuario usuario)
        {
            var Usuario = _usuarioBusiness.GetAll(usuario, param);
            try
            {
                return Json(new
                {
                    draw = param.draw,
                    iTotalRecords = param.length,
                    iTotalDisplayRecords = Usuario.Count,
                    data = Usuario.ListaUsuario,
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
            Usuario _usuario = new Usuario();
            if (Id != 0)
            {
                return View(_usuarioBusiness.GetUsuario(Id));

            }
            else
            {
                return View(_usuarioBusiness.GetUsuario(Id));
            }

        }

        [HttpPost]
        public ActionResult Edit(Usuario usario)
        {
            try
            {
                _usuarioBusiness.AlterUsuario(usario);
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


            try
            {
                _usuarioBusiness.RemoveUsuario(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Response.StatusCode = 574; 
                Response.TrySkipIisCustomErrors = true;                
                return View("Index");
            }
            
        }


    }
}
