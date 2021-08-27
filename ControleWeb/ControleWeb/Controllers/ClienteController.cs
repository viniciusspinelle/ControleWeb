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
    public class ClienteController : Controller
    {


        JQueryDataTableParamModel param = new JQueryDataTableParamModel();
        ClienteBusiness _clienteBusiness = new ClienteBusiness();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Cliente cliente)
        {
            var Cliente = _clienteBusiness.GetAll(cliente, param);
            try
            {
                return Json(new
                {
                    draw = param.draw,
                    iTotalRecords = param.length,
                    iTotalDisplayRecords = Cliente.Count,
                    data = Cliente.ListaCliente,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Json(ex.Message);
            }

        }

        public ActionResult getClientes(string Search)
       {
            return Json(new { cliente = _clienteBusiness.getCliente(Search) } , JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult Edit(long Id = 0)
        {
            Cliente _cliente = new Cliente();
            if (Id != 0)
            {
                return View(_clienteBusiness.GetCliente(Id));

            }
            else
            {
                return View(_clienteBusiness.GetCliente(Id));
            }

        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                _clienteBusiness.AlterCliente(cliente);
                return Json(JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;
                return Json(ex.Message);

            }
            return View();
        }

        public ActionResult Delete(long Id)
        {


            try
            {
                _clienteBusiness.RemoveCliente(Id);
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
