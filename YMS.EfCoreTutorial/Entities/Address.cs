namespace YMS.EfCoreTutorial.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public string? Definition { get; set; }

        public Employee? Employee { get; set; }

        public int EmployeeId { get; set; }
    }
}
