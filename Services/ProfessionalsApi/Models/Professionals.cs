using System.ComponentModel.DataAnnotations;

namespace ProfessionalsApi.Models
{
    public class Professionals
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Gender { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;                    
        public DateOnly DOB { get; set; }
        public string? ProfilePic { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public decimal Rating { get; set; } = 0;
        public bool IsAvailable { get; set; }=false;
        public decimal BasePay { get; set; } = 0;
        public bool IsConfirmed { get; set; } = false;
        public string? Domain { get; set; } = string.Empty;
        public string? DocumentPath { get; set; }=string.Empty;
        public decimal CummilativeRating { get; set; } = 0;
        public int TotalReviews { get; set; } = 0;

    }
}
