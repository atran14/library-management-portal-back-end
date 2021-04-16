
using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public class BorrowRequest : IEntity
    {
        public int Id { get; set; }
        public List<BorrowRequestDetails> BorrowRequestDetails { get; set; }
        public DateTime BorrowRequestDate { get; set; }
        public DateTime? BorrowUntilDate { get; set; }
        public int RequestUserId { get; set; }
        public User RequestUser { get; set; }
        public DateTime? ActionTime { get; set; }
        public int? ActionByUserId { get; set; }
        public User ActionByUser { get; set; }
        public BorrowRequestStatus ActionStatus { get; set; }
    }
}