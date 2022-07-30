using System.ComponentModel.DataAnnotations;

namespace YMS.EfCoreTutorial.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Username { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }
    }
}
