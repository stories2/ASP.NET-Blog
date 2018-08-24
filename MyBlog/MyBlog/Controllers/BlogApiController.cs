using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBlog.Controllers
{
    public class BlogApiController : ApiController
    {
        //MyBlogEntities myBlogEntities;
        MyAspNetBlogEntities myAspNetBlogEntities;
        MyBlogDBManager myBlogDBManager;
        HttpsManager httpsManager;
        public BlogApiController()
        {
            //myBlogEntities = new MyBlogEntities();
            myAspNetBlogEntities = new MyAspNetBlogEntities();
            myBlogDBManager = new MyBlogDBManager(myAspNetBlogEntities);
            httpsManager = new HttpsManager();
        }

        [HttpGet]
        public Dictionary<string, object> SayHello()
        {
            Dictionary<string, object> resultMsg = new Dictionary<string, object>();
            resultMsg["message"] = "Hello";
            return resultMsg;
        }

        [HttpGet]
        public Dictionary<string, object> GetCurrentPageArticleInfo(int pageNumber = DefineManager.DEFAULT_SHOW_PAGE_NUMBER)
        {
            Dictionary<string, object> resultMsg = new Dictionary<string, object>();
            resultMsg["latestArticleList"] = myBlogDBManager.GetLatestArticeList(pageNumber);
            resultMsg["articleListCount"] = myBlogDBManager.GetCountOfArticleList();
            resultMsg["limitOfPrintArticleInOnePage"] = DefineManager.LIMIT_OF_SHOW_ARTICLES;
            resultMsg["currentShowPage"] = pageNumber;
            resultMsg["pageNavigationSize"] = DefineManager.PAGE_NAVIGATION_SHOW_SIZE;

            return resultMsg;
        }

        [HttpPost]
        public Dictionary<string, object> UploadNewArticle([FromBody] NewArticleModel newArticleModel)
        {
            Dictionary<string, object> resultMsg = new Dictionary<string, object>();
            resultMsg["result"] = DefineManager.RESULT_MSG_FAIL;

            try
            {
                Article newArticle = new Article();

                newArticle.articleContent = newArticleModel.articleContent;
                newArticle.highlightText = newArticleModel.highlightText;
                newArticle.title = newArticleModel.title;
                newArticle.imgUrl = newArticleModel.imgUrl;

                string clientToken = newArticleModel.clientToken;


                if (clientToken != null)
                {
                    LogManager.PrintLogMessage("BlogApiController", "UploadNewArticle", "token is available?: " + clientToken, DefineManager.LOG_LEVEL_DEBUG);
                    string userDisplayName = httpsManager.IsTokenVerified(clientToken);
                    if (userDisplayName != null)
                    {
                        try
                        {
                            newArticle.writer = userDisplayName;
                            LogManager.PrintLogMessage("BlogApiController", "UploadNewArticle", "article title: " + newArticle.title + " highlight: " +
                                newArticle.highlightText + " image url: " + newArticle.imgUrl + " content len: " + newArticle.articleContent.Length, DefineManager.LOG_LEVEL_DEBUG);
                            myBlogDBManager.InsertNewArticle(newArticle);
                            resultMsg["result"] = DefineManager.RESULT_MSG_OK;
                        }
                        catch (Exception except)
                        {
                            LogManager.PrintLogMessage("BlogApiController", "UploadNewArticle", "exception accepted while upload new article: " + except, DefineManager.LOG_LEVEL_ERROR);
                        }
                    }
                    else
                    {
                        LogManager.PrintLogMessage("BlogApiController", "UploadNewArticle", "cannot recognize user, so you cannot insert new article", DefineManager.LOG_LEVEL_WARN);
                    }
                }
                else
                {
                    LogManager.PrintLogMessage("BlogApiController", "UploadNewArticle", "token is null", DefineManager.LOG_LEVEL_WARN);
                }
            }
            catch(Exception error)
            {
                LogManager.PrintLogMessage("BlogApiController", "UploadNewArticle", "request error accured: " + error, DefineManager.LOG_LEVEL_ERROR);
            }
            return resultMsg;
        }

        [HttpGet]
        public Dictionary<string, object> ShowSelectedArticle(int articleID = DefineManager.DEFAULT_SHOW_ARTICLE)
        {
            Dictionary<string, object> resultMsg = new Dictionary<string, object>();
            resultMsg["article"] = myBlogDBManager.GetDetailOfArticle(articleID);
            return resultMsg;
        }

        [HttpPost]
        public Dictionary<string, object> NewUser([FromBody] UserInfoModel userInfoModel)
        {
            LogManager.PrintLogMessage("BlogApiController", "NewUser", "display name: " +
                userInfoModel.displayName + " email: " + userInfoModel.email + " uid: " + userInfoModel.uid, DefineManager.LOG_LEVEL_DEBUG);

            bool status = myBlogDBManager.AppendNewUser(userInfoModel);

            Dictionary<string, object> resultMsg = new Dictionary<string, object>();
            if (status)
            {
                resultMsg["msg"] = DefineManager.RESULT_MSG_OK;
            }
            else
            {
                resultMsg["msg"] = DefineManager.RESULT_MSG_FAIL;
            }

            return resultMsg;
        }
    }
}
