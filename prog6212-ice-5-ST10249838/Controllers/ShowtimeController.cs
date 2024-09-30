using Microsoft.AspNetCore.Mvc;
using ICE5.Models;

namespace ICE5.Controllers
{
    public class ShowtimeController : Controller
    {
        public static List<ShowtimeModel> ShowTimes = new List<ShowtimeModel>();

        public IActionResult Index()
        {
            return View(ShowTimes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShowtimeModel showTime)
        {
            if (ModelState.IsValid)
            {
                var random = new Random();
                showTime.Id = random.Next(10000, 99999);
                ShowTimes.Add(showTime);
                return RedirectToAction("Index");
            }
            return View(showTime);
        }

        public IActionResult Edit(int id)
        {
            var showTime = ShowTimes.FirstOrDefault(st => st.Id == id);
            if (showTime == null)
            {
                return NotFound();
            }
            return View(showTime);
        }

        [HttpPost]
        public IActionResult Edit(ShowtimeModel showTime)
        {
            if (ModelState.IsValid)
            {
                var existingShowTime = ShowTimes.FirstOrDefault(st => st.Id == showTime.Id);
                if (existingShowTime != null)
                {
                    existingShowTime.Showtime = showTime.Showtime;
                    existingShowTime.AvailableSeats = showTime.AvailableSeats;
                }
                return RedirectToAction("Index");
            }
            return View(showTime);
        }

        public IActionResult Delete(int id)
        {
            var showTime = ShowTimes.FirstOrDefault(st => st.Id == id);
            if (showTime == null)
            {
                return NotFound();
            }
            return View(showTime);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var showTime = ShowTimes.FirstOrDefault(st => st.Id == id);
            if (showTime != null)
            {
                ShowTimes.Remove(showTime);
            }
            return RedirectToAction("Index");
        }
    }
}
