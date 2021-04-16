using System.Collections.Generic;

namespace back_end.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public int CategoryId {get; set;}
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Authors { get; set; }
        public string Description { get; set; }
        public List<BorrowRequestDetails> BorrowRequestDetails { get; set; }
    }
}