using System.Web;
using System.Web.Optimization;

namespace Adikov
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // JS SCRIPTS

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Content/assets/global/plugins/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Content/assets/global/plugins/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/coreJs").Include(
                "~/Content/assets/global/plugins/js.cookie.min.js",
                "~/Content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/assets/global/plugins/jquery.blockui.min.js",
                "~/Content/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/themeComponents").Include(
                "~/Content/assets/global/scripts/app.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                "~/Content/assets/layouts/layout2/scripts/layout.min.js"));

            // CSS STYLES

            bundles.Add(new StyleBundle("~/Content/globalCss").Include(
                "~/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                "~/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"));

            bundles.Add(new StyleBundle("~/Content/pageCss").Include(
                "~/Content/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css",
                "~/Content/assets/global/plugins/morris/morris.css",
                "~/Content/assets/global/plugins/fullcalendar/fullcalendar.min.css",
                "~/Content/assets/global/plugins/jqvmap/jqvmap/jqvmap.css"));

            bundles.Add(new StyleBundle("~/Content/themeCss").Include(
                "~/Content/assets/global/css/components.min.css",
                "~/Content/assets/global/css/plugins.min.css"));

            bundles.Add(new StyleBundle("~/Content/layoutCss").Include(
                "~/Content/assets/layouts/layout2/css/layout.min.css",
                "~/Content/assets/layouts/layout2/css/themes/blue.min.css",
                "~/Content/assets/layouts/layout2/css/custom.min.css"));
        }
    }
}
