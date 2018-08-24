using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Controllers
{
    public class MyBlogDBManager
    {
        //MyBlogEntities myBlogEntities { get; set; }
        MyAspNetBlogEntities myAspNetBlogEntities { get; set; }

        //public MyBlogDBManager(MyBlogEntities myBlogEntities = null)
        //{
        //    this.myBlogEntities = myBlogEntities;
        //}

        public MyBlogDBManager(MyAspNetBlogEntities myAspNetBlogEntities)
        {
            this.myAspNetBlogEntities = myAspNetBlogEntities;
        }

        public List<Article> GetLatestArticeList(int pageNum = DefineManager.DEFAULT_PAGE_NUM, int limit = DefineManager.LIMIT_OF_SHOW_ARTICLES)
        {
            List<Article> latestArticleList = myAspNetBlogEntities.Article
                .Where(article => article.isDelete == DefineManager.NOT_DELETED_ARTICLE)
                .OrderByDescending(article => article.articleID)
                .Skip((pageNum - 1) * limit)
                .Take(limit).ToList();
            return latestArticleList;
        }

        public int GetCountOfArticleList()
        {
            int articleListCount = myAspNetBlogEntities.Article
                .Where(article => article.isDelete == DefineManager.NOT_DELETED_ARTICLE)
                .Count();
            return articleListCount;
        }

        public Article GetDetailOfArticle(int articleID)
        {
            Article article = null;
            try
            {
                article = myAspNetBlogEntities.Article
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
                //article.writer = DefineManager.DEFAULT_WRITER;
                myAspNetBlogEntities.Article.Add(article);
                myAspNetBlogEntities.SaveChanges();
            }
            catch(Exception except)
            {
                LogManager.PrintLogMessage("MyBlogDBManager", "InsertNewArticle", "cannot insert new article: " + article.articleID + " except: " + except, DefineManager.LOG_LEVEL_ERROR);
            }
        }

        public bool AppendNewUser(UserInfoModel userInfoModel)
        {
            try
            {
                LogManager.PrintLogMessage("MyBlogDBManager", "AppendNewUser", "try to append new user: " + userInfoModel.uid, DefineManager.LOG_LEVEL_DEBUG);
                bool userExistStatus = myAspNetBlogEntities.UserInfo.Any(userInfoModelFromDB => userInfoModelFromDB.uid == userInfoModel.uid);
                LogManager.PrintLogMessage("MyBlogDBManager", "AppendNewUser", "user exist status: " + userExistStatus, DefineManager.LOG_LEVEL_DEBUG);
                if(userExistStatus == false)
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.email = userInfoModel.email;
                    userInfo.uid = userInfoModel.uid;
                    userInfo.userDisplayName = userInfoModel.displayName;
                    myAspNetBlogEntities.UserInfo.Add(userInfo);
                    myAspNetBlogEntities.SaveChanges();
                    LogManager.PrintLogMessage("MyBlogDBManager", "AppendNewUser", "ok new user appended", DefineManager.LOG_LEVEL_INFO);
                }
                return true;
            }
            catch(Exception except)
            {
                LogManager.PrintLogMessage("MyBlogDBManager", "AppendNewUser", "failed to append new user: " + except, DefineManager.LOG_LEVEL_ERROR);
            }
            return false;
        }
    }
}