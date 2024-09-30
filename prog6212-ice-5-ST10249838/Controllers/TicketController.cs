using Microsoft.AspNetCore.Mvc;
using ICE5.Models;

namespace ICE5.Controllers
{
    public class TicketController : Controller
    {
        public static List<TicketModel> Tickets = new List<TicketModel>();

        public IActionResult Index()
        {
            return View(Tickets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TicketModel ticket)
        {
            if (ModelState.IsValid)
            {
                var random = new Random();
                ticket.Id = random.Next(10000, 99999);
                Tickets.Add(ticket);
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        public IActionResult Edit(int id)
        {
            var ticket = Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Edit(TicketModel ticket)
        {
            if (ModelState.IsValid)
            {
                var existingTicket = Tickets.FirstOrDefault(t => t.Id == ticket.Id);
                if (existingTicket != null)
                {
                    existingTicket.CustomerName = ticket.CustomerName;
                    existingTicket.NumberOfTickets = ticket.NumberOfTickets;
                }
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        public IActionResult Delete(int id)
        {
            var ticket = Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var ticket = Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                Tickets.Remove(ticket);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Book(TicketModel ticket)
        {
            var showtime = ShowtimeController.ShowTimes.FirstOrDefault(s => s.Id == ticket.ShowtimeId);
            if (showtime == null)
            {
                return NotFound("Showtime does not exist.");
            }

            if (showtime.AvailableSeats < ticket.NumberOfTickets)
            {
                ModelState.AddModelError(string.Empty, "Insufficient seats available.");
                return View(ticket);
            }

            if (ModelState.IsValid)
            {
                showtime.AvailableSeats -= ticket.NumberOfTickets;
                return RedirectToAction("Confirmation");
            }
            return View(ticket);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
