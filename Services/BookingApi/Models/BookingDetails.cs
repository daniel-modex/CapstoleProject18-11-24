namespace BookingApi.Models
{
    public class BookingDetails
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string ProfessionalName { get; set; } = null!;
        public string? BookingStatus { get; set; }
        public bool BookingRequestedSuccessfully { get; set; }=false;
        public bool ServiceProviderResponse { get; set; } = false;
        public bool IsCompleted { get; set; } =false;
        public string? ServiceProvided { get; set; }
        public string? ServiceDetails { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool PaymetSuccessful { get; set; } =false ;
        public bool CancelationConfirmed { get; set; }=false ;
    }
}
