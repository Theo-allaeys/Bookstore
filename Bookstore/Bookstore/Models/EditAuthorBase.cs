using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class EditAuthorBase
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string firstname { get; set; }

        [Required]
        [MaxLength(100)]
        public string lastname { get; set; }

        [Required]
        public DateTime birthdate { get; set; }
    }
}
