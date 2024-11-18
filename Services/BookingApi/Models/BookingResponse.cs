using System.ComponentModel.DataAnnotations;

namespace BookingApi.Models
{
    public class BookingResponse
    {
        [Key]
        public int ResponseId { get; set; }
        public int BookingId { get; set; }
        public bool ResponseValue { get; set; }=false;
        public string? ResponseMessage { get; set; }
        
    }
}
