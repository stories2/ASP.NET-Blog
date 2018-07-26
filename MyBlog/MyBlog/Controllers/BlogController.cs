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
        public ActionResult Index()
        {
            ViewBag.latestArticleList = myBlogDBManager.GetLatestArticeList();
            ViewBag.articleListCount = myBlogDBManager.GetCountOfArticleList();
            return View();
        }
    }
}