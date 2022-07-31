using System.ComponentModel.DataAnnotations;

namespace YMS.EfCoreTutorial.Entities
{
    //SRP => S => Single Responsibility 
    public class AppUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
  
        public string? Password { get; set; }


        public int RoleId { get; set; }

        public AppRole? AppRole { get; set; }
    }
}
