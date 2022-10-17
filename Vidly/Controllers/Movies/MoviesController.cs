using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using System.Web.Configuration;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Avengers" };

            var customers = new List<Customer>()
            {
                new Customer() {Name = "Json", Id = 1},
                new Customer() {Name = "Python", Id=2},
            };

            var movieRandom = new RandomMovieViewModel() { Customers = customers , Movie = movie };

            return View(movieRandom);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }


        public ActionResult Index()
        {
            //if (!pageIndex.HasValue)
            //{
            //    pageIndex = 1;
            //}


            //if (String.IsNullOrEmpty(sortBy))
            //{
            //    sortBy = "Release Date";

            //}

            //return Content(String.Format("Index={0}&SortBy={1}",pageIndex,sortBy));

            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);

        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).ToList().Find(m => m.Id == id);
            if(movie == null)
                return HttpNotFound();
            return View(movie);
        }


        public ActionResult New()
        {
            var movieFormViewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("MoviesForm", movieFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            var movieFormViewModel = new MovieFormViewModel()
            {   
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MoviesForm", movieFormViewModel);
        }


        [HttpPost]
        public ActionResult Save (Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var moviesInDB = _context.Movies.Single(m => m.Id == movie.Id);
                moviesInDB.Name = movie.Name;
                moviesInDB.ReleaseDate = movie.ReleaseDate;
                moviesInDB.GenreId = movie.GenreId;
                moviesInDB.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }


        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}