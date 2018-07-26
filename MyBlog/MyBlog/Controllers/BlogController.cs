﻿using MyBlog.Models;
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

            //ViewBag.currentShowPage = 1;
            ViewBag.articleListCount = 40;
            return View();
        }
    }
}