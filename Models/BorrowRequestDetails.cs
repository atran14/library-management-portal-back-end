using System.Collections.Generic;

namespace back_end.Models
{
    public class BorrowRequestDetails : IEntity
    {
        public int Id { get; set; }
        public int BorrowRequestId { get; set; }
        public virtual BorrowRequest BorrowRequest { get; set; }
        public int RequestedBookId { get; set; }
        public virtual Book RequestedBook { get; set; }
    }

    public class BorrowRequestDetailsResponse : IEntity
    {
        public int Id { get; set; }
        public int BorrowRequestId { get; set; }
        public int RequestedBookId { get; set; }
        public string RequestedBook { get; set; }
    }
}