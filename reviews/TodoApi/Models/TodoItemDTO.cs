namespace Reviews.Models
{
    public class TodoItemDTO
    {
        public int Id { get; set; }
        public string? CityFrom { get; set; }
        public DateTime? DateFrom { get; set; }
        public string? CityTo { get; set; }
        public DateTime? DateTo { get; set; }
        public string? Comment { get; set; }
        public int? Rate { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Dateborn { get; set; }
        public string? Number { get; set; }
        public string? Pasport { get; set; }
    }
}
