namespace ProfessionalsApi.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public string? ProfessionalName  { get; set; }
        public string? UserName { get; set; }
        public DateTime DateTime { get; set; }
        public string? Message { get; set; }
        public decimal UserRating { get; set; } = 0;
    }
}
