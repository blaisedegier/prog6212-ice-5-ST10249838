using System.ComponentModel.DataAnnotations;

namespace ICE5.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string? Genre { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [Range(30, 300, ErrorMessage = "Duration must be between 30 and 300 minutes.")]
        public int Duration { get; set; }
    }
}
