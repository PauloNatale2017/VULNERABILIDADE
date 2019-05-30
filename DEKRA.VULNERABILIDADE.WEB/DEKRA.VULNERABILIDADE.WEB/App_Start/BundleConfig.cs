﻿using System.Web;
using System.Web.Optimization;

namespace DEKRA.VULNERABILIDADE.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            // Package Layout New
            bundles.Add(new ScriptBundle("~/LayoutPackages/css").Include(
                "~/LayoutPackages/css/component.css",
                "~/LayoutPackages/css/demo.css",
                "~/LayoutPackages/css/normalize.css"));

            // Package Layout New
            bundles.Add(new ScriptBundle("~/LayoutPackages/js").Include(
                 "~/LayoutPackages/js/classie.js",
                 "~/LayoutPackages/js/gnmenu.js",
                 "~/LayoutPackages/js/modernizr.custom.js"));


            // Package Layout New
            bundles.Add(new ScriptBundle("~/ScriptsAngular/js").Include(
                  "~/Scripts/jquery-3.2.1.js",
                  "~/Scripts/bootstrap.js",       
                  "~/Scripts/angular.js",
                  "~/Scripts/angular-block-ui.js",
                  "~/Scripts/angular-animate.js",
                  "~/Scripts/angular-touch.js",
                  "~/Scripts/angular-route.js",
                  "~/Scripts/angular-cookies.js",
                  "~/Scripts/Chart.js",
                  "~/Scripts/fusioncharts.min.js",
                  "~/Scripts/fusioncharts.charts.min.js",
                  "~/Scripts/angular-fusioncharts.min.js",             
                  "~/Scripts/ui-grid.js"));



            bundles.Add(new ScriptBundle("~/Scripts/UiTreeView/js").Include(
               //"~/Scripts/UiTreeView/angular-1.5.0.js",
               "~/Scripts/UiTreeView/angular.js",
               "~/Scripts/UiTreeView/ui-grid.min-4.0.2.js"));

            bundles.Add(new ScriptBundle("~/Scripts/UiTreeView/css").Include(
                "~/Scripts/UiTreeView/ui-grid.min.css"));
 

            // Package Layout New
            bundles.Add(new ScriptBundle("~/ContentAngular/css").Include(
                 "~/ContentAngular/bootstrap.css",
                 "~/ContentAngular/bootstrap.min.css",
                 "~/ContentAngular/angular-block-ui.css", 
                 "~/Content/site.css"));

           
        }
    }
}
