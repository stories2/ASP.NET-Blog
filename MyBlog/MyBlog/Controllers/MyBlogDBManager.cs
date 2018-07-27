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

        public List<Article> GetLatestArticeList(int pageNum = DefineManager.DEFAULT_PAGE_NUM, int limit = DefineManager.LIMIT_OF_SHOW_ARTICLES)
        {
            List<Article> latestArticleList = myBlogEntities.Article
                .Where(article => article.isDelete == DefineManager.NOT_DELETED_ARTICLE)
                .OrderByDescending(article => article.articleID)
                .Skip((pageNum - 1) * limit)
                .Take(limit).ToList();
            return latestArticleList;
        }

        public int GetCountOfArticleList()
        {
            int articleListCount = myBlogEntities.Article
                .Where(article => article.isDelete == DefineManager.NOT_DELETED_ARTICLE)
                .Count();
            return articleListCount;
        }

        public Article GetDetailOfArticle(int articleID)
        {
            Article article = null;
            try
            {
                article = myBlogEntities.Article
                    .Where(articleModel => articleModel.isDelete == DefineManager.NOT_DELETED_ARTICLE)
                    .Where(articleModel => articleModel.articleID == articleID).First<Article>();
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
                article.isDelete = DefineManager.NOT_DELETED_ARTICLE;
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