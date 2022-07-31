using System.ComponentModel.DataAnnotations;

namespace YMS.EfCoreTutorial.Models
{
    public class CreateEmployeeModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Surname is required")]
        public string? Surname { get; set; }
    }
}
