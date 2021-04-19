using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApi.Models
{
    public class ArticleNotice
    {
        string status { get; set; }
        int totalResults { get; set; }
        IList<Article> articles { get; set; }
    }


    public class Article
    {
        Source source { get; set; }

        string author { get; set; }
        string title { get; set; }
        string description { get; set; }
        string url { get; set; }
        string urlToImage { get; set; }
        string publishedAt { get; set; }
        string content { get; set; }
    }

    public class Source
    {
        int id { get; set; }
        string name { get; set; }
    }

}
