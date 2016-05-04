using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Portal.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Opis")]
        [StringLength(100, ErrorMessage = "Długość opisu musi składać się od 6-10 znaków.", MinimumLength = 6)]
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