﻿using System.Web;
using System.Web.Optimization;

namespace MyBlog
{
    public class BundleConfig
    {
        // 번들 작성에 대한 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=301862 링크를 참조하십시오.
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Modernizr의 개발 버전을 사용하여 개발하고 배우십시오. 그런 다음
            // 프로덕션할 준비가 되면 http://modernizr.com 링크의 빌드 도구를 사용하여 필요한 테스트만 선택하십시오.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Blog/js").Include(
                "~/Template/assets/js/jquery.scrollex.min.js",
                "~/Template/assets/js/jquery.scrolly.min.js",
                "~/Template/assets/js/browser.min.js",
                "~/Template/assets/js/breakpoints.min.js",
                "~/Template/assets/js/util.js",
                "~/Template/assets/js/main.js",
                "~/Template/custom/js/settings/DefineManager.js",
                "~/Template/custom/js/utils/LogManager.js",
                "~/Template/custom/js/core/TabMenuManager.js",
                "~/Template/custom/js/core/AuthManager.js",
                "~/Template/custom/js/view/MyBlogBigLayoutManager.js",
                "~/Template/custom/js/core/DataTransferManager.js",
                "~/Template/custom/js/core/UserManager.js",
                "~/Template/custom/js/view/SignInLayoutManager.js"
                ));

            bundles.Add(new ScriptBundle("~/Blog/Angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-*",
                "~/Scripts/app/*.js",
                "~/Scripts/app/service/*.js"
                ).IncludeDirectory(
                      "~/Scripts/app", "*.js"));

            bundles.Add(new StyleBundle("~/Blog/css").Include(
                "~/Template/assets/css/main.css",
                "~/Template/assets/css/noscript.css",
                "~/Template/assets/css/font-awesome.min.css",
                "~/Template/custom/css/Profile.css"
                ));

            bundles.Add(new StyleBundle("~/Blog/Angular/css").Include(
                "~/Content/angular-*"
                ));
        }
    }
}
