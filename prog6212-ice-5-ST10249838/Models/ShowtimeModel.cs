using System.ComponentModel.DataAnnotations;

namespace ICE5.Models
{
    public class ShowtimeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie ID is required.")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Showtime is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date and time.")]
        public DateTime Showtime { get; set; }

        [Required(ErrorMessage = "Available seats are required.")]
        [Range(1, 100, ErrorMessage = "Available seats must be between 1 and 100.")]
        public int AvailableSeats { get; set; }
    }
}
