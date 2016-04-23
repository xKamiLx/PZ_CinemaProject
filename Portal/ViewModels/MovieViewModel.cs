using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;

namespace Portal.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public MovieViewModel()
        {
        }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Description = movie.Description;
        }
    }
}