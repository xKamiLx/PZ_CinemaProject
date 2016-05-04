using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using Portal.Models;
using System.ComponentModel.DataAnnotations;

namespace Portal.ViewModels
{
    public class NewsViewModel
    {
        //TODO
        //MaQ read about Attributes, and use them to this properties
        //http://www.asp.net/mvc/overview/older-versions/getting-started-with-aspnet-mvc4/adding-validation-to-the-model
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Opis")]
        [StringLength(100, ErrorMessage = "Długość opisu musi składać się od 6-10 znaków.", MinimumLength = 6)]
        public string Description { get; set; }

        public DateTime AddedDateTime { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

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
    }
}