namespace Client.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Dateborn { get; set; }
        public string? Number { get; set; }
        public string? Pasport { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}