using System;
using System.Collections.Generic;
using System.Text;

namespace ADO_Basics.Models
{
    public class UserInfo
    {
        public required string IdNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
