namespace BookingApi.Models
{
    public class BookingRequest
    {
        public string UserName { get; set; } = null!;
        public string ProfessionalName { get; set; } = null!;
        public string? BookingStatus { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string? ServiceProvided { get; set; }
        public string? ServiceDetails { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
