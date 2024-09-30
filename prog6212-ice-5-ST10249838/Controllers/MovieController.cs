using Microsoft.AspNetCore.Mvc;
using ICE5.Models;

namespace ICE5.Controllers
{
    public class MovieController : Controller
    {
        public static List<MovieModel> Movies = new List<MovieModel>();

        public IActionResult Index()
        {
            return View(Movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                var random = new Random();
                movie.Id = random.Next(10000, 99999);
                Movies.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                var existingMovie = Movies.FirstOrDefault(m => m.Id == movie.Id);
                if (existingMovie != null)
                {
                    existingMovie.Title = movie.Title;
                    existingMovie.Genre = movie.Genre;
                    existingMovie.Duration = movie.Duration;
                }
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                Movies.Remove(movie);
            }
            return RedirectToAction("Index");
        }
    }
}
