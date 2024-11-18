namespace ProfessionalsApi.Models
{
    public class UpdateProfile
    {
        public string name { get; set; }
        public string? Gender { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public DateOnly DOB { get; set; }
        public string? ProfilePic { get; set; } = string.Empty;
        public decimal BasePay { get; set; }
        public string? DocumentPath { get; set; }
        public string? Domain { get; set; }
        public string? City { get; set; }


    }
}
