namespace Tiket.Models
{
    public class TodoItemDTO
    {
        public int Id { get; set; }
        public DateTime? Data1 { get; set; }
        public int CityId1 { get; set; }
        public DateTime? Data2 { get; set; }
        public int CityId2 { get; set; }
        public int? Price { get; set; }
        public string? Typetransport { get; set; }
        public int ClientId { get; set; }
    }
}
