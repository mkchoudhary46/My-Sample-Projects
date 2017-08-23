using System.Web;
using System.Web.Optimization;

namespace CRUD_AngularJs_ASPNET_MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/vendors/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/vendors/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/vendors/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/vendors/bootstrap.js",
                      "~/Scripts/vendors/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularJS").Include(
                     "~/Scripts/vendors/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/customJS").Include(
                                 "~/Scripts/BookScripts/Module.js",
                                 "~/Scripts/BookScripts/Service.js",
                                 "~/Scripts/BookScripts/Controller.js",
                                 "~/Scripts/SpicyScripts/SpicyModule.js",
                                 "~/Scripts/SpicyScripts/SpicyController.js",
                                 "~/Scripts/SpicyScripts/SpicyService.js"
                                 ));
        }
    }
}
