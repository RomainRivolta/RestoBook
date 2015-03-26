using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace RestoBook.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/boostrap")
                .Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/js/modernizr")
                .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/js/jquery")
                .Include("~/Scripts/jquery-2.1.3.min.js"));

            bundles.Add(new ScriptBundle("~/js/jqueryval")
                .Include("~/Scripts/jquery.validate*")
                .Include("~/Scripts/jquery.validate.unobtrusive*"));

            bundles.Add(new StyleBundle("~/css")
                .Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Style/Site.css", new CssRewriteUrlTransform()));
            

            BundleTable.EnableOptimizations = true;
        }
    }
}