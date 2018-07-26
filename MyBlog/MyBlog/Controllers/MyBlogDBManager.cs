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

        public List<Article> GetLatestArticeList(int limit = 5)
        {
            List<Article> latestArticleList = myBlogEntities.Article.OrderByDescending(article => article.articleID).Take(limit).ToList();
            return latestArticleList;
        }
    }
}