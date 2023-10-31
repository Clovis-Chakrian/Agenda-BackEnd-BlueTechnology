namespace Agenda.API.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}