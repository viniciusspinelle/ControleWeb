using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Entities;
using System.Web.Mvc;

namespace ControleWeb.App_Start
{
    public static class DataTablesConfig
    {
        public static void RegisterDataTables()
        {
            if (!ModelBinders.Binders.ContainsKey(typeof(JQueryDataTableParamModel)))
                ModelBinders.Binders.Add(
                    typeof(JQueryDataTableParamModel),
                    new DataTables.DataTablesRequestBinder());
        }
    }
}