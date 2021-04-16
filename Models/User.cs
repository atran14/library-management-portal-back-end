using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public List<BorrowRequest> BorrowRequests {get; set;}
    }
}