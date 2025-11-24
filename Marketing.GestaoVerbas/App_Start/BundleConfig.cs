using System.Web;
using System.Web.Optimization;

namespace Marketing.GestaoVerbas
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Vendors/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/tether").Include(
                      "~/Vendors/tether/js/tether.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Vendors/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/slideandswipe").Include(
                      "~/Scripts/jquery.slideandswipe.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Vendors/bootstrap/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/tether").Include(
                      "~/Vendors/tether/css/tether.css",
                      "~/Vendors/tether/css/tether-theme-basic.css",
                      "~/Vendors/tether/css/tether-theme-arrows.css",
                      "~/Vendors/tether/css/tether-theme-arrows-dark.css"));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                "~/Content/fab.css",
                "~/Content/style.css"));
        }
    }
}
