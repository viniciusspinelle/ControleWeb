using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using System.Web.Mvc;

namespace ControleWeb.DataTables
{
    public class DataTablesRequestBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            JQueryDataTableParamModel obj = new JQueryDataTableParamModel();
            var request = controllerContext.HttpContext.Request.Params;

            obj.start = Convert.ToInt32(request["start"]);
            obj.length = Convert.ToInt32(request["length"]);
            obj.draw = Convert.ToInt32(request["draw"]);
            obj.search = request["search[value]"].ToString();

            return obj;
        }
    }
}