using System.ComponentModel.DataAnnotations;

namespace UserApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Gender { get; set; }=string.Empty;
        public string? Address { get; set; }= string.Empty;
        public DateOnly DOB { get; set; } 
        public string? ProfilePic { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public string? City { get; set; } = string.Empty ;  



    }
}
