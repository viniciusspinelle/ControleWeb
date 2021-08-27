using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleServices.Business;
using Entities;
using Microsoft.Ajax.Utilities;

namespace ControleWeb.Controllers
{
    public class LoginController : Controller
    {
        UsuarioBusiness _usuarioBusiness = new UsuarioBusiness();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (usuario.Login == null)
                    {
                        ModelState.AddModelError("error", "Digite o Login !!");
                        return View();
                    }
                    if (usuario.Senha == null)
                    {
                        ModelState.AddModelError("error", "Digite sua Senha !!");
                        return View();
                    }
                }
                _usuarioBusiness.Login(usuario);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                ModelState.AddModelError("error", ex.Message);

                return View("Login");
                
            }
        }
    }
}


