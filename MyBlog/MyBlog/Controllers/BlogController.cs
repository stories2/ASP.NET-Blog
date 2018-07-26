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

        public BlogController()
        {
            myBlogEntities = new MyBlogEntities();
            myBlogDBManager = new MyBlogDBManager(myBlogEntities);
        }

        // GET: Blog
        public ActionResult Index(int page = DefineManager.DEFAULT_SHOW_PAGE_NUMBER)
        {
            ViewBag.latestArticleList = myBlogDBManager.GetLatestArticeList();
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
        public ActionResult UploadNewArticle()
        {
            LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "user entered making new article", DefineManager.LOG_LEVEL_INFO);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadNewArticle(Article newArticle)
        {
            if (ModelState.IsValid)
            {
                LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "current token is valied", DefineManager.LOG_LEVEL_INFO);
            }
            else
            {
                LogManager.PrintLogMessage("BlogController", "UploadNewArticle", "current token is not valied", DefineManager.LOG_LEVEL_WARN);
            }
            return View();
        }

        [HttpGet]
        public ActionResult ShowSelectedArticle(int articleID = DefineManager.DEFAULT_SHOW_ARTICLE)
        {
            return View();
        }
    }
}