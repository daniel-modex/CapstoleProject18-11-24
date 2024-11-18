namespace ProfessionalsApi.Models
{
    public class Domains
    {
        public int Id { get; set; }
        public string? DomainName { get; set; }
        public string? ProfessionalName { get; set; }
        public int ProfessionalId { get; set; }
        public bool IsAvailable { get; set; } = false;
    }
}
