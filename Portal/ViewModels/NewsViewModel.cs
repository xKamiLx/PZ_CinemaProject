using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using Portal.Models;

namespace Portal.ViewModels
{
    public class NewsViewModel
    {
        public NewsViewModel()
        {
        }
        public NewsViewModel(News news)
        {
            Id = news.Id;
            Title = news.Title;
            Description = news.Description;
            AddedDateTime = news.AddedDateTime;
            ApplicationUser = news.ApplicationUser;
        }

        //TODO
        //MaQ read about Attributes, and use them to this properties
        //http://www.asp.net/mvc/overview/older-versions/getting-started-with-aspnet-mvc4/adding-validation-to-the-model

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedDateTime { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}