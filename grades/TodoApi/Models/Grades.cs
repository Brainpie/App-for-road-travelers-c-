namespace Grades.Models
{
    public class Grades
    {
        public int Id { get; set; }
        public string? Place{ get; set; }
        public int? Rate { get; set; }
        public string? CityFrom { get; set; }
        public DateTime? DateFrom { get; set; }
        public string? CityTo { get; set; }
        public DateTime? DateTo { get; set; }
        public string? ClientId { get; set; }

    }
}