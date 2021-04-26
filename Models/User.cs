using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public virtual List<BorrowRequest> BorrowRequests { get; set; }
    }

    public class UserResponse : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }

    public class LoggedInUserResponse : UserResponse
    {
        public string Role { get; set; }
    }
}