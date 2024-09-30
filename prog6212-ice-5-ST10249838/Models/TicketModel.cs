using System.ComponentModel.DataAnnotations;

namespace ICE5.Models
{
    public class TicketModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Showtime ID is required.")]
        public int ShowtimeId { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [MaxLength(100, ErrorMessage = "Customer name cannot exceed 100 characters.")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Number of tickets is required.")]
        [Range(1, 10, ErrorMessage = "You can book between 1 and 10 tickets.")]
        public int NumberOfTickets { get; set; }
    }
}
