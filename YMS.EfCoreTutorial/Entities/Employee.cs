using System.ComponentModel.DataAnnotations;

namespace YMS.EfCoreTutorial.Entities
{
    //entity => db deki tablonun programatik olarak class karşılığı
    // => SRP ' ye aykırı
    // Single Responsibility Principle => SOLID 
    // TEK SORUMLULUK
    // DbContext
    public class Employee
    {
        public int Id { get; set; }
        // Dataannotation
        // constraint => Name

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public List<Address>? Addresses { get; set; }
    }
}
