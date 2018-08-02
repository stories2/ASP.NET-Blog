using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class NewArticleModel
    {
        public string clientToken { get; set; }
        public string title { get; set; }
        public string highlightText { get; set; }
        public string imgUrl { get; set; }
        public string articleContent { get; set; }
    }
}