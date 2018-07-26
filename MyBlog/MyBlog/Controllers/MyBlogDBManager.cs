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

        public Article GetDetailOfArticle(int articleID)
        {
            Article article = null;
            try
            {
                article = myBlogEntities.Article.Where(articleModel => articleModel.articleID == articleID).First<Article>();
            }
            catch(Exception except)
            {
                LogManager.PrintLogMessage("MyBlogDBManager", "GetDetailOfArticle", "article id: " + articleID + "cannot execute query: " + except, DefineManager.LOG_LEVEL_ERROR);
            }
            return article;
        }

        public void InsertNewArticle(Article article)
        {
            try
            {
                article.uploadDateTime = DateTime.Now;
                article.writer = DefineManager.DEFAULT_WRITER;
                myBlogEntities.Article.Add(article);
                myBlogEntities.SaveChanges();
            }
            catch(Exception except)
            {
                LogManager.PrintLogMessage("MyBlogDBManager", "InsertNewArticle", "cannot insert new article: " + article.articleID + " except: " + except, DefineManager.LOG_LEVEL_ERROR);
            }
        }
    }
}