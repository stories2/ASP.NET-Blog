using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Controllers
{
    public class MyBlogDBManager
    {
        MyBlogEntities myBlogEntities { get; set; }

        public MyBlogDBManager(MyBlogEntities myBlogEntities = null)
        {
            this.myBlogEntities = myBlogEntities;
        }

        public List<Article> GetLatestArticeList(int limit = DefineManager.LIMIT_OF_SHOW_ARTICLES)
        {
            List<Article> latestArticleList = myBlogEntities.Article.OrderByDescending(article => article.articleID).Take(limit).ToList();
            return latestArticleList;
        }

        public int GetCountOfArticleList()
        {
            int articleListCount = myBlogEntities.Article.Count();
            return articleListCount;
        }
    }
}