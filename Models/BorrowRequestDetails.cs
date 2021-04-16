using System.Collections.Generic;

namespace back_end.Models
{
    public class BorrowRequestDetails : IEntity
    {
        public int Id { get; set; }
        public int BorrowRequestId { get; set; }
        public BorrowRequest BorrowRequest { get; set; }
        public int RequestedBookId { get; set; }
        public Book RequestedBook { get; set; }
    }
}