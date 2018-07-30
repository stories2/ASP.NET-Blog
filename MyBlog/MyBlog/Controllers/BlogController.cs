using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        MyBlogEntities myBlogEntities;
        MyBlogDBManager myBlogDBManager;
        HttpsManager httpsManager;
        public BlogController()
        {
            myBlogEntities = new MyBlogEntities();
            myBlogDBManager = new MyBlogDBManager(myBlogEntities);
            httpsManager = new HttpsManager();
        }

        // GET: Blog
        public ActionResult Index(int page = DefineManager.DEFAULT_SHOW_PAGE_NUMBER)
        {
            ViewBag.latestArticleList = myBlogDBManager.GetLatestArticeList(page);
            ViewBag.articleListCount = myBlogDBManager.GetCountOfArticleList();
            ViewBag.limitOfPrintArticleInOnePage = DefineManager.LIMIT_OF_SHOW_ARTICLES;
            ViewBag.currentShowPage = page;
            ViewBag.pageNavigationSize = DefineManager.PAGE_NAVIGATION_SHOW_SIZE;

            LogManager.PrintLogMessage("BlogController", "Index", "current page: " + page + " article count: " + 
                ViewBag.articleListCount + " one page per print article limit: " + ViewBag.limitOfPrintArticleInOnePage + 
                " page navigation size: " + ViewBag.pageNavigationSize, DefineManager.LOG_LEVEL_INFO);

            return View();
        }

        [HttpGet]
        public ActionResult WriteNewArticle()
        {
            LogManager.PrintLogMessage("BlogController", "WriteNewArticle", "user entered making new article", DefineManager.LOG_LEVEL_INFO);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void UploadNewArticle(Article newArticle, string clientToken)
        {
            if (ModelState.IsValid)
            {
                LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "current token is valied", DefineManager.LOG_LEVEL_INFO);
                if(clientToken != null)
                {
                    LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "token is available?: " + clientToken, DefineManager.LOG_LEVEL_DEBUG);
                    httpsManager.IsTokenVerified(clientToken);
                    try
                    {
                        LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "article title: " + newArticle.title + " highlight: " +
                            newArticle.highlightText + " image url: " + newArticle.imgUrl + " content len: " + newArticle.articleContent.Length, DefineManager.LOG_LEVEL_DEBUG);
                        myBlogDBManager.InsertNewArticle(newArticle);
                    }
                    catch (Exception except)
                    {
                        LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "exception accepted while upload new article: " + except, DefineManager.LOG_LEVEL_ERROR);
                    }
                }
                else
                {
                    LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "token is null", DefineManager.LOG_LEVEL_WARN);
                }
            }
            else
            {
                LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "current token is not valied", DefineManager.LOG_LEVEL_WARN);
            }
            //return View();
            Response.Redirect("/Blog/Index");
        }

        [HttpGet]
        public ActionResult ShowSelectedArticle(int articleID = DefineManager.DEFAULT_SHOW_ARTICLE)
        {
            ViewBag.article = myBlogDBManager.GetDetailOfArticle(articleID);
            if(ViewBag.article == null)
            {
                LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "selected article is null", DefineManager.LOG_LEVEL_WARN);
                Response.Redirect("/Blog/Error");
                return null;
            }
            else
            {
                LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "selected article id: " + ViewBag.article.articleID, DefineManager.LOG_LEVEL_DEBUG);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Error()
        {
            ErrorModel errorModel = new ErrorModel();
            errorModel.errorTitle = "This is error title";
            errorModel.errorCode = "This is error detail code";

            ViewBag.errorModel = errorModel;

            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(UserInfoModel userInfoModel)
        {
            LogManager.PrintLogMessage("BlogController", "NewUser", "display name: " +
                userInfoModel.displayName + " email: " + userInfoModel.email + " uid: " + userInfoModel.uid, DefineManager.LOG_LEVEL_DEBUG);

            var resultMsg = new { msg="dev"};
            return Json(resultMsg, JsonRequestBehavior.AllowGet);
        }
    }
}