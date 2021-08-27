using System.Web;
using System.Web.Optimization;

namespace ControleWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*")); 

            bundles.Add(new ScriptBundle("~/bundles/ControleWeb").Include(
                "~/Scripts/easing.js",
               "~/Scripts/toastr.js",
                "~/Scripts/moment.js",
                "~/Scripts/ControleWeb.js"));

            bundles.Add(new ScriptBundle("~/bundles/jstorage").Include(
             "~/Scripts/json2.js",
             "~/Scripts/jstorage.js"));

            bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                       "~/Scripts/typeahead.js"));



            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                       "~/Content/typeahead.css",
                     "~/Content/toastr.css"));

            bundles.Add(new ScriptBundle("~/bundles/blockUI").Include(
                                  "~/Scripts/jquery.blockUI.js"));

            bundles.Add(new ScriptBundle("~/bundles/Maskd").Include(
                                   "~/Scripts/Maskara.js",
                                   "~/Scripts/jquery-maskedinput.js")); 

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                                   "~/Scripts/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
                                   "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
                "~/Scripts/DataTables/jquery.dataTables.js"));


        }
    }
}
