using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ProfilePic { get; set; }
    }
}
