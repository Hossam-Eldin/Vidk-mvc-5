using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidk.Models;

namespace Vidk.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ViewResult Index()
        {
            var Movies = GetMovies();

            return View(Movies);
        }


        private IEnumerable<Movies>  GetMovies()
        {
            return new List<Movies>
                {
                   new Movies { Id = 1, Name = "God Father" },
                   new Movies{Id = 2, Name = "Lord of the rings"}
                };
        }
    }
}